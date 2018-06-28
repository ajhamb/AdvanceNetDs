using System;
using System.Collections.Generic;
using System.ComponentModel;
using AdvanceNetDs.Shared;

namespace AdvanceNetDs.Heap
{
    public abstract class HeapWithArray<T> : IHeap<T> where T : IComparable<T>
    {
        private readonly HeapTypeEnum _heapTypeEnum;

        private readonly IList<Node<T>> _heapDataNodes;

        private readonly Func<T, T, bool> _operation;

        protected HeapWithArray(HeapTypeEnum heapTypeEnum)
        {
            _heapTypeEnum = heapTypeEnum;
            _operation = GetOperation();
            _heapDataNodes = new List<Node<T>>();
        }

        private Func<T, T, bool> GetOperation()
        {
            switch (_heapTypeEnum)
            {
                case HeapTypeEnum.Min: return ((parent, child) => parent.CompareTo(child) < 0);
                case HeapTypeEnum.Max: return ((parent, child) => parent.CompareTo(child) > 0);
            }

            throw new InvalidEnumArgumentException(" Incorrect Heap Type");
        }

        public void Add(Node<T> data)
        {
            _heapDataNodes.Add(data);
            HeapifyUp();
        }

        public Node<T> PeekTop()
        {
            if (Count() <= 0) throw new NullReferenceException("Heap has No Data");
            return _heapDataNodes[0];
        }

        public Node<T> RemoveTop()
        {
            if (Count() <= 0) throw new NullReferenceException("Heap has No Data");

            var data = _heapDataNodes[0];

            _heapDataNodes[0].Data = _heapDataNodes[Count() - 1].Data;

            _heapDataNodes.RemoveAt(Count() - 1);

            HeapifyDown();

            return data;
        }

        public void HeapifyDown()
        {
            if(Count() <= 0) return;
            int index = 0;

            while (HasLeftChild(index))
            {
                int smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && !_operation(_heapDataNodes[smallerIndex].Data, _heapDataNodes[GetRightChildIndex(index)].Data))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_operation(_heapDataNodes[index].Data, _heapDataNodes[smallerIndex].Data))
                    return;


                Swap(_heapDataNodes, index, smallerIndex);
                index = smallerIndex;
            }
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= Count() - 1;
        }

        private int GetLeftChildIndex(int index)
        {
            return (2 * index + 1);
        }

        private int GetRightChildIndex(int index)
        {
            return (2 * index + 2);
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= Count() - 1;
        }

        public void HeapifyUp()
        {
            int index = Count() - 1;

            while (HasParent(index) &&  !_operation(_heapDataNodes[GetParentIndex(index)].Data, _heapDataNodes[index].Data))
            {
                Swap(_heapDataNodes, index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void Swap(IList<Node<T>> heapDataNodes, int index, int getParentIndex)
        {
            var temp = heapDataNodes[getParentIndex].Data;
            heapDataNodes[getParentIndex].Data = heapDataNodes[index].Data;
            heapDataNodes[index].Data = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private bool HasParent(int index)
        {
            return index > 0 && (index - 1) / 2 >= 0;
        }

        public int Count()
        {
            return _heapDataNodes.Count;
        }
    }
}
