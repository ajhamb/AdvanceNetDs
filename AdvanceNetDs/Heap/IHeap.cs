using System;
using AdvanceNetDs.Shared;

namespace AdvanceNetDs.Heap
{
    public interface IHeap<T> where T : IComparable<T>
    {
        void Add(Node<T> data);
        Node<T> PeekTop();
        Node<T> RemoveTop();
        void HeapifyDown();
        void HeapifyUp();
        int Count();

    }
}
