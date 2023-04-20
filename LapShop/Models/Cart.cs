namespace LapShop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            TotalPrice = 0;
        }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
