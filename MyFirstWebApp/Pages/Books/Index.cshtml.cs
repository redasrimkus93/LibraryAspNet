using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;

namespace MyFirstWebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksRepository _booksRepository;
        
        public List<Book> Books { get; set; }

        public IndexModel(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void OnGet()
        {
            Books = _booksRepository.GetBooks();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = _booksRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            _booksRepository.DeteteBook(id);
            return RedirectToPage("Index");
        }
    }
}
