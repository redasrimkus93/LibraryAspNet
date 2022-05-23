using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;

namespace MyFirstWebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksRepository _booksRepository;
        
        public List<Book> Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; }
        public SelectList Authors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedAuthorName { get; set; }

        public IndexModel(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IActionResult OnGet()
        {
            if (SelectedAuthorName == "Create")
            {
                return RedirectToPage("Create");
            }
            var authors = _booksRepository.GetBooksAuthors();

            Authors = new SelectList(authors);

            Books = _booksRepository.GetBooks(SearchInputTitle, SelectedAuthorName);
            return Page();

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
