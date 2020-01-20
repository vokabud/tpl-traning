using System.Threading.Tasks;

namespace TplProducerConsumer.Interfaces
{
    public interface IProducer<TData, TError>
    {
        Maybe<TData, TError> Produce(string siteUrl);
    }
}
