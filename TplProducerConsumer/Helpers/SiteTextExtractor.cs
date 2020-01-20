using HtmlAgilityPack;
using TplProducerConsumer.Interfaces;
using TplProducerConsumer.Models;

namespace TplProducerConsumer.Helpers
{
    internal class SiteTextExtractor : ISiteTextExtractor
    {
        private readonly ILogger _logger;

        public SiteTextExtractor(ILogger logger)
        {
            this._logger = logger;
        }
        
        public string ExtractContent(Site site)
        {
            this._logger.LogInfo($"Extract site inner text ({site.Url})");

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(site.Content);

            return htmlDocument
                .DocumentNode
                .InnerText;
        }
    }
}
