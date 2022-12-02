///
/// Inventory manager.
///
namespace InventoryManager
{
    /// <summary>
    /// Represents a Bag of Holding.
    /// </summary>
    public class BagOfHolding
    {
        // fields
        private static int Capacity;
        private int weight = 15;
        public Dictionary<string, Item> inventory;

        /// <summary>
        /// No-parameter constructor.
        /// </summary>
        public BagOfHolding()
        {
            Capacity = 500;
            inventory= new Dictionary<string, Item>();
        }
       
        public void StoreItem(Item item)
        {
            inventory.Add(item.name, item);
            Capacity -= item.weight;
        }
    }
}