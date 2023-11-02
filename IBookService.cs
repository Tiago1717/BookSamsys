
using Book;
using BookService;

namespace IBookService;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task UpdateBookAsync(int id, Book book);
    Task DeleteBookAsync(int id);
}
