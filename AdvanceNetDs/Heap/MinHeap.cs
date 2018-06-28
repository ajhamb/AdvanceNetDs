using System;
using AdvanceNetDs.Shared;

namespace AdvanceNetDs.Heap
{
    public class MinHeap<T> : HeapWithArray<T>, IMinHeap<T> where T : IComparable<T>
    {
        public MinHeap(): base(HeapTypeEnum.Min )
        {

        }

        public Node<T> PeekMinElement()
        {
            return PeekTop();
        }

        public Node<T> RemoveMinElement()
        {
            return RemoveTop();
        }
    }
}
