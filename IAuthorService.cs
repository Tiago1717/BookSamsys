
using autores;

namespace IAutor;
public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAutoresAsync();
    Task<Author> GetAutoresAsync(int id);
    Task<Author> CreateAutoresAsync(Author autor);
    Task UpdateAutoresAsync(int id, Author autor);
    Task DeleteAutoresAsync(int id);
}
