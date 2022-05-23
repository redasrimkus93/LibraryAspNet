using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;

namespace MyFirstWebApp.Pages.Books
{
    public class CreateModel : AuthorSelectModel
    {
        private readonly BooksRepository _booksRepository;
        private readonly LibraryManagementContext _context;

        [BindProperty]
        public Book Book { get; set; }


        public CreateModel(BooksRepository booksRepository
            , LibraryManagementContext context)
        {
            _booksRepository = booksRepository;
            _context = context;
        }

        public IActionResult OnGet()
        {
            GenerateAuthorsDropDownList(_context);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            /*            if (!ModelState.IsValid)
                        {
                            return Page();
                        }*/
            if (Book.Title == null && Book.AuthorId == 0)
            {
                return Page();
            }
            _booksRepository.CreateBook(Book);
            return RedirectToPage("Category/Index");

/*            var emptyBook = new Book();

            var tryUpdate = await TryUpdateModelAsync<Book>(emptyBook, "book", s => s.Id, s => s.AuthorId, s => s.Title, s => s.Content);

            if (tryUpdate)
            {
                _booksRepository.CreateBook(emptyBook);
                return RedirectToPage("Index");
            }

            return Page();*/

        }
    }
}
