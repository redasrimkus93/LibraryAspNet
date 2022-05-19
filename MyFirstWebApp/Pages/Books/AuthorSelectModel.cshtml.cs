using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Model;

namespace MyFirstWebApp.Pages.Books
{
    public class AuthorSelectModel : PageModel
    {
        public SelectList AuthorsNames { get; set; }

        public void GenerateAuthorsDropDownList(LibraryManagementContext context, object selectedAuthor = null) 
        {
            var authorsQuery = context.Authors.OrderBy(a => a.Name);

            AuthorsNames = new SelectList(authorsQuery.AsNoTracking(), "Id", "Name", selectedAuthor);
        }
    }
}
