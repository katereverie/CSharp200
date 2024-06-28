using NUnit.Framework;
using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Potions;
using VideoGameInventory.UI.Items.Weapons;

namespace VideoGameInventory.Tests
{
    [TestFixture]
    public class WeightRestrictedInventoryTests
    {
        [Test]
        public void AddItem_Overweight()
        {
            var inventory = new WeightRestrictedInventory(2, 12);

            var item1 = new Sword();
            var item2 = new Sword();

            var result = inventory.AddItem(item1);
            Assert.AreEqual(AddResult.Success, result);

            var overweightResult = inventory.AddItem(item2);
            Assert.AreEqual(AddResult.Overweight, overweightResult);

        }

        [Test]
        public void AddRemoveItem_CorrectWeightCalculation()
        {
            var inventory = new WeightRestrictedInventory(3, 20);
            Assert.AreEqual(0, inventory.CurrentWeight);

            var potion1 = new HealthPotion(); // 1kg
            var sword1 = new Sword(); // 10kg
            var helm1 = new Helm(); // 10kg

            inventory.AddItem(potion1);
            Assert.AreEqual(1.0, inventory.CurrentWeight);

            inventory.AddItem(sword1);
            Assert.AreEqual(11.0, inventory.CurrentWeight);

            var overWeightresult = inventory.AddItem(helm1);
            Assert.AreEqual(AddResult.Overweight, overWeightresult);
            Assert.AreEqual(11.0, inventory.CurrentWeight);

            var removedItem = inventory.RemoveItem(0);
            Assert.AreEqual(10.0, inventory.CurrentWeight);

            inventory.RemoveItem(1);
            Assert.AreEqual(0, inventory.CurrentWeight);

            var result2 = inventory.RemoveItem(1);
            Assert.IsNull(result2);
        }
        [Test]
        public void AddItem_FailedAdd_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(1, 20);
            var item1 = new Sword(); // 10kg

            inventory.AddItem(item1);
            var result2 = inventory.AddItem(item1); // should fail due to capacity
            Assert.AreEqual(AddResult.ContainerFull, result2);
            Assert.AreEqual(10, inventory.CurrentWeight);
        }

        [Test]
        public void RemoveItem_FailedRemoved_DoesNotImpactCurrentWeight()
        {
            var inventory = new WeightRestrictedInventory(2, 20);
            var item1 = new Sword(); // 10kg

            var removedItem = inventory.RemoveItem(0); // should be null
            Assert.IsNull(removedItem);
            Assert.AreEqual(0, inventory.CurrentWeight); // should be 0;
        }
    }
}
