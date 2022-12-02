using InventoryManager;

namespace InventoryTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GemWeightZero()
        {
            Item gem = new InventoryItems.Gemstone("ruby", 50);
            Assert.AreEqual(0, gem.weight);
        }
    }
}