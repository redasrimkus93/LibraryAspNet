using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;

namespace MyFirstWebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryManagementContext _context;
        public List<Book> Books { get; set; }

        public IndexModel(LibraryManagementContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }
    }
}
