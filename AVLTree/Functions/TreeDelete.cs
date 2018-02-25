using System;
using AVLTree.Enum;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeDelete<T> : ITreeDelete<T>
        where T : IComparable<T>
    {
        private readonly AvlTree<T> _tree;
        private readonly ITreeSearch<T> _treeSearch;
        private readonly ITreeBalancing<T> _treeBalancing;

        public TreeDelete(AvlTree<T> tree, ITreeSearch<T> treeSearch, ITreeBalancing<T> treeBalancing)
        {
            if (tree == null || treeSearch == null || treeBalancing == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeSearch = treeSearch;
            _treeBalancing = treeBalancing;
        }

        public bool Delete(Node<T> node)
        {
            var current = node.Parent;

            if (node.Left == null)
            {
                Transplant(node, node.Right);
            }
            else if (node.Right == null)
            {
                Transplant(node, node.Left);
            }
            else
            {
                var leftmostNode = _treeSearch.Minimum(node.Right);

                current = leftmostNode.Parent;

                if (leftmostNode.Parent != node)
                {
                    Transplant(leftmostNode, leftmostNode.Right);
                    leftmostNode.Right = node.Right;
                    leftmostNode.Right.Parent = leftmostNode;
                }
                else
                {
                    current = node.Right;
                }

                Transplant(node, leftmostNode);
                leftmostNode.Left = node.Left;
                leftmostNode.Left.Parent = leftmostNode;          
            }

            _tree.Count--;

            while (current != null)
            {
                if (current.State != TreeState.Balanced)
                {
                    _treeBalancing.FixUp(current);
                }

                current = current.Parent;
            }

            return true;
        }

        private void Transplant(Node<T> deletedNode, Node<T> replacementNode)
        {
            if (deletedNode.Parent == null)
            {
                _tree.Root = replacementNode;
            }
            else if (deletedNode == deletedNode.Parent.Left)
            {
                deletedNode.Parent.Left = replacementNode;
            }
            else
            {
                deletedNode.Parent.Right = replacementNode;
            }

            if (replacementNode != null)
            {
                replacementNode.Parent = deletedNode.Parent;
            }
        }
    }
}
