using System;
using System.Collections;
using System.Collections.Generic;
using AVLTree.Enum;
using AVLTree.Functions;
using AVLTree.Interfaces;
using AVLTree.Models;

namespace AVLTree
{
    public class AvlTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public Node<T> Root { get; set; } 

        public int Count { get; set; }

        private readonly ITreeEnumeration<T> _treeEnumeration;

        private readonly ITreeTraversal<T> _treeTraversal;

        private readonly ITreeSearch<T> _treeSearch;

        private readonly ITreeInsert<T> _treeInsert;

        private readonly ITreeDelete<T> _treeDelete;

        private readonly ITreeRotation<T> _treeRotation;

        private readonly ITreeBalancing<T> _treeBalancing; 

        public AvlTree()
        {
            _treeEnumeration = new TreeEnumeration<T>(this);
            _treeTraversal = new TreeTraversal<T>();
            _treeSearch = new TreeSearch<T>();
            _treeRotation = new TreeRotation<T>(this);
            _treeBalancing = new TreeBalancing<T>(_treeRotation);
            _treeInsert = new TreeInsert<T>(this, _treeBalancing);
            _treeDelete = new TreeDelete<T>(this, _treeSearch, _treeBalancing);
        }

        public AvlTree(
            ITreeEnumeration<T> treeEnumeration, 
            ITreeTraversal<T> treeTraversal, 
            ITreeSearch<T> treeSearch, 
            ITreeInsert<T> treeInsert, 
            ITreeDelete<T> treeDelete, 
            ITreeRotation<T> treeRotation, 
            ITreeBalancing<T> treeBalancing)
        {
            _treeEnumeration = treeEnumeration;
            _treeTraversal = treeTraversal;
            _treeSearch = treeSearch;
            _treeInsert = treeInsert;
            _treeDelete = treeDelete;
            _treeRotation = treeRotation;
            _treeBalancing = treeBalancing;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _treeEnumeration.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public Node<T> Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            return _treeInsert.Insert(new Node<T>(value));
        }

        public bool Delete(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            return _treeDelete.Delete(node);
        }

        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            return _treeSearch.Contains(Root, value);
        }

        public Node<T> Search(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            return _treeSearch.Search(Root, value);
        }

        public Node<T> Minimum(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            return _treeSearch.Minimum(node);
        }

        public Node<T> Maximum(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            return _treeSearch.Maximum(node);
        }

        public Node<T> Successor(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            return _treeSearch.Successor(node);
        }

        public Node<T> Predecessor(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            return _treeSearch.Predecessor(node);
        }

        public void PreOrderTraversal(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException();

            _treeTraversal.PreOrderTraversal(Root, action);
        }

        public void InOrderTraversal(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException();

            _treeTraversal.InOrderTraversal(Root, action);
        }

        public void PostOrderTraversal(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException();

            _treeTraversal.PostOrderTraversal(Root, action);
        }
    }
}
