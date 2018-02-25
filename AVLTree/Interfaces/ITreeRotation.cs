using System;
using AVLTree.Models;

namespace AVLTree.Interfaces
{
    public interface ITreeRotation<T>
        where T : IComparable<T>
    {
        void RotateLeft(Node<T> oldRoot);

        void RotateRight(Node<T> oldRoot);
    }
}
