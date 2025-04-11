using Microsoft.AspNetCore.Mvc;
using BookApi.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;

namespace BookApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:ControllerBase
    {

        // private static List<Book> books = new List<Book>
        // {
        //     new Book { Id = 1, Title = "Book 1", Author = "Author 1", Price = 10 },
        //     new Book { Id = 2, Title = "Book 2", Author = "Author 2", Price = 20 },
        //     new Book { Id = 3, Title = "Book 3", Author = "Author 3", Price = 30 }
        // };

        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // [HttpGet("{id}")]
        // public ActionResult<Book> GetBook(int id)
        // {
        //     var book = books.FirstOrDefault(b => b.Id == id);
        //     if (book == null)
        //         return NotFound();
        //     return Ok(book);
        // }

        // [HttpPost]
        // public ActionResult<Book> CreateBook(Book book)
        // {
        //     book.Id = books.Max(b => b.Id) + 1;
        //     books.Add(book);
        //     return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        // }

        // [HttpPut("{id}")]
        // public ActionResult UpdateBook(int id, Book updatedBook)
        // {
        //     var bookIndex = books.FindIndex(b => b.Id == id);
        //     if (bookIndex == -1)
        //         return NotFound();
            
        //     books[bookIndex] = updatedBook;
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public ActionResult DeleteBook(int id)
        // {
        //     var bookIndex = books.FindIndex(b => b.Id == id);
        //     if (bookIndex == -1)
        //         return NotFound();
            
        //     books.RemoveAt(bookIndex);
        //     return NoContent();
        // }
    }

}