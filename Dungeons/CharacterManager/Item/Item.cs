namespace InventoryManager
{
    public abstract class Item
    {
        protected bool equipped;
        protected bool destroyed;
        protected string type;
        protected string description;
        public string name
        {
            get => name; 
            private set { name = value; }
       }
public int weight 
        {
            get => weight; 
            private set { weight = value; } 
        }
   
        protected  Item(string name, int weight)
        {
            equipped = true;
            destroyed= false;
            type = "";
            description = "";
            this.name= name;
            this.weight = weight;
        }

        protected abstract void SetDescription(string d);

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
        protected void Equip()
        {
            equipped = true;
        }

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