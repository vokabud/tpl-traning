using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TplProducerConsumer.Interfaces;

namespace TplProducerConsumer
{
    class Processor<TData, TError> : IProcessor<TData, TError>
    {
        private readonly IProducer<TData, TError> _producer;

        private readonly IConsumer<TData>[] _consumers;

        private readonly IConfiguration _configuration;

        private readonly ILogger _logger;

        public Processor(
            IProducer<TData, TError> producer, 
            IConsumer<TData>[] consumers, 
            IConfiguration configuration, 
            ILogger logger)
        {
            this._producer = producer;
            this._consumers = consumers;
            this._configuration = configuration;
            this._logger = logger;
        }

        public void RunAndWait()
        {
            var siteUrls = this._configuration.GetSiteList();
            var tasks = new List<Task>();

            foreach (var siteUrl in siteUrls)
            {
                 var producerTask =  Task.Run(() =>
                 {
                    var site = this._producer.Produce(siteUrl);

                    if (site.HasError)
                    {
                        this._logger.LogError(site.Error.ToString());
                        return;
                    }

                    var innerTasks = this._consumers.Select(
                        con => Task.Factory.StartNew(() =>
                        {
                            con.Consume(site.Value);
                        }, TaskCreationOptions.AttachedToParent))
                        .ToArray();

                    Task.WaitAll(innerTasks);
                });

                tasks.Add(producerTask);
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
