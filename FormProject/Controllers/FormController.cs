using FormProject.Context;
using FormProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormProject.Controllers
{
    public class FormController : Controller
    {
        private readonly AppDbContext _context;

        public FormController(AppDbContext context)
        {
            _context = context;
        }
        //search
        public IActionResult Search(string searchString)
        {
            var forms = from f in _context.Forms
                        select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(s => s.Name.Contains(searchString));
            }

            return View("Index", forms.ToList());
        }
        public IActionResult Index()
        {
            IEnumerable<Form> objFormList = _context.Forms;
            return View(objFormList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Form form)
        {
            int userId;
            bool parsed = int.TryParse(Request.Cookies["UserId"], out userId);

            if (!parsed)
            {
                return RedirectToAction("Index", "Login");
            }
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            form.User = user;

            form.UserId = userId;

            if (ModelState.IsValid)
            {

                _context.Forms.Add(form);
                _context.SaveChanges();
                TempData["success"] = "Form created successfully";
                return RedirectToAction("Index");
            }
            //return View(form);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.Forms.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Form obj)
        {
            int userId = int.Parse(Request.Cookies["UserId"]);

            if (ModelState.IsValid)
            {
                obj.UserId = userId;

                _context.Forms.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Form updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categoryFromDb = _context.Forms.Find(id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _context.Forms.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_context.Forms.Remove(obj);
			_context.SaveChanges();
            TempData["success"] = "Form deleted successfully";
            return RedirectToAction("Index");

		}
	}
}