using System.IO;
using TplProducerConsumer.Interfaces;

namespace TplProducerConsumer.Helpers
{
    public class Configuration : IConfiguration
    {
        private string _jsonFileName;

        public string[] GetSiteList()
        {
            return File.ReadAllLines("data.txt");
        }

        public string JsonFileName
        {
            get
            {
                if (string.IsNullOrEmpty(this._jsonFileName))
                {
                    this._jsonFileName = new FileNameBuilder()
                        .GenerateFileName("json", "json");
                }

                return this._jsonFileName;
            }
        }
    }
}
