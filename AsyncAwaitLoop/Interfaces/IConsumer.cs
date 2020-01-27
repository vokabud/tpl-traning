using System.Threading.Tasks;

namespace AsyncAwaitLoop.Interfaces
{
    public interface IConsumer<in T>
    {
        Task ConsumeAsync(T item);
    }
}
