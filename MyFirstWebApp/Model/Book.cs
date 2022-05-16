using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
