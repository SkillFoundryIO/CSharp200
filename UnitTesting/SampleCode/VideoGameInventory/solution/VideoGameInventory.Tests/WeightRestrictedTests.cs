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

            Assert.That(result, Is.EqualTo(AddResult.Success));
            
            var overweightItem = new Sword(); // Weight: 10
            var overweightResult = inventory.AddItem(overweightItem);
            
            Assert.That(overweightResult, Is.EqualTo(AddResult.Overweight));
        }

        [Test]
        public void AddItem_CheckWeightCalculation_Success()
        {
            var inventory = new WeightRestrictedInventory(3, 20);
            var item1 = new Sword(); // Weight: 10
            var item2 = new HealthPotion(); // Weight: 1
            
            var result1 = inventory.AddItem(item1);
            
            Assert.That(result1, Is.EqualTo(AddResult.Success));
            Assert.That(inventory.CurrentWeight, Is.EqualTo(10));
            
            var result2 = inventory.AddItem(item2);
            
            Assert.That(result2, Is.EqualTo(AddResult.Success));
            Assert.That(inventory.CurrentWeight, Is.EqualTo(11));
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
            
            Assert.That(removedItem1, Is.EqualTo(item1));
            Assert.That(inventory.CurrentWeight, Is.EqualTo(1));
            
            var removedItem2 = inventory.RemoveItem(1);
            
            Assert.That(removedItem2, Is.EqualTo(item2));
            Assert.That(inventory.CurrentWeight, Is.EqualTo(0));
        }

        [Test]
        public void AddItem_FailedAdd_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(1, 20);
            var item1 = new Sword(); // Weight: 10
            
            inventory.AddItem(item1);
            
            var result2 = inventory.AddItem(item1); // This should fail due to capacity
            
            Assert.That(result2, Is.EqualTo(AddResult.ContainerFull));
            Assert.That(inventory.CurrentWeight, Is.EqualTo(10));
        }

        [Test]
        public void RemoveItem_FailedRemove_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(2, 20);
            var item1 = new Sword(); // Weight: 10
            
            inventory.AddItem(item1);
            
            var removedItem2 = inventory.RemoveItem(1); // This should fail due to no item at the given index
            
            Assert.That(removedItem2, Is.Null);
            Assert.That(inventory.CurrentWeight, Is.EqualTo(10));
        }
    }
}
