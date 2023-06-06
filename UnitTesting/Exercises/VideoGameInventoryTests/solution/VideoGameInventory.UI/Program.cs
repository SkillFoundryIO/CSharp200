using VideoGameInventory.UI.Containers;
using VideoGameInventory.UI.Items;
using VideoGameInventory.UI.Items.Armors;
using VideoGameInventory.UI.Items.Potions;
using VideoGameInventory.UI.Items.Weapons;

Chest inv = new Chest(3);

inv.AddItem(new Helm());
inv.AddItem(new HealthPotion());
inv.AddItem(new Sword());

if (inv.AddItem(new HealthPotion()) == AddResult.Overweight)
{
    Console.WriteLine("Capacity is working");
}

var item = inv.RemoveItem(1);
if (item is HealthPotion && inv.RemoveItem(1) == null)
{
    Console.WriteLine("Removed potion");
}

inv.ListContents();

PotionBandoleer b = new PotionBandoleer();

if(b.AddItem(new Sword()) == AddResult.WrongType && 
    b.AddItem(new HealthPotion()) == AddResult.Success)
{
    Console.WriteLine("Restrictions working");
}