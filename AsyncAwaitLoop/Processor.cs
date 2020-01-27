using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncAwaitLoop.Interfaces;

namespace AsyncAwaitLoop
{
    class Processor<TData> : IProcessor<TData>
    {
        private readonly IProducer<TData> _producer;

        private readonly IConsumer<TData>[] _consumers;

        private readonly IConfiguration _configuration;

        private readonly ILogger _logger;

        public Processor(
            IProducer<TData> producer, 
            IConsumer<TData>[] consumers, 
            IConfiguration configuration, 
            ILogger logger)
        {
            this._producer = producer;
            this._consumers = consumers;
            this._configuration = configuration;
            this._logger = logger;
        }
        
        public async Task RunAndWait()
        {
            var consumerTasks = new List<Task>();
            var siteUrls = this._configuration.GetSiteList();

            using (var blockingCollection = new BlockingCollection<TData>(4))
            {
                var producingTask = Task.Run(() =>
                {
                    foreach (var siteUrl in siteUrls)
                    {
                        try
                        {
                            var site = this._producer.ProduceAsync(siteUrl);
                            blockingCollection.Add(site.Result);
                        }
                        catch 
                        {
                            this._logger.LogError($"error for {siteUrl}");
                        }
                    }

                    blockingCollection.CompleteAdding();
                });

                foreach (var item in blockingCollection.GetConsumingEnumerable())
                {
                    foreach (var consumer in this._consumers)
                    {
                        consumerTasks.Add(Task.Run(() => consumer
                            .ConsumeAsync(item)));
                    }
                }
                
                await producingTask;
            }

            await Task.WhenAll(consumerTasks);
        }
    }
}
