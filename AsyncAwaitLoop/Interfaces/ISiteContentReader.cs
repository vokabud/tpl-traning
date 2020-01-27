using System.Threading.Tasks;

namespace AsyncAwaitLoop.Interfaces
{
    public interface ISiteContentReader
    {
        Task<string> ReadContentAsync(string siteUrl);
    }
}
