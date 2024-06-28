using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Potions;
using VideoGameInventory.UI.Items.Weapons;

namespace VideoGameInventory.Tests
{
    
    [TestFixture]
    public class TypeRestrictedInventoryTests
    {
        [Test]
        public void AddItem_WrongType()
        {
            var potionBand = new PotionBandoleer();

            var item1 = new Sword();

            var result = potionBand.AddItem(item1);

            Assert.AreEqual(AddResult.WrongType, result);
        }

        [Test]
        public void AddItem_CorrectType()
        {
            var potionBand = new PotionBandoleer();

            var item1 = new HealthPotion();

            var result = potionBand.AddItem(item1);

            Assert.AreEqual(AddResult.Success, result);
        }

        [Test]
        public void RetrieveItem_RemovalSuccess()
        {
            var potionBand = new PotionBandoleer();

            var item1 = new HealthPotion();

            potionBand.AddItem(item1);

            var result = potionBand.RemoveItem(0);

            Assert.AreEqual(item1, result);
        }
    }
    
}
