namespace InventoryManager
{
    public abstract class Item
    {
        protected bool equipped;
        protected bool destroyed;
        protected string type;
        protected string description;
        public double  weight;
        public double  value;
        public string name;
        public double cost;
        public bool magical;
      
       

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