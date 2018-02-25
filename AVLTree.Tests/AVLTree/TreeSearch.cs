using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class TreeSearch : Base
    {
        [Test]
        public void Contains_Should_Succeed_Locating_Node()
        {
            var tree = AvlTree;

            Assert.That(tree.Contains(ItemsSearchSucceeds), Is.True);
        }

        [Test]
        public void Contains_Should_Fail_Locating_Node()
        {
            var tree = AvlTree;

            Assert.That(tree.Contains(ItemsSearchFails), Is.False);
        }

        [Test]
        public void Search_Should_Succeed_Locating_Node()
        {
            var tree = AvlTree;

            Assert.That(tree.Search(ItemsSearchSucceeds).Value, Is.EqualTo(ItemsSearchSucceeds));
        }

        [Test]
        public void Search_Should_Fail_Locating_Node()
        {
            var tree = AvlTree;

            Assert.That(tree.Search(ItemsSearchFails), Is.Null);
        }

        [Test]
        public void Minimum_Should_Return_Correct_Value()
        {
            var tree = AvlTree;

            Assert.That(tree.Minimum(tree.Root).Value, Is.EqualTo(ItemsSearchMinimum));
        }

        [Test]
        public void Maximum_Should_Return_Correct_Value()
        {
            var tree = AvlTree;

            Assert.That(tree.Maximum(tree.Root).Value, Is.EqualTo(ItemsSearchMaximum));
        }

        [Test]
        public void Successor_Should_Succeed_Locating_Node()
        {
            var tree = AvlTree;

            var result = tree.Search(ItemsSearchSuccessorSucceeds[0]);

            Assert.That(tree.Successor(result).Value, Is.EqualTo(ItemsSearchSuccessorSucceeds[1]));
        }

        [Test]
        public void Successor_Should_Fail_Locating_Node()
        {
            var tree = AvlTree;

            var result = tree.Search(ItemsSearchSuccessorFails);

            Assert.That(tree.Successor(result), Is.Null);
        }

        [Test]
        public void Predecessor_Should_Succeed_Locating_Node()
        {
            var tree = AvlTree;

            var result = tree.Search(ItemsSearchPredecessorSucceeds[0]);

            Assert.That(tree.Predecessor(result).Value, Is.EqualTo(ItemsSearchPredecessorSucceeds[1]));
        }

        [Test]
        public void Predecessor_Should_Fail_Locating_Node()
        {
            var tree = AvlTree;

            var result = tree.Search(ItemsSearchPredecessorFails);

            Assert.That(tree.Predecessor(result), Is.Null);
        }
    }
}
