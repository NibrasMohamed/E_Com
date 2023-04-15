using LapShop.DataBaseConnection;
using LapShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace LapShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly SignInManager<User> _signInManager;
        // GET: RegisterController
        public RegisterController(MyDbContext dbContext, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
        }
        public ActionResult Index()
        {
            return View("Register");
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            var first_name = Request.Form["first_name"];
            var last_name = Request.Form["last_name"];
            var address = Request.Form["address"];
            var city = Request.Form["city"];
            var country = Request.Form["country"];
            var postal_code = Request.Form["code"];
            var phone_no = Request.Form["phone_no"];


            var email = Request.Form["email"];
            var password = Request.Form["password"];

            if (string.IsNullOrEmpty(first_name))
            {
                ModelState.AddModelError("first_name", "First name is required");
            }

            if (string.IsNullOrEmpty(last_name))
            {
                ModelState.AddModelError("last_name", "Last name is required");
            }

            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "Email is required");
            }

            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is required");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var user = new User
                {
                    Email = email,
                    Password = password
                };

                _dbContext.Add(user);
                _dbContext.SaveChanges();

                var customer = new Customer
                {
                    FirstName = first_name,
                    LastName = last_name,
                    Address = address,
                    City = city,
                    Phone = phone_no,
                    Country = country,
                    PostalCode = postal_code,
                    UserID = user.UserID,
                };

                _dbContext.Add(customer);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("register", ex.Message);
                throw;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User ID Not found. Please register!";
                return RedirectToAction("Register");
            }

            if(user.Password != password)
            {
                TempData["ErrorMessage"] = "Password was incorrecr";
                return RedirectToAction("Regsiter");
            }
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("/", "Home");
        }
        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
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

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
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

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
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
    }
}
