using InventoryManager;

namespace InventoryTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StoreATrinket()
        {
            BagOfHolding bag = new BagOfHolding();
            String key = "a mummified goblin hand";
            InventoryItems.Trinket trinket = new InventoryItems.Trinket(key);
            bag.StoreItem(trinket);
            Assert.IsTrue(bag.inventory.ContainsKey(key));
        }

        [TestMethod]
        public void WeightOfTrinketIsZero()
        {
            BagOfHolding bag = new();
            String key = "some trinket";
            InventoryItems.Trinket t = new(key);
            bag.StoreItem(t);
            Assert.AreEqual(500, bag.CheckCapacity());

        }

        [TestMethod]
        public void ListInventoryTest()
        {
            BagOfHolding bag = new BagOfHolding();
            String key;
            for(int i = 0; i < 10; i++)
            {
                key = i.ToString() + "a";
                InventoryItems.Trinket t = new(key);
                bag.StoreItem(t);
            }

            List<string> list = bag.ListContents();
            Assert.AreEqual(10, list.Count);
            Assert.AreEqual("0a", list.First());
            Assert.AreEqual("9a", list.Last());
        }
    }
}