
using autores;

namespace IAutor;
public interface IAutorService
{
    Task<IEnumerable<Autor>> GetAutoresAsync();
    Task<Autor> GetAutoresAsync(int id);
    Task<Autor> CreateAutoresAsync(Autor autor);
    Task UpdateAutoresAsync(int id, Autor autor);
    Task DeleteAutoresAsync(int id);
}
