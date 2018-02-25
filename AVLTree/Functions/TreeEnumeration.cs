using System;
using System.Collections.Generic;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree.Functions
{
    public class TreeEnumeration<T> : ITreeEnumeration<T>
        where T : IComparable<T>
    {
        private readonly AvlTree<T> _tree;

        public TreeEnumeration(AvlTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_tree.Root != null)
            {
                var stack = new Stack<Node<T>>();

                var goLeft = true;

                var current = _tree.Root;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right == null)
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }
                    else
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                }
            }
        }
    }
}
