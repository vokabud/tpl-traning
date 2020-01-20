using System.Net;
using TplProducerConsumer.Interfaces;

namespace TplProducerConsumer.Helpers
{
    internal class SiteContentReader : ISiteContentReader
    {
        private readonly ILogger _logger;

        public SiteContentReader(ILogger logger)
        {
            this._logger = logger;
        }
        
        public string ReadContent(string siteUrl)
        {
            this._logger.LogInfo($"Read site {siteUrl}");

            using (var client = new WebClient())
            {
                return client.DownloadString(siteUrl);
            }
        }
    }
}
