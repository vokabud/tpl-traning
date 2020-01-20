using TplProducerConsumer.Interfaces;

namespace TplProducerConsumer.Helpers
{
    using System.IO;

    internal class FileWriter : IFileWriter
    {
        private readonly ILogger _logger;

        public FileWriter(ILogger logger)
        {
            this._logger = logger;
        }

        public void Write(string text, string fileName)
        {
            this._logger.LogInfo($"Write text to file {fileName}");

            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(text);
                file.Write("\r\n-------------separator-------------\r\n");
            }
        }
    }
}
