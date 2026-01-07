using Activity3.Data;
using Activity3.Models;
using Activity3.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Activity3.Controllers
{
    // Controller that handles home-related pages and actions
    public class HomeController : Controller
    {
        // DbContext used to access the database
        private readonly ApplicationDbContext dbContext;

        // Constructor injection: gives the controller access to the database
        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Displays the home page with the form
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Loads Index.cshtml
        }

        // POST: Handles form submission from the home page
        [HttpPost]
        public async Task<IActionResult> Index(FormViewModel viewModel)
        {
            // Convert the ViewModel into a Form entity
            var form = new Form
            {
                Username = viewModel.Username,
                Character = viewModel.Character,
                MessageText = viewModel.MessageText,
                Rating = viewModel.Rating
            };
 
            await dbContext.Forms.AddAsync(form);  // Add the new form data to the database
            await dbContext.SaveChangesAsync();    // Save changes to the database

            return View();   // Reload the same page after saving
        }

        // GET: Displays the list of submitted forms
        [HttpGet]
        public async Task<IActionResult> FormList()
        {
            // Get all records from the Forms table
            var forms = await dbContext.Forms.ToListAsync();

            // Pass the list to the FormList view
            return View(forms);
        }


        // Edit entries in the form
        [HttpGet]
        public async Task<IActionResult> EditForm(Guid id)
        {
            var form = await dbContext.Forms.FindAsync(id);

            return View(form);
        }

        // Get updated entries from the form
        [HttpPost]
        public async Task<IActionResult> EditForm(Form viewModel)
        {
            var form = await dbContext.Forms.FindAsync(viewModel.Id);

            if (form is not null)
            {
                form.Username = viewModel.Username;
                form.Character = viewModel.Character;
                form.MessageText = viewModel.MessageText;
                form.Rating = viewModel.Rating;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("FormList", "Home");
        }

        //// Delete entries in the form list
        [HttpGet]
        public async Task<IActionResult> DeleteForm(Guid id)
        {
            var form = await dbContext.Forms.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (form is not null)
            {
                dbContext.Forms.Remove(form);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("FormList", "Home");
        }

        // Handles error pages and disables caching
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Shows error details when something goes wrong
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
