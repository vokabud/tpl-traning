using System.Threading.Tasks;
using TplProducerConsumer.Interfaces;
using TplProducerConsumer.Models;

namespace TplProducerConsumer.Producer
{
    public class SiteReaderProducer : IProducer<Site, string>
    {
        private readonly ILogger _logger;

        private readonly ISiteContentReader _siteContentReader;

        public SiteReaderProducer(
            ILogger logger, 
            ISiteContentReader siteContentReader)
        {
            this._logger = logger;
            this._siteContentReader = siteContentReader;
        }

        public Maybe<Site, string> Produce(string siteUrl)
        {
            try
            {
                this._logger.LogInfo($"Produce HTML of ({siteUrl})");

                return new Maybe<Site, string>(
                    new Site(
                        url: siteUrl,
                        content: this._siteContentReader.ReadContent(siteUrl)));
            }
            catch
            {
                return new Maybe<Site, string>("Error wile produce");
            }
        }
    }
}
