using System;
using AVLTree.Models;

namespace AVLTree.Interfaces
{
    public interface ITreeSearch<T>
        where T : IComparable<T>
    {
        bool Contains(Node<T> node, T value);

        Node<T> Search(Node<T> node, T value);

        Node<T> Minimum(Node<T> node);

        Node<T> Maximum(Node<T> node);

        Node<T> Successor(Node<T> node);

        Node<T> Predecessor(Node<T> node);
    }
}
