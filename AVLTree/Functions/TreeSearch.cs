using System;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeSearch<T> : ITreeSearch<T>
        where T : IComparable<T>
    {
        public bool Contains(Node<T> node, T value)
        {
            return SearchNode(node, value) != null;
        }

        public Node<T> Search(Node<T> node, T value)
        {
            return SearchNode(node, value);
        }

        public Node<T> Minimum(Node<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public Node<T> Maximum(Node<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        public Node<T> Successor(Node<T> node)
        {
            if (node.Right != null)
                return Minimum(node.Right);

            var current = node.Parent;
            while (current != null && node == current.Right)
            {
                node = current;
                current = current.Parent;
            }

            return current;
        }

        public Node<T> Predecessor(Node<T> node)
        {
            if (node.Left != null)
                return Maximum(node.Left);

            var current = node.Parent;
            while (current != null && node == current.Left)
            {
                node = current;
                current = current.Parent;
            }

            return current;
        }

        private Node<T> SearchNode(Node<T> current, T value)
        {
            if (current == null || value.Equals(current.Value))
                return current;

            if (value.CompareTo(current.Value) < 0)
            {
                return SearchNode(current.Left, value);
            }

            return SearchNode(current.Right, value);
        }
    }
}
