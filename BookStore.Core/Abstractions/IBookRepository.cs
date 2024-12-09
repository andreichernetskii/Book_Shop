using BookStore.Core.Models;

namespace BookStore.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}