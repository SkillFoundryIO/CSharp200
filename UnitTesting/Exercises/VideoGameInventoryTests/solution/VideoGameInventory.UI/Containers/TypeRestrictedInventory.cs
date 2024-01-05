using VideoGameInventory.UI.Items;

namespace VideoGameInventory.UI.Containers
{
    public class TypeRestrictedInventory : InventoryBase
    {
        protected ItemType _requiredType;

        public TypeRestrictedInventory(int capacity, ItemType requiredType) : base(capacity)
        {
            _requiredType = requiredType;
        }

        public override AddResult AddItem(ItemBase item)
        {
            if(item.Type == _requiredType)
            {
                return base.AddItem(item);
            }

            return AddResult.WrongType;
        }
    }
}
