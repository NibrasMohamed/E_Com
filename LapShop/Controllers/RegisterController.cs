using Microsoft.AspNetCore.Mvc;


namespace LapShop.Controllers
{
    public class RegisterController : Controller
    {
        // GET: RegisterController
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
            var name = Request.Form["first_name"];
            var last_name = Request.Form["last_name"];
            var address = Request.Form["address"];
            var city = Request.Form["city"];
            var country = Request.Form["country"];
            var postal_code = Request.Form["code"];
            var phone_no = Request.Form["phone_no"];
            
            var email = Request.Form["email"];
            var password = Request.Form["password"];

            return RedirectToAction(last_name, email, password);

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
