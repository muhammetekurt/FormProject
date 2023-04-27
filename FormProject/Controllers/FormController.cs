using FormProject.Context;
using FormProject.Models;
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
            // form verilerini veri tabanına kaydedin
            // burada veri tabanı işlemleri yapılır
            // örneğin veri tabanına kaydettikten sonra Index sayfasına yönlendirin
            _context.Forms.Add(form);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}