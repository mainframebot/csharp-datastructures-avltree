using System;
using AVLTree.Enum;

namespace AVLTree.Models
{
    public class Node<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get ; set; }

        public Node<T> Right { get; set; }

        public Node<T> Parent { get; set; }

        public int LeftHeight { get { return MaxChildHeight(Left); } }

        public int RightHeight { get { return MaxChildHeight(Right); } }

        public int BalancingFactor { get { return RightHeight - LeftHeight; } }

        public TreeState State { get { return DetermineTreeState(); } }

        public Node(T value)
        {
            Value = value;
        }

        private int MaxChildHeight(Node<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }

            return 0;
        }

        private TreeState DetermineTreeState()
        {
            if (LeftHeight - RightHeight > 1)
            {
                return TreeState.LeftHeavy;
            }

            if (RightHeight - LeftHeight > 1)
            {
                return TreeState.RightHeavy;
            }

            return TreeState.Balanced;
        }
    }
}
