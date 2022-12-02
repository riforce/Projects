namespace InventoryManager
{
    public class InventoryItems
    {
        private Dictionary<string, Gemstone> gems;

        public InventoryItems()
        {
            gems = new Dictionary<string, Gemstone>();
        }

        public class Gemstone : Item
        {
            protected int value;
            protected Gemstone(string name, int value, int weight) : base(name, weight)
            {
                this.value = value;
                this.type = "gem";
            }

            protected override void SetDescription(string description)
            {
                this.description = description;
            }

        }

    }
}