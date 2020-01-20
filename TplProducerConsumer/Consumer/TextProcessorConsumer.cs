using TplProducerConsumer.Helpers;
using TplProducerConsumer.Interfaces;
using TplProducerConsumer.Models;

namespace TplProducerConsumer.Consumer
{
    internal class TextProcessorConsumer : IConsumer<Site>
    {
        private readonly IFileWriter _writer;

        private readonly ILogger _logger;

        private readonly FileNameBuilder _fileNameBuilder;

        private readonly ISiteTextExtractor _textExtractor;

        public TextProcessorConsumer(
            IFileWriter writer, 
            ILogger logger, 
            FileNameBuilder fileNameBuilder, 
            ISiteTextExtractor textExtractor)
        {
            this._writer = writer;
            this._logger = logger;
            this._fileNameBuilder = fileNameBuilder;
            this._textExtractor = textExtractor;
        }
        public void Consume(Site site)
        {
            try
            {
                var textProcessingResult = this._textExtractor.ExtractContent(site);

                this._logger.LogInfo($"Put TEXT to file ({site.Url})");

                this._writer
                    .Write(
                        textProcessingResult,
                        this._fileNameBuilder.GenerateFileName("site_text", "json"));
            }
            catch
            {
                this._logger.LogError($"Error while TEXT processing of {site.Url}");
            }
        }
    }
}
