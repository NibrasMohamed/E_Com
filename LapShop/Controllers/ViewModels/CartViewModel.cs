using LapShop.Models;

namespace LapShop.Controllers.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
