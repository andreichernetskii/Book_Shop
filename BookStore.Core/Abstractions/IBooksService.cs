using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetBooks();
        Task<Guid> UpdateBok(Guid id, string title, string description, decimal price);
    }
}