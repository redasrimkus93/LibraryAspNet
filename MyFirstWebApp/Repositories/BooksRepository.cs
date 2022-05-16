using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyFirstWebApp.Model;

namespace MyFirstWebApp.Repositories
{
    public class BooksRepository
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public void DeteleBook(int id)
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


    }
}
