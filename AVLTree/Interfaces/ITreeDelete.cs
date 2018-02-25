using System;
using AVLTree.Models;

namespace AVLTree.Interfaces
{
    public interface ITreeDelete<T>
        where T : IComparable<T>
    {
        bool Delete(Node<T> node);
    }
}
