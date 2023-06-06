using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Weapons;

namespace VideoGameInventory.Tests
{
    [TestFixture]
    public class InventoryBaseTests
    {
        [Test]
        public void AddItem_Success()
        {
            var chest = new Chest(2);
            var item = new Sword();

            var result = chest.AddItem(item);

            Assert.AreEqual(AddResult.Success, result);
        }

        [Test]
        public void AddItem_ContainerFull()
        {
            var chest = new Chest(1);
            var item1 = new Sword();
            var item2 = new Helm();

            chest.AddItem(item1);
            var result = chest.AddItem(item2);

            Assert.AreEqual(AddResult.ContainerFull, result);
        }
    }
}