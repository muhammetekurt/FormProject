using FormProject.Context;
using FormProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormProject.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //get
        public IActionResult Register()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
