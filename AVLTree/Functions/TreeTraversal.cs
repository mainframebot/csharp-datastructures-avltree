using System;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeTraversal<T> : ITreeTraversal<T>
        where T : IComparable<T>
    {
        public void InOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, action);
                action(node.Value);
                InOrderTraversal(node.Right, action);
            }
        }

        public void PostOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left, action);
                PostOrderTraversal(node.Right, action);
                action(node.Value);
            }
        }

        public void PreOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(node.Left, action);
                PreOrderTraversal(node.Right, action);
            }
        }
    }
}
