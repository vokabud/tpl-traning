using System.Net;
using System.Threading.Tasks;
using AsyncAwaitLoop.Interfaces;

namespace AsyncAwaitLoop.Helpers
{
    internal class SiteContentReader : ISiteContentReader
    {
        private readonly ILogger _logger;

        public SiteContentReader(ILogger logger)
        {
            this._logger = logger;
        }
        
        public async Task<string> ReadContentAsync(string siteUrl)
        {
            this._logger.LogInfo($"Read site {siteUrl}");

            using (var client = new WebClient())
            {
                return await Task.Run(
                    () => client.DownloadString(siteUrl));
            }
        }
    }
}
