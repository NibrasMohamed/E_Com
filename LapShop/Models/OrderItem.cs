namespace LapShop.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ModelID { get; set; }
        public int ConfigurationItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public ModelConfigurationItem ModelConfigurationItem { get; set; }
    }
}
