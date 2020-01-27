using System.Threading.Tasks;
using AsyncAwaitLoop.Interfaces;

namespace AsyncAwaitLoop.Helpers
{
    using System.IO;

    internal class FileWriter : IFileWriter
    {
        private readonly ILogger _logger;

        public FileWriter(ILogger logger)
        {
            this._logger = logger;
        }

        public async Task WriteAsync(string text, string fileName)
        {
            this._logger.LogInfo($"Write text to file {fileName}");

            using (var file = new StreamWriter(fileName, true))
            {
                await file.WriteLineAsync(text);
            }
        }
    }
}
