
using Book;
using BookService;
using author;

namespace IBookService;

public interface IBookService
{
    Task<IEnumerable<Books>> GetBooksAsync();
    Task<Books> GetBookAsync(int id);
    Task<Books> CreateBookAsync(Books book);
    Task UpdateBookAsync(int id, Books book);
    Task DeleteBookAsync(int id);
}
