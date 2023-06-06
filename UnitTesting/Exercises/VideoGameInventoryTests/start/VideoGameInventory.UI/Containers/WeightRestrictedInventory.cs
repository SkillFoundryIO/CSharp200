using VideoGameInventory.UI.Items;

namespace VideoGameInventory.UI.Containers
{
    public class WeightRestrictedInventory : InventoryBase
    {
        protected double _maxWeight;
        protected double _currentWeight = 0;

        public WeightRestrictedInventory(int capacity, double maxWeight) : base(capacity)
        {
            _maxWeight = maxWeight;
        }

        public override AddResult AddItem(ItemBase item)
        {
            // see if the item will fit (weight)
            if (_currentWeight + item.Weight > _maxWeight)
            {
                return AddResult.Overweight;
            }
            
            if (base.AddItem(item) == AddResult.Success)
            {
                _currentWeight += item.Weight;
            }

            return AddResult.Success;
        }

        public override ItemBase RemoveItem(int index)
        {
            var item = base.RemoveItem(index);

            if (item != null)
            {
                _currentWeight -= item.Weight;
            }

            return item;
        }
    }
}
