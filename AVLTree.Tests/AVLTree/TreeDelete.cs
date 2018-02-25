using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class TreeDelete : Base
    {
        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase1A()
        {
            var tree = AvlTreeDeleteFixUpCase1AItems;

            var node = tree.Search(DeleteFixUpCase1AItem);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(40));

            // Root.Left

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(20));

            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(35));

            // Root.Right

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(50));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(80));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase1AItems.Length - 1));
        }

        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase1B()
        {
            var tree = AvlTreeDeleteFixUpCase1BItems;

            var node = tree.Search(DeleteFixUpCase1BItem);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(20));

            // Root.Left

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(10));

            // Root.Left.Left

            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(5));

            // Root.Right

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(50));

            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(80));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase1BItems.Length - 1));
        }

        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase2A()
        {
            var tree = AvlTreeDeleteFixUpCase2AItems;

            var node = tree.Search(DeleteFixUpCase2AItem);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(70));

            // Root.Left

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(50));

            // Root.Left.Left

            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(20));

            // Root.Right

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(80));

            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(75));

            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(90));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase2AItems.Length - 1));
        }

        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase2B()
        {
            var tree = AvlTreeDeleteFixUpCase2BItems;

            var node = tree.Search(DeleteFixUpCase2BItem);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Parent, Is.Null);
            Assert.That(tree.Root.Value, Is.EqualTo(80));

            // Root.Left

            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(50));

            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(20));

            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(70));

            // Root.Right

            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(90));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(95));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase2BItems.Length - 1));
        }
    }
}
