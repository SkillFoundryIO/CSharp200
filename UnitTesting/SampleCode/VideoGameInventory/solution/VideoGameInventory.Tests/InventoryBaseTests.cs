using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Potions;
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

        [Test]
        public void RemoveItem_Success()
        {
            var chest = new Chest(2);
            var item = new HealthPotion();

            chest.AddItem(item);
            var removedItem = chest.RemoveItem(0);

            Assert.IsNotNull(removedItem);
            Assert.AreEqual(item, removedItem);
        }

        [Test]
        public void RemoveItem_BadIndex_ReturnsNull()
        {
            var chest = new Chest(2);
            var removedItem = chest.RemoveItem(-1);

            Assert.IsNull(removedItem);
        }

        [Test]
        public void RemoveItem_NoItemAtGivenIndex_ReturnsNull()
        {
            var chest = new Chest(2);
            var item = new Sword();

            chest.AddItem(item);
            var removedItem = chest.RemoveItem(1);

            Assert.IsNull(removedItem);
        }

        [Test]
        public void RemoveItem_RemovedItemHasNullElement()
        {
            var chest = new Chest(2);
            var item = new HealthPotion();

            chest.AddItem(item);
            var removedItem = chest.RemoveItem(0);

            Assert.IsNotNull(removedItem);
            Assert.IsNull(chest.RemoveItem(0));
        }
    }
}