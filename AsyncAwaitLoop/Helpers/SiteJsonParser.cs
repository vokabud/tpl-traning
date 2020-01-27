using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HtmlAgilityPack;
using AsyncAwaitLoop.Interfaces;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Helpers
{
    internal class SiteJsonParser : IJsonParser
    {
        private readonly ILogger _logger;

        public SiteJsonParser(ILogger logger)
        {
            this._logger = logger;
        }
        
        public  async Task<string> ParseAsync(Site site)
        {
            return await Task.Run(() =>
            {
                this._logger.LogInfo($"Parse site to JSON ({site.Url})");

                var doc = new HtmlDocument();
                var serializer = new JavaScriptSerializer();

                doc.LoadHtml(site.Content);

                var json = doc.DocumentNode
                    .SelectNodes("//*")
                    .GroupBy(node => node.Name)
                    .Select(n => new
                    {
                        Name = n.Key,
                        Count = n.Count()
                    });

                return serializer.Serialize(json);
            });
        }
    }
}
