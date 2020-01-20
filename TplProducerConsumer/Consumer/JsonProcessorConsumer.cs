using TplProducerConsumer.Interfaces;
using TplProducerConsumer.Models;

namespace TplProducerConsumer.Consumer
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
        public void Consume(Site site)
        {
            try
            {
                var jsonProcessingResult = this._jsonParser.Parse(site);

                this._logger.LogInfo($"Put JSON to file ({site.Url})");

                this._writer
                    .Write(
                        jsonProcessingResult,
                        this._fileName);
            }
            catch
            {
                this._logger.LogError($"Error while JSON processing of {site.Url}");
            }
        }
    }
}
