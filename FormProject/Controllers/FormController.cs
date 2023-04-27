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
    }
}
