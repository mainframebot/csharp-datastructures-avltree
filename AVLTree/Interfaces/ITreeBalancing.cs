using System;
using AVLTree.Models;

namespace AVLTree.Interfaces
{
    public interface ITreeBalancing<T>
        where T : IComparable<T>
    {
        void FixUp(Node<T> node);
    }
}
