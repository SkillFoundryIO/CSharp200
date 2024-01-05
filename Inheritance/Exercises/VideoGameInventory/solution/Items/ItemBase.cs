namespace VideoGameInventory.Items
{
    public class ItemBase
    {
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public decimal Value { get; set; }
    }
}
