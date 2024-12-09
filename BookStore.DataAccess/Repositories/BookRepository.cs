using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            List<BookEntity> bookEntities = await _context.Books
                .AsNoTracking() // allowed if nothing to change 
                .ToListAsync();

            // mapper Enity to Domain model
            List<Book> books = bookEntities
                .Select(book => Book.Create(book.Id, book.Title, book.Description, book.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> CreateBook(Book book)
        {
            BookEntity bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(book => book.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(book => book.Title, book => title)
                    .SetProperty(book => book.Description, book => description)
                    .SetProperty(book => book.Price, book => price));

            return id;
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            await _context.Books
                .Where(book => book.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
