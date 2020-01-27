using System.Threading.Tasks;
using AsyncAwaitLoop.Interfaces;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Producer
{
    public class SiteReaderProducer : IProducer<Site>
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

        public async Task<Site> ProduceAsync(string siteUrl)
        {
            this._logger.LogInfo($"Produce HTML of ({siteUrl})");

            return new Site(
                url: siteUrl,
                content: await this._siteContentReader.ReadContentAsync(siteUrl));
        }
    }
}
