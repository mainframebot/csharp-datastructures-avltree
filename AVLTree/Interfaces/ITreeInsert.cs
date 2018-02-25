using System;
using AVLTree.Models;

namespace AVLTree.Interfaces
{
    public interface ITreeInsert<T>
        where T : IComparable<T>
    {
        Node<T> Insert(Node<T> node);
    }
}
