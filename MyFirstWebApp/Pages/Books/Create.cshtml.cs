using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;

namespace MyFirstWebApp.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagementContext _context;

        [BindProperty]
        public Book Book { get; set; }

        public CreateModel(LibraryManagementContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(Book);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
