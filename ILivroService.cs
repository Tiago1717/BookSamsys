
namespace ILivro;

public interface ILivroService
{
    Task<IEnumerable<Livro>> GetLivrosAsync();
    Task<Livro> GetLivroAsync(int id);
    Task<Livro> CreateLivroAsync(Livro livro);
    Task UpdateLivroAsync(int id, Livro livro);
    Task DeleteLivroAsync(int id);
}
