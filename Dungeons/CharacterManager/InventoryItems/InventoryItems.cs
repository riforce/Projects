using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace InventoryManager
{
    public class InventoryItems
    {
        private static Dictionary<string, Gemstone>? gems;
        private static Dictionary<string, Trinket>? trinkets;
        private static Dictionary<string, Clothes>? clothes;
        private static Dictionary<string, Container>? containers;
        private static Dictionary<string, Focus>? foci;

        public InventoryItems()
        {
            gems = new Dictionary<string, Gemstone>();
            trinkets = new Dictionary<string, Trinket>();
            clothes = new Dictionary<string, Clothes>();
            containers = new Dictionary<string, Container>();
            foci = new Dictionary<string, Focus> { };
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
                this.magical = false;

            }

            public double UseGem()
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
                this.magical = false;
            }

            protected override void Equip()
            {
                trinkets.Add(this.name, this);
            }
        }

        public class Clothes : Item
        {
            //may include stat boosts here too

            public Clothes(string name) : base(name)
            {
                this.magical = false;
                this.type = "clothes";

                if (name == "common clothes")
                {
                    this.weight = 3;
                    this.cost = 0.5;
                    this.value = 0.5;
                    this.description = "";
                }
                else if (name == "costume")
                {
                    this.weight = 4;
                    this.cost = 5;
                    this.value = 5;
                    this.description = "";

                }
                else if (name == "fine clothes")
                {
                    this.weight = 6;
                    this.cost = 15;
                    this.value = 15;
                    this.description = "";

                }
                else if (name == "robes")
                {
                    this.weight = 4;
                    this.cost = 1;
                    this.value = 1;
                    this.description = "";

                }
                else if (name == "travelers clothes")
                {
                    this.weight = 4;
                    this.cost = 2;
                    this.value = 2;
                    this.description = "";

                }
            }

            protected override void Equip()
            {
                clothes.Add(this.name, this);
            }
        }

        public class Container : Item
        {
            public int capacity; //might want to further split this by volume and weight, or number (quiver:number of arrows)
            private double contentsValue;
            private double contentsWeight;
            private double emptyWeight;
            public Dictionary<string, Item> contents;

            public Container(String name, int capacity) : base(name)
            {
                this.capacity = capacity;
                this.magical = false;
                contents = new Dictionary<string, Item>();
                this.contentsValue = 0;
                this.contentsWeight = 0;
                this.value = cost + contentsValue;
                this.weight = emptyWeight + contentsWeight;
                this.type = "container";

                if (name == "backpack")
                {
                    this.cost = 2;
                    this.emptyWeight = 5;
                    this.description = "You can also strap items, such as a bedroll or " +
                        "a coil of rope, to the outside of a backpack.";
                }
                else if (name == "barrel")
                {
                    this.cost = 2;
                    this.emptyWeight = 70;
                    this.description = "";
                }
                else if (name == "basket")
                {
                    this.cost = .4;
                    this.emptyWeight = 2;
                    this.description = "";
                }
                else if (name == "bucket")
                {
                    this.cost = .005;
                    this.emptyWeight = 2;
                    this.description = "";
                }
                else if (name == "case, crossbow bolt")
                {
                    this.cost = 1;
                    this.emptyWeight = 1;
                    this.description = "";
                }
                else if (name == "case, map/scroll")
                {
                    this.cost = 1;
                    this.emptyWeight = 1;
                    this.description = "";
                }
                else if (name == "chest")
                {
                    this.cost = 5;
                    this.emptyWeight = 25;
                    this.description = "";
                }
                else if (name == "flask or tankard")
                {
                    this.cost = .002;
                    this.emptyWeight = 1;
                    this.description = "";
                }
                else if (name == "glass bottle")
                {
                    this.cost = 2;
                    this.emptyWeight = 2;
                    this.description = "";
                }
                else if (name == "jug or pitcher")
                {
                    this.cost = 0.002;
                    this.emptyWeight = 4;
                    this.description = "";
                }
                else if (name == "pot, iron")
                {
                    this.cost = 2;
                    this.emptyWeight = 10;
                    this.description = "";
                }
                else if (name == "pouch")
                {
                    this.cost = .5;
                    this.emptyWeight = 1;
                    this.description = "A cloth or leather pouch can hold up to 20 sling bullets or 50 blowgun needles, " +
                        "among other things. " +
                        "A compartmentalized pouch for holding spell components is called a component pouch.";
                }
                else if (name == "quiver")
                {
                    this.cost = 1;
                    this.emptyWeight = 1;
                    this.description = "";
                }
                else if (name == "sack")
                {
                    this.cost = .001;
                    this.emptyWeight = 0.5;
                    this.description = "";
                }
                else if (name == "vial")
                {
                    this.cost = 1;
                    this.emptyWeight = 0;
                    this.description = "";
                }
                else if (name == "waterskin")
                {
                    this.cost = .2;
                    this.emptyWeight = 5; //when full
                    this.description = "";
                }


            }

            public void StoreItem(Item item)
            {
                contents.Add(item.name, item);
                contentsValue += item.value;
                contentsWeight += item.weight;
            }

            public void RemoveItem(Item item)
            {
                if (contents.ContainsKey(item.name))
                {
                    contents.Remove(item.name);
                    contentsValue -= item.value;
                    contentsWeight -= item.weight;
                }
            }
            protected override void Equip()
            {
                containers.Add(this.name, this);
            }

        }
        public abstract class Focus : Item
        {
            protected string focusType;
            protected string focusDescription;
            protected List<string> userTypes;
            protected Focus(string name, string focusType) : base(name)
            {
                this.focusType = focusType;
                this.magical = true;
                this.description = "";
                this.focusDescription = "no description yet";
                this.userTypes = new List<string>();
            }

            protected override void Equip()
            {
                foci.Add(this.name, this);
            }
        }

        public class ArcaneFocus : Focus
        {
            public ArcaneFocus(string name, string focusType) : base(name, focusType)
            {
                this.focusType = focusType;
                this.focusDescription = "An arcane focus is a special item -- an orb, a crystal, a rod, a specifically " +
                    "constructed staff, a wand-like length of wood, or some similar item -- desiged to channel the power of " +
                    "arcane spells. A sorcerer, a warlock, or wizard can use such an item as a spellcasting focus.";

                this.userTypes.Add("wizard");
                this.userTypes.Add("sorcerer");
                this.userTypes.Add("warlock");

                if(name == "crystal")
                {
                    this.cost = 10;
                    this.weight = 1;
                }
                if (name == "orb")
                {
                    this.cost = 20;
                    this.weight = 3;
                }
                if (name == "rod")
                {
                    this.cost = 10;
                    this.weight = 2;
                }
                if (name == "staff")
                {
                    this.cost = 5;
                    this.weight = 4;
                }
                if (name == "wand")
                {
                    this.cost = 10;
                    this.weight = 1;
                }


            }
        }

        public class DruidicFocus : Focus
        {
            public DruidicFocus(string name, string focusType) : base(name, focusType)
            {
                this.focusType = focusType;
                this.focusDescription = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of " +
                    "yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating " +
                    "feathers, fur, bones, and teeth from sacred animals. A druid can use such an object as a spellcasting " +
                    "focus.";

                this.userTypes.Add("druid");

                if(name == "sprig of mistletoe" || name == "totem")
                {
                    this.cost = 1;
                    this.weight = 0;
                }
                if (name == "wooden staff")
                {
                    this.cost = 5;
                    this.weight = 4;
                }
                if (name == "yew wand")
                {
                    this.cost = 10;
                    this.weight = 1;
                }
            }
        }

        public class HolySymbol : Focus
        {
            public HolySymbol(string name, string focusType) : base(name, focusType)
            {
                this.focusType = focusType;
                this.focusDescription = "A holy symbol is a representation of a god or pantheon. It might be an amulet depicting " +
                    "a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a " +
                    "tiny box holding a fragment of a sacred relic. A cleric or paladin can use a holy symbol as a spellcasting " +
                    "focus. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a " +
                    "shield.";

                this.userTypes.Add("cleric");
                this.userTypes.Add("paladin");

                if (name == "amulet")
                {
                    this.cost = 5;
                    this.weight = 1;
                }
                if (name == "emblem")
                {
                    this.cost = 5;
                    this.weight = 0;
                }
                if (name == "reliquary")
                {
                    this.cost = 5;
                    this.weight = 2;
                }

            }
        }
    }
}