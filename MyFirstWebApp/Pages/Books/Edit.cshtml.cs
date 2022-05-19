using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;

namespace MyFirstWebApp.Pages.Books
{
    public class EditModel : AuthorSelectModel
    {
        private readonly BooksRepository _booksRepository;
        private readonly LibraryManagementContext _context;

        public EditModel(BooksRepository booksRepository, LibraryManagementContext context)
        {
            _booksRepository = booksRepository;
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet(int id)
        {

            Book = _booksRepository.GetBook(id);
            GenerateAuthorsDropDownList(_context);
        }

        public async Task<IActionResult> OnPost()
        {
/*            if (!ModelState.IsValid)
            {
                return Page();
            }*/

            if (Book.Title == null || Book.AuthorId == 0)
            {
                return Page();
            }

            var bookFromDb = _booksRepository.GetBook(Book.Id);

            bookFromDb.Title = Book.Title;
            bookFromDb.AuthorId = Book.AuthorId;
            bookFromDb.Content = Book.Content;

            _booksRepository.UpdateBook(bookFromDb);
            return RedirectToPage("Index");


            /*            var tryUpdate = await TryUpdateModelAsync<Book>(bookFromDb, "book"
                            ,s => s.Id, s => s.AuthorId, s => s.Title, s => s.Content);

                        if (tryUpdate)
                        {
                            _booksRepository.UpdateBook(bookFromDb);
                            return RedirectToPage("Index");
                        }
                        GenerateAuthorsDropDownList(_context, bookFromDb.AuthorId);*/
        }


    }
}
