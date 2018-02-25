using System;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeInsert<T> : ITreeInsert<T>
        where T : IComparable<T>
    {
        private readonly AvlTree<T> _tree;
        private readonly ITreeBalancing<T> _treeBalancing;

        public TreeInsert(AvlTree<T> tree, ITreeBalancing<T> treeBalancing)
        {
            if (tree == null || treeBalancing == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeBalancing = treeBalancing;
        }

        public Node<T> Insert(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (_tree.Root == null)
            {
                _tree.Root = node;
            }
            else
            {
                InsertNode(_tree.Root, node);
            }

            _tree.Count++;

            return node;
        }

        private void InsertNode(Node<T> current, Node<T> node)
        {
            node.Parent = current;

            if (node.Value.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                { 
                    current.Left = node;
                }
                else
                {
                    InsertNode(current.Left, node);
                }

            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = node;
                }
                else
                {
                    InsertNode(current.Right, node);
                }
            }
            _treeBalancing.FixUp(current);
        }
    }
}
