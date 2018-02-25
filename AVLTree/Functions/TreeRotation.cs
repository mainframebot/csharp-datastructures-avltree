using System;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeRotation<T> : ITreeRotation<T>
        where T : IComparable<T>
    {
        private readonly AvlTree<T> _tree;

        public TreeRotation(AvlTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public void RotateLeft(Node<T> oldRoot)
        {
            var newRoot = oldRoot.Right;

            oldRoot.Right = newRoot.Left;

            if (newRoot.Left != null)
                newRoot.Left.Parent = oldRoot;

            if (oldRoot.Right != null)
                oldRoot.Right.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Left = oldRoot;
        }

        public void RotateRight(Node<T> oldRoot)
        {
            var newRoot = oldRoot.Left;

            oldRoot.Left = newRoot.Right;

            if (oldRoot.Left != null)
                oldRoot.Left.Parent = oldRoot;

            if (oldRoot.Right != null)
                oldRoot.Right.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Right = oldRoot;
        }

        private void RotateParent(Node<T> oldRoot, Node<T> newRoot)
        {
            newRoot.Parent = oldRoot.Parent;

            if (oldRoot.Parent == null)
            {
                _tree.Root = newRoot;
            }
            else if (oldRoot == oldRoot.Parent.Left)
            {
                oldRoot.Parent.Left = newRoot;
            }
            else
            {
                oldRoot.Parent.Right = newRoot;
            }

            oldRoot.Parent = newRoot;
        }
    }
}
