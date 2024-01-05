namespace VideoGameInventory.UI.Items.Armors
{
    public class Helm : ArmorBase
    {
        public Helm()
        {
            Type = ItemType.Armor;
            Name = "Steel Helmet";
            Description = "Protective metal armor.";
            Weight = 10.0;
            Value = 200m;
            Defense = 5;
        }
    }
}
