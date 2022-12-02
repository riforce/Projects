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
        private int capacity;
        private int weight = 15;
        public Dictionary<string, Item> inventory;

        public static void Main(string[] args)
        {
            BagOfHolding bag = new BagOfHolding();
        }

        /// <summary>
        /// No-parameter constructor.
        /// </summary>
        public BagOfHolding()
        {
            capacity = 500;
            inventory = new Dictionary<string, Item>();
        }

        public void StoreItem(Item item)
        {
            inventory.Add(item.name, item);
            capacity -= item.weight;
            Console.Out.WriteLine(item.name + " stored.");
        }

        public int CheckCapacity()
        {
            return capacity;
        }

        public List<string> ListContents()
        {
            List<string> items = new List<string>();
            foreach(KeyValuePair<string, Item> pair in inventory) 
            {
                items.Add(pair.Key);
            }
            return items;
        }
    }
}