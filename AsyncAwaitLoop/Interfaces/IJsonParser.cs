using System.Threading.Tasks;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Interfaces
{
    public interface IJsonParser
    {
        Task<string> ParseAsync(Site site);
    }
}
