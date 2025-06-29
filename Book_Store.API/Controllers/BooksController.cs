using Book_Store.API.Contracts;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetBooks();
            var response = books.Select(book => new BooksResponse(book.Id, book.Title, book.Description, book.Price));
            
            return Ok(response);
        }
    }
}
