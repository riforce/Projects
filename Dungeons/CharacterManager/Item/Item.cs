namespace InventoryManager
{
    public abstract class Item
    {
        protected bool equipped;
        protected bool destroyed;
        protected string type;
        protected string description;
        public int weight;
        public int value;
        public string name
        {
            get => name; 
            private set { name = value; }
        }
       

        protected  Item(string name)
        {
            equipped = true;
            destroyed= false;
            type = "no type yet";
            description = "no description yet";
            this.name= name;
        }

        protected void SetDescription(string d)
        {
            description = d;
        }

        /// <summary>
        /// Unequips the item.
        /// </summary>
        protected void Unequip()
        {
            equipped = false;
        }

        /// <summary>
        /// Equips the item.
        /// </summary>
        protected abstract void Equip();

        /// <summary>
        /// Destroys the item.
        /// </summary>
        protected void Destroy()
        {
            equipped = false;
            destroyed= true;
        }

    

     
    }
}