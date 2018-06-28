using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdvanceNetDs.Shared;
using AdvanceNetDs.Tree;

namespace AdvanceNetDs.Heap
{
    public abstract class HeapWithTree<T> : IHeap<T> where T : IComparable<T>
    {
        private HeapTypeEnum _heapTypeEnum;

        private BinaryTree<T> _root;

        protected HeapWithTree(HeapTypeEnum heapTypeEnum)
        {
            _heapTypeEnum = heapTypeEnum;
        }

        public void Add(Node<T> data)
        {
            if (_root == null)
            {
                _root = new BinaryTree<T>(data);
                return;
            }

            bool bInserted = false;

            BinaryTree<T> tempNode = _root;
            Queue<BinaryTree<T>> tempQueue = new Queue<BinaryTree<T>>();
            tempQueue.Enqueue(_root);
            while (tempQueue.Any())
            {
                BinaryTree<T> temp = tempQueue.Dequeue();

                if (temp.Left == null)
                {
                    temp.Left = new BinaryTree<T>(data);
                    HeapifyDown();
                    return;
                }

                if (temp.Right == null)
                {
                    temp.Right = new BinaryTree<T>(data);
                    HeapifyDown();
                    return;
                }

                tempQueue.Enqueue(temp.Left);
                tempQueue.Enqueue(temp.Right);
            }
        }

        public Node<T> PeekTop()
        {
            return _root.Data;
        }

        public Node<T> RemoveTop()
        {
            Node<T> node = _root.Data;

            HeapifyDown();

            return node;
        }

        public void HeapifyDown()
        {
            throw new System.NotImplementedException();
        }

        public void HeapifyUp()
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }
    }
}
