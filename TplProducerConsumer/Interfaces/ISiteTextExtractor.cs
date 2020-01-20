using TplProducerConsumer.Models;

namespace TplProducerConsumer.Interfaces
{
    public interface ISiteTextExtractor
    {
        string ExtractContent(Site site);
    }
}
