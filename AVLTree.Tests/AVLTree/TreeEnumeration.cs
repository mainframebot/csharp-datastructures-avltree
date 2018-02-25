using NUnit.Framework;

namespace AVLTree.Tests.AVLTree
{
    [TestFixture]
    public class TreeEnumeration : Base
    {
        [Test]
        public void Enumeration_Should_TraverseTree_InOrder()
        {
            int index = 0;

            foreach (var item in AvlTree)
            {
                Assert.That(ItemsInOrder[index++], Is.EqualTo(item));
            }
        }
    }
}
