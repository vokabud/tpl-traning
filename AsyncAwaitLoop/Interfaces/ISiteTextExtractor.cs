using System.Threading.Tasks;
using AsyncAwaitLoop.Models;

namespace AsyncAwaitLoop.Interfaces
{
    public interface ISiteTextExtractor
    {
        Task<string> ExtractContentAsync(Site site);
    }
}
