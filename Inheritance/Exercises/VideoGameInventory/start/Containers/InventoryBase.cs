using VideoGameInventory.Items;

namespace VideoGameInventory.Containers
{
    public class InventoryBase
    {
        private int _capacity;
        private ItemBase[] _contents;

        public InventoryBase(int capacity)
        {
            _capacity = capacity;
            _contents = new ItemBase[_capacity];
        }

        public virtual bool AddItem(ItemBase item)
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_contents[i] == null)
                {
                    _contents[i] = item;
                    return true;
                }
            }
            return false;
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
    }
}
