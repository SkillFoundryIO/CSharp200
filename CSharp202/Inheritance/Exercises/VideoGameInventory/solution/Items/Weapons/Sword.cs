namespace VideoGameInventory.Items.Weapons
{
    public class Sword : WeaponBase
    {
        public Sword()
        {
            Type = ItemType.Weapon;
            Name = "Sword";
            Description = "A sharp, sturdy sword.";
            Weight = 10.0;
            Value = 100m;
            Damage = 5;
        }
    }
}
