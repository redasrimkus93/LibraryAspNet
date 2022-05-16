using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApp.Model
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
    : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }



    }
}
