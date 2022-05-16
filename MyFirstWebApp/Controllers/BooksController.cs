using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;

namespace MyFirstWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository _booksRepository;

        public BooksController(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }


        // GET api/books
        [HttpGet]
        public List<Book> GetBooks()
        {
            return _booksRepository.GetBooks();

        }

        // GET api/books/id
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return _booksRepository.GetBook(id);
        }

        // POST api/books
        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            _booksRepository.CreateBook(book);
            return Ok();
            //return CreatedAtAction(nameof(book), book);
        }

        [HttpDelete]
        public ActionResult DeleteBook([FromQuery] int id)
        {
            _booksRepository.DeteteBook(id);
            return Ok();
        } 

        [HttpPut]
        public ActionResult UpdateBook([FromBody] Book book)
        {
            _booksRepository.UpdateBook(book);
            return Ok();
        }







    }
}
