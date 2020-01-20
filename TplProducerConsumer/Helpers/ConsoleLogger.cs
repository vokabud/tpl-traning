using System;
using TplProducerConsumer.Interfaces;

namespace TplProducerConsumer.Helpers
{
    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string message)
        {
            this.Log(message, "INFO");
        }

        public void LogError(string message)
        {
            this.Log(message, "ERROR");
        }

        private void Log(string message, string type)
        {
            Console.WriteLine($"{DateTime.Now} {type}: {message}");
        }
    }
}
