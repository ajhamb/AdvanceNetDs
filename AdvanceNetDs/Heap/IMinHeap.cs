using System;
using AdvanceNetDs.Shared;

namespace AdvanceNetDs.Heap
{
    public interface IMinHeap<T> : IHeap<T> where T : IComparable<T>
    {
        Node<T> PeekMinElement();

        Node<T> RemoveMinElement();
    }
}
