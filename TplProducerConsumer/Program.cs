using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TplProducerConsumer.Consumer;
using TplProducerConsumer.Helpers;
using TplProducerConsumer.Interfaces;
using TplProducerConsumer.Models;
using TplProducerConsumer.Producer;
using Unity;
using Unity.Injection;

namespace TplProducerConsumer
{
    class Program
    {
        private static UnityContainer container;

        static void Main(string[] args)
        {
            InitUnityContainer();

            var processor = container.Resolve<IProcessor<Site, string>>();

            processor.RunAndWait();

            Console.WriteLine("That's all!");
        }

        private static void InitUnityContainer()
        {
            container = new UnityContainer();

            container.RegisterType<ILogger, ConsoleLogger>();
            container.RegisterType<IConfiguration, Configuration>();

            container.RegisterType<IFileWriter, FileWriter>();
            container.RegisterType<IJsonParser, SiteJsonParser>();
            container.RegisterType<ISiteContentReader, SiteContentReader>();
            container.RegisterType<ISiteTextExtractor, SiteTextExtractor>();

            container.RegisterType<IProducer<Site, string>, SiteReaderProducer>();
            container.RegisterType<IConsumer<Site>, JsonProcessorConsumer>("JsonProcessorConsumer");
            container.RegisterType<IConsumer<Site>, TextProcessorConsumer>("TextProcessorConsumer");

            container.RegisterType<IProcessor<Site, string>, Processor<Site, string>>();
        }
    }
}
