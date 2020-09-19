
namespace CustomQueue
{
    public interface IAbstractQueue<T>
    {
        void Enqueue(T item);

        T Dequeue();

        T Peek();

        int Count { get; }


    }
}
