using System;
using System.Collections.Generic;
using System.Linq;
using AVLTree.Enum;
using AVLTree.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class TreeBalancing : Base
    {
        [Test]
        public void Test_Balance_OpsFailure1()
        {
            int[] items = {195, 105, 319, 324, 170, 221, 157, 257, 278, 395, 273, 96, 240, 175, 124, 369, 225, 113, 247, 435};

            int[] delete = {257, 324, 240, 157, 278};

            var tree = new AvlTree<int>();

            List<int> insertPointsOfFailure = new List<int>();
            List<int> deletePointsOfFailure = new List<int>();

            foreach (var item in items)
            {
                tree.Insert(item);

                var node = tree.Search(170);

                if (node != null)
                {
                    if (node.State != TreeState.Balanced)
                    {
                        insertPointsOfFailure.Add(item);
                    }
                }
            }

            foreach (var item in delete)
            {
                if (item == 157)
                {
                    string oops = "";
                }

                var result = tree.Search(item);

                if (result != null)
                {
                    tree.Delete(result);

                    var node = tree.Search(170);

                    if (node != null)
                    {
                        if (node.State != TreeState.Balanced)
                        {
                            deletePointsOfFailure.Add(item);
                        }
                    }
                }
            }

            Assert.That(insertPointsOfFailure, Is.Empty);
            Assert.That(deletePointsOfFailure, Is.Empty);
        }

        [Test]
        public void Test_Balance_OpsFailure2()
        {
            int[] items = { 276,183,128,85,253,466,202,443,76,281,393,193,387,66,259,216,2,154,412,408,340,45,343,243,389,198,225,327 };

            int[] delete = { 393,340,443,183,85,193,276 };

            var tree = new AvlTree<int>();

            List<int> insertPointsOfFailure = new List<int>();
            List<int> deletePointsOfFailure = new List<int>();

            foreach (var item in items)
            {
                tree.Insert(item);

                var node = tree.Search(216);

                if (node != null)
                {
                    if (node.State != TreeState.Balanced)
                    {
                        insertPointsOfFailure.Add(item);
                    }
                }
            }

            foreach (var item in delete)
            {
                if (item == 85)
                {
                    string oops = "";
                }

                var result = tree.Search(item);

                if (result != null)
                {
                    tree.Delete(result);

                    var node = tree.Search(216);

                    if (node != null)
                    {
                        if (node.State != TreeState.Balanced)
                        {
                            deletePointsOfFailure.Add(item);
                        }
                    }
                }
            }

            Assert.That(insertPointsOfFailure, Is.Empty);
            Assert.That(deletePointsOfFailure, Is.Empty);
        }

        [Test]
        public void Test_Balance_OpsFailure3()
        {
            int[] items = { 298, 481, 80, 451, 125, 220, 229, 417, 169, 22, 446, 443, 380, 42, 354, 250, 175, 415, 230, 480, 428, 152, 134, 66, 61, 437, 323, 76, 136, 24 };

            int[] delete = { 415, 76, 125, 323, 417, 380, 42, 61, 22, 481, 437, 134, 80, 428, 354, 446, 169, 451 };

            var tree = new AvlTree<int>();

            List<int> insertPointsOfFailure = new List<int>();
            List<int> deletePointsOfFailure = new List<int>();

            foreach (var item in items)
            {
                tree.Insert(item);

                var node = tree.Search(200);

                if (node != null)
                {
                    if (node.State != TreeState.Balanced)
                    {
                        insertPointsOfFailure.Add(item);
                    }
                }
            }

            foreach (var item in delete)
            {
                if (item == 169)
                {
                    string oops = "";
                }

                var result = tree.Search(item);

                if (result != null)
                {
                    tree.Delete(result);

                    var node = tree.Search(220);

                    if (node != null)
                    {
                        if (node.State != TreeState.Balanced)
                        {
                            deletePointsOfFailure.Add(item);
                        }
                    }
                }
            }

            Assert.That(insertPointsOfFailure, Is.Empty);
            Assert.That(deletePointsOfFailure, Is.Empty);
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_With_BinarySearchTree_Properties()
        {
            for (int i = 0; i < 1000; i++)
            {
                List<Operations> operations = new List<Operations>();

                var tree = GenerateRandomTree(operations);

                TestingLoop(tree, operations);
            }
        }

        private void TestingLoop(AvlTree<int> tree, List<Operations> operations)
        {
            List<int> values = new List<int>();
            List<int> failure = new List<int>();

            values.Add(0);

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                var last = values.Last();

                if (last > x.Value)
                {
                    failure.Add(x.Value);
                }

                values.Add(x.Value);
            });

            var all = JsonConvert.SerializeObject(values);

            List<int> values2 = new List<int>();
            List<int> stateIssues = new List<int>();
            List<Node<int>> stateIssueNodes = new List<Node<int>>();

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                if (x.State != TreeState.Balanced)
                {
                    stateIssues.Add(x.Value);
                    stateIssueNodes.Add(x);

                    Assert.That(x.State, Is.EqualTo(TreeState.Balanced));
                }

                values2.Add(x.Value);
            });

            var ops = JsonConvert.SerializeObject(operations);
            var all2 = JsonConvert.SerializeObject(values2);

            //            if (stateIssues.Any())
            //            {
            //                string oops = "!";
            //            }

            Assert.That(stateIssues, Is.Empty);
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_With_Balanced_Nodes()
        {
            List<Operations> operations = new List<Operations>();

            var tree = GenerateRandomTree(operations);

            List<int> nodes = new List<int>();
            List<int> failure = new List<int>();
            List<Node<int>> failureNodes = new List<Node<int>>();

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                nodes.Add(x.Value);
                if (x.State != TreeState.Balanced)
                {
                    failure.Add(x.Value);
                    failureNodes.Add(x);
                }

                Assert.That(x.State, Is.EqualTo(TreeState.Balanced));
            });

            var ops = JsonConvert.SerializeObject(operations);
            var values = JsonConvert.SerializeObject(nodes);
        }

        private void TreeNodeInOrderTraversal(Node<int> node, Action<Node<int>> action)
        {
            if (node != null)
            {
                TreeNodeInOrderTraversal(node.Left, action);
                action(node);
                TreeNodeInOrderTraversal(node.Right, action);
            }
        }

    }
}
