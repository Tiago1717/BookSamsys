
namespace IBooks;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Livro> GetBookAsync(int id);
    Task<Livro> CreateLivroAsync(Livro livro);
    Task UpdateLivroAsync(int id, Livro livro);
    Task DeleteLivroAsync(int id);
}
