using Activity3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Activity3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FormDbContext _context;

        // Inject DbContext into HomeController
        public HomeController(ILogger<HomeController> logger, FormDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Display Home page (with form)
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FanInteractionForm(Form model)
        {
            if (!ModelState.IsValid)
            {
                // Return user back to the form if validation fails
                return View("Index", model);
            }

            _context.Forms.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Forms");
        }

        // Display all submitted forms
        public IActionResult Forms()
        {
            var allForms = _context.Forms.ToList();
            return View(allForms);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
