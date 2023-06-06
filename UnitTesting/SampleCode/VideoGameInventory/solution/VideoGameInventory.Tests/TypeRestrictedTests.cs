using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Potions;
using VideoGameInventory.UI.Items.Weapons;

namespace VideoGameInventory.Tests
{
    [TestFixture]
    public class TypeRestrictedTests
    {
        [Test]
        public void AddItem_Success()
        {
            var bandoleer = new PotionBandoleer();
            var item = new HealthPotion();

            var result = bandoleer.AddItem(item);

            Assert.AreEqual(AddResult.Success, result);
        }

        [Test]
        public void AddItem_WrongType()
        {
            var bandoleer = new PotionBandoleer();
            var item = new Sword();

            var result = bandoleer.AddItem(item);

            Assert.AreEqual(AddResult.WrongType, result);
        }

        [Test]
        public void AddAndRemove_Success()
        {
            var bandoleer = new PotionBandoleer();
            var item = new HealthPotion();

            var addResult = bandoleer.AddItem(item);
            var removedItem = bandoleer.RemoveItem(0);

            Assert.AreEqual(AddResult.Success, addResult);
            Assert.IsNotNull(removedItem);
            Assert.AreEqual(item, removedItem);
        }
    }
}