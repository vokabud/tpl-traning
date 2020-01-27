using System.Threading.Tasks;
using HtmlAgilityPack;
using AsyncAwaitLoop.Interfaces;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Helpers
{
    internal class SiteTextExtractor : ISiteTextExtractor
    {
        private readonly ILogger _logger;

        public SiteTextExtractor(ILogger logger)
        {
            this._logger = logger;
        }
        
        public async Task<string> ExtractContentAsync(Site site)
        {
            return await Task.Run(() =>
            {
                this._logger.LogInfo($"Extract site inner text ({site.Url})");

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(site.Content);

                return htmlDocument
                    .DocumentNode
                    .InnerText;
            });
        }
    }
}
