using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Model
{
    public class Author
    {
        public int Id { get; set; }
        [Display(Name="Author Name")]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
