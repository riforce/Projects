namespace InventoryManager
{
    public class InventoryItems
    {
        private static Dictionary<string, Gemstone> gems;
        private static Dictionary<string, Trinket> trinkets;

        public InventoryItems()
        {
            gems = new Dictionary<string, Gemstone>();
            trinkets = new Dictionary<string, Trinket>();
        }

        /// <summary>
        /// Gemstone class.
        /// </summary>
        public class Gemstone : Item
        {
            public Gemstone(string name, int value) : base(name)
            {
                this.value = value;
                this.type = "gem";
                this.weight = 0;
            }

            public int UseGem()
            {
                Destroy();
                return value;
            }

            protected override void Equip()
            {
                gems.Add(this.name, this);
            }
        }

        public class Trinket : Item
        {
            public Trinket(string name) : base(name) 
            {
                this.weight = 0;
                this.value = 0;
                this.type = "trinket";
            }

            protected override void Equip()
            {
                trinkets.Add(this.name, this);
            }
        }
    }
}