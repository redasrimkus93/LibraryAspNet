using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirstWebApp.Model;

namespace MyFirstWebApp.Repositories
{
    public class BooksRepository
    {
        private readonly LibraryManagementContext _context;

        public BooksRepository(LibraryManagementContext context)
        {
            _context = context;
        }

/*        public List<Book> GetBooks()
        {
            return _context.Books.Include(book => book.Author).ToList();
        }*/

        public List<Book> GetBooks(string title = null, string authorName = null)
        {
            var books = _context.Books.Include(b=> b.Author).Select(book => book);
            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(book => book.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                books = books.Where(book => book.Author.Name.Contains(authorName));
            }

            return books.ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public void DeteteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void CreateBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public List<string> GetBooksAuthors()
        {
            return _context.Books.Include(b => b.Author).Select(b => b.Author.Name).Distinct().ToList();
        }


    }
}
