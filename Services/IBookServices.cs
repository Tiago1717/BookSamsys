
using Book;
using BookService;
using authors;

namespace IBookServices
{

    public interface IBookService
    {
        Task<IEnumerable<Books>> GetBooksAsync();
        Task<Books> GetBookAsync(int id);
        Task<Books> CreateBookAsync(Books book);
        Task UpdateBookAsync(int id, Books book);
        Task DeleteBookAsync(int id);
    }
}
