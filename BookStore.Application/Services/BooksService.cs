using BookStore.Core.Models;
using BookStore.DataAccess.Repositories;

namespace BookStore.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;

        public BooksService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.CreateBook(book);
        }

        public async Task<Guid> UpdateBok(Guid id, string title, string description, decimal price)
        {
            return await _bookRepository.UpdateBook(id, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookRepository.DeleteBook(id);
        }
    }
}
