using System.Threading.Tasks;

namespace TplProducerConsumer.Interfaces
{
    public interface ISiteContentReader
    {
        string ReadContent(string siteUrl);
    }
}
