using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VideoGameInventory.Items
{
    public class Sword : ItemBase
    {
        public Sword()
        {
            Type = ItemType.Weapon;
            Name = "Sword";
            Description = "A sharp, sturdy sword.";
            Weight = 10.0;
            Value = 100m;
        }
    }
}
