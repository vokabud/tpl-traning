using System.Threading.Tasks;

namespace AsyncAwaitLoop.Interfaces
{
    public interface IProducer<TData>
    {
        Task<TData> ProduceAsync(string siteUrl);
    }
}
