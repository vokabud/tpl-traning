using System.Threading.Tasks;
using AsyncAwaitLoop.Helpers;
using AsyncAwaitLoop.Interfaces;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Consumer
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
        public async Task ConsumeAsync(Site site)
        {
            var textProcessingResult = this._textExtractor.ExtractContentAsync(site);

            this._logger.LogInfo($"Put TEXT to file ({site.Url})");

            await this._writer
                .WriteAsync(
                    await textProcessingResult,
                    this._fileNameBuilder.GenerateFileName("site_text", "json"));
        }
    }
}
