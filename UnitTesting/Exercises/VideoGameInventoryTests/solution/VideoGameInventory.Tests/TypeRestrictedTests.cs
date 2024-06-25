using NUnit.Framework;
using VideoGameInventory.UI.Containers;
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

            Assert.That(AddResult.Success, Is.EqualTo(result));
        }

        [Test]
        public void AddItem_WrongType()
        {
            var bandoleer = new PotionBandoleer();
            var item = new Sword();

            var result = bandoleer.AddItem(item);

            Assert.That(AddResult.WrongType, Is.EqualTo(result));
        }

        [Test]
        public void AddAndRemove_Success()
        {
            var bandoleer = new PotionBandoleer();
            var item = new HealthPotion();

            var addResult = bandoleer.AddItem(item);
            var removedItem = bandoleer.RemoveItem(0);

            Assert.That(AddResult.Success, Is.EqualTo(addResult));
            Assert.That(removedItem, Is.Not.Null);
            Assert.That(item, Is.EqualTo(removedItem));
        }
    }
}