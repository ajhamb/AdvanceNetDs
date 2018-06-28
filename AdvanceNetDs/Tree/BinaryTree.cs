using System;
using AdvanceNetDs.Shared;

namespace AdvanceNetDs.Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Data { get; set; }

        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public BinaryTree(Node<T> data)
        {
            Data = data;
        }
    }
}
