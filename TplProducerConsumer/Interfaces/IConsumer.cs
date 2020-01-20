namespace TplProducerConsumer.Interfaces
{
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }
}
