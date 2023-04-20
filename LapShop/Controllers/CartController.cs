using LapShop.Controllers.ViewModels;
using LapShop.DataBaseConnection;
using LapShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _context;
        public CartController(MyDbContext context) {
            _context = context;
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult AddToCart(int ModelId, int Quantity)
        {
            // Get the model from the database
            var model = _context.Models.Find(ModelId);

            // Create a new cart item
            var cartItem = new CartItem
            {
                Id = model.ModelID,
                Name = model.ModelName,
                Price = model.BasePrice,
                Quantity = Quantity
            };

            // Get the current cart from the session
            
            var cart = HttpContext.Session.GetObjectFromJson<CartViewModel>("Cart") ?? new CartViewModel();

            // Add the new item to the cart
            cart.Items.Add(cartItem);

            // Calculate the total price of the cart
            cart.TotalPrice = cart.Items.Sum(item => item.Price * item.Quantity);

            // Save the cart back to the session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index");
        }
    }
}
