using Xunit;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.models;
using BookApi.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.EntityFrameworkCore;

namespace api.test
{
    public class BookControllerTests
    {
        private BookContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .Options;
            var context = new BookContext(options);
            return context;
        }

        [Fact]
        public async Task GetBooks_ReturnsAllBooks()
        {
            var context = GetInMemoryDbContext();
            context.Books.AddRange(new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author A", Price = 10 },
                new Book { Id = 2, Title = "Book 2", Author = "Author B", Price = 20 }
            });
            context.SaveChanges();

            var controller = new BooksController(context);

            var result = await controller.GetBooks();
            var books = Assert.IsType<List<Book>>(result.Value);

            Assert.Equal(2, books.Count);
        }

        [Fact]
        public async Task CreateBook_ReturnsCreatedBook()
        {
            var context = GetInMemoryDbContext();
            var controller = new BooksController(context);

            var book = new Book { Id = 3, Title = "New Book", Author = "Author X", Price = 50 };
            var result = await controller.CreateBook(book);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdBook = Assert.IsType<Book>(createdResult.Value);

            Assert.Equal("New Book", createdBook.Title);
            Assert.Single(context.Books.ToList());
        }

        [Fact]
        public async Task UpdateBook_ReturnsOk_WhenSuccessful()
        {
            var context = GetInMemoryDbContext();
            var book = new Book { Id = 1, Title = "Old Title", Author = "Someone", Price = 30 };
            context.Books.Add(book);
            context.SaveChanges();

            var controller = new BooksController(context);
            book.Title = "Updated Title";

            var result = await controller.UpdateBook(1, book);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Book updated successfully.", okResult.Value);
        }

        [Fact]
        public async Task UpdateBook_ReturnsBadRequest_OnIdMismatch()
        {
            var context = GetInMemoryDbContext();
            var controller = new BooksController(context);

            var book = new Book { Id = 2, Title = "Mismatch", Author = "Mismatch", Price = 10 };

            var result = await controller.UpdateBook(1, book);
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Book ID mismatch.", badRequest.Value);
        }

        [Fact]
        public async Task DeleteBook_ReturnsNoContent_WhenSuccessful()
        {
            var context = GetInMemoryDbContext();
            var book = new Book { Id = 1, Title = "Book to Delete", Author = "Author", Price = 10 };
            context.Books.Add(book);
            context.SaveChanges();

            var controller = new BooksController(context);
            var result = await controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteBook_ReturnsNotFound_WhenBookMissing()
        {
            var context = GetInMemoryDbContext();
            var controller = new BooksController(context);

            var result = await controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}