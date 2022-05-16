using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApp.Model
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
    : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }


    }
}
