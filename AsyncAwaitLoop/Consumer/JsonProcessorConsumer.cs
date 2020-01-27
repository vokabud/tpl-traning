using System.Threading.Tasks;
using AsyncAwaitLoop.Models;
using AsyncAwaitLoop.Interfaces;

namespace AsyncAwaitLoop.Consumer
{
    internal class JsonProcessorConsumer : IConsumer<Site>
    {
        private readonly string _fileName;

        private readonly IFileWriter _writer;

        private readonly IJsonParser _jsonParser;

        private readonly ILogger _logger;

        public JsonProcessorConsumer(
            IFileWriter writer, 
            IJsonParser jsonParser,
            IConfiguration configuration, 
            ILogger logger)
        {
            this._writer = writer;
            this._jsonParser = jsonParser;
            this._logger = logger;
            this._fileName = configuration.JsonFileName;
        }
        public async Task ConsumeAsync(Site site)
        {
            var jsonProcessingResult = this._jsonParser.ParseAsync(site);

            this._logger.LogInfo($"Put JSON to file ({site.Url})");

            await this._writer
                .WriteAsync(
                    await jsonProcessingResult,
                    this._fileName);
        }
    }
}
