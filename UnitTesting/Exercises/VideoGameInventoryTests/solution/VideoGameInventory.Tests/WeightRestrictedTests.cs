using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Potions;
using VideoGameInventory.UI.Items.Weapons;

namespace VideoGameInventory.Tests
{
    [TestFixture]
    public class WeightRestrictedTests
    {
        [Test]
        public void AddItem_Overweight_Fails()
        {
            var inventory = new WeightRestrictedInventory(2, 12);
            var item = new Helm(); // Weight: 10

            var result = inventory.AddItem(item);
            Assert.AreEqual(AddResult.Success, result);

            var overweightItem = new Sword(); // Weight: 10
            var overweightResult = inventory.AddItem(overweightItem);

            Assert.AreEqual(AddResult.Overweight, overweightResult);
        }

        [Test]
        public void AddItem_CheckWeightCalculation_Success()
        {
            var inventory = new WeightRestrictedInventory(3, 20);
            var item1 = new Sword(); // Weight: 10
            var item2 = new HealthPotion(); // Weight: 1

            var result1 = inventory.AddItem(item1);
            Assert.AreEqual(AddResult.Success, result1);
            Assert.AreEqual(10, inventory.CurrentWeight);

            var result2 = inventory.AddItem(item2);
            Assert.AreEqual(AddResult.Success, result2);
            Assert.AreEqual(11, inventory.CurrentWeight);
        }

        [Test]
        public void RemoveItem_CheckWeightCalculation_Success()
        {
            var inventory = new WeightRestrictedInventory(3, 20);
            var item1 = new Sword(); // Weight: 10
            var item2 = new HealthPotion(); // Weight: 1

            inventory.AddItem(item1);
            inventory.AddItem(item2);

            var removedItem1 = inventory.RemoveItem(0);
            Assert.AreEqual(item1, removedItem1);
            Assert.AreEqual(1, inventory.CurrentWeight);

            var removedItem2 = inventory.RemoveItem(1);
            Assert.AreEqual(item2, removedItem2);
            Assert.AreEqual(0, inventory.CurrentWeight);
        }

        [Test]
        public void AddItem_FailedAdd_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(1, 20);
            var item1 = new Sword(); // Weight: 10

            inventory.AddItem(item1);
            var result2 = inventory.AddItem(item1); // This should fail due to capacity
            Assert.AreEqual(AddResult.ContainerFull, result2);
            Assert.AreEqual(10, inventory.CurrentWeight);
        }

        [Test]
        public void RemoveItem_FailedRemove_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(2, 20);
            var item1 = new Sword(); // Weight: 10

            inventory.AddItem(item1);
            var removedItem2 = inventory.RemoveItem(1); // This should fail due to no item at the given index
            Assert.IsNull(removedItem2);
            Assert.AreEqual(10, inventory.CurrentWeight);
        }
    }
}
