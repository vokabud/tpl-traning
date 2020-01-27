using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitLoop.Consumer;
using AsyncAwaitLoop.Helpers;
using AsyncAwaitLoop.Interfaces;
using AsyncAwaitLoop.Models;
using AsyncAwaitLoop.Producer;
using AsyncAwaitLoop;
using Unity;

namespace AsyncAwaitLoop
{
    class Program
    {
        private static UnityContainer container;

        static async Task Main(string[] args)
        {
            InitUnityContainer();

            var processor = container.Resolve<IProcessor<Site>>();
            await processor.RunAndWait();

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

            container.RegisterType<IProducer<Site>, SiteReaderProducer>();
            container.RegisterType<IConsumer<Site>, JsonProcessorConsumer>("JsonProcessorConsumer");
            container.RegisterType<IConsumer<Site>, TextProcessorConsumer>("TextProcessorConsumer");

            container.RegisterType<IProcessor<Site>, Processor<Site>>();
        }
    }
}
