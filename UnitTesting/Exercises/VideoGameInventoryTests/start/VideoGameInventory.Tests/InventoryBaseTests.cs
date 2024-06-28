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
            var chest = new Chest(1);
            var item1 = new Sword();

            chest.AddItem(item1);

            var result1 = chest.RemoveItem(0);

            Assert.IsNotNull(result1);
            Assert.AreEqual(item1, result1);
        }

        [Test]
        public void RemoveItem_IndexOutOfRange()
        {
            var chest = new Chest(3);
            var item1 = new Sword();
            var item2 = new Helm();
            var item3 = new HealthPotion();

            chest.AddItem(item1);
            chest.AddItem(item2);
            chest.AddItem(item3);

            // capacity for chest is 3, index 3 points to a 4th item.
            var result = chest.RemoveItem(3);

            Assert.IsNull(result);
        }

        [Test]
        public void RemoveItem_NoItemAtIndex()
        {
            var chest = new Chest(4);
            var item1 = new Sword();
            var item2 = new Helm();
            var item3 = new HealthPotion();

            chest.AddItem(item1);
            chest.AddItem(item2);
            chest.AddItem(item3);
            // remove item at index 3
            var result = chest.RemoveItem(3);

            Assert.IsNull(result);

        }

        [Test] 
        public void RemoveItem_SuccessAndNoItemAtIndex()
        {
            var chest = new Chest(3);
            var item1 = new Sword();
            var item2 = new Helm();
            var item3 = new HealthPotion();

            chest.AddItem(item1);
            chest.AddItem(item2);
            chest.AddItem(item3);

            // remove the last item at index 2: return removed item
            // this assertion is redundant :)
            var result1 = chest.RemoveItem(2);
            Assert.AreEqual(item3, result1);
            // remove item at index 2 again: return null
            var result2 = chest.RemoveItem(2);
            Assert.IsNull(result2);

        }
    }

}