using System;
using AVLTree.Enum;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeBalancing<T> : ITreeBalancing<T>
        where T : IComparable<T>
    {
        private readonly ITreeRotation<T> _treeRotation;

        public TreeBalancing(ITreeRotation<T> treeRotation)
        {
            _treeRotation = treeRotation;
        }  

        public void FixUp(Node<T> node)
        {
            switch (node.State)
            {
                case TreeState.LeftHeavy:
                    if (node.Left.BalancingFactor > 0)
                    {
                        _treeRotation.RotateLeft(node.Left);
                        _treeRotation.RotateRight(node);
                    }
                    else
                    {
                        _treeRotation.RotateRight(node);
                    }
                    break;
                case TreeState.RightHeavy:
                    if (node.Right.BalancingFactor < 0)
                    {
                        _treeRotation.RotateRight(node.Right);
                        _treeRotation.RotateLeft(node);
                    }
                    else
                    {
                        _treeRotation.RotateLeft(node);
                    }
                    break;       
            }
        }
    }
}
