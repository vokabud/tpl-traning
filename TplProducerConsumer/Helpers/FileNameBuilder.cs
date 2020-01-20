namespace TplProducerConsumer.Helpers
{
    using System;

    public class FileNameBuilder
    {
        public string GenerateFileName(string prefix, string extension)
        {
            return $"{prefix}_{Guid.NewGuid()}.{extension}";
        }
    }
}
