using System.Xml.Linq;

namespace VideoGameInventory.Items
{
    public class Helm : ItemBase
    {
        public Helm()
        {
            Type = ItemType.Armor;
            Name = "Steel Helmet";
            Description = "Protective metal armor.";
            Weight = 10.0;
            Value = 200m;
        }
    }
}
