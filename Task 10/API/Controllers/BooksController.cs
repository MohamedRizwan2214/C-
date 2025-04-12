using Microsoft.AspNetCore.Mvc;
using BookApi.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using System.Threading.Tasks;

namespace BookApi.Controller
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("GetBooks")]
        
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            // Console.WriteLine("GetBooks called");
            return await _context.Books.ToListAsync();
        }


        [HttpPost]
        [Route("CreateBook")]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error creating book.");
            }
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("Book ID mismatch.");
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok("Book updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound("Book not found.");
            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"DELETE request received for Book ID: {id}");

            var book = await _context.Books.FindAsync(id);
            if (book is null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}