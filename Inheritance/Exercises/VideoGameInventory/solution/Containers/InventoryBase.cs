using VideoGameInventory.Items;

namespace VideoGameInventory.Containers
{
    public abstract class InventoryBase
    {
        private int _capacity;
        private ItemBase[] _contents;

        public InventoryBase(int capacity)
        {
            _capacity = capacity;
            _contents = new ItemBase[_capacity];
        }

        public virtual AddResult AddItem(ItemBase item)
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_contents[i] == null)
                {
                    _contents[i] = item;
                    return AddResult.Success;
                }
            }
            return AddResult.ContainerFull;
        }

        public virtual ItemBase RemoveItem(int index)
        {
            if (index >= 0 && index < _capacity)
            {
                ItemBase item = _contents[index];
                if (item != null)
                {
                    _contents[index] = null;
                    return item;
                }
            }
            return null;
        }

        public virtual void ListContents()
        {
            Console.WriteLine("Contents\n=================");
            for (int i = 0; i < _contents.Length; i++)
            {
                if (_contents[i] != null)
                {
                    var item = _contents[i];
                    Console.WriteLine($"{item.Type} | {item.Name} | {item.Weight}kg | {item.Value:c0} ");
                }
            }
        }
    }
}
