using System.Threading.Tasks;

namespace AsyncAwaitLoop.Interfaces
{
    interface IFileWriter
    {
        Task WriteAsync(string text, string fileName);
    }
}
