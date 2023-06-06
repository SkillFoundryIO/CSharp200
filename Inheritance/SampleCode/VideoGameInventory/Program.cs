using VideoGameInventory.Containers;
using VideoGameInventory.Items;

Chest inv = new Chest(3);

inv.AddItem(new Helm());
inv.AddItem(new Potion());
inv.AddItem(new Sword());

if(!inv.AddItem(new Potion()))
{
    Console.WriteLine("Capacity is working");
}

var item = inv.RemoveItem(1);
if (item is Potion && inv.RemoveItem(1)==null)
{
    Console.WriteLine("Removed potion");
}

