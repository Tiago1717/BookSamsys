
using autores;
using System.Collections.Generic;
using System.Threading.Tasks;

using IAutor;
public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public Task<Autor> CreateAutoresAsync(Autor autor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAutoresAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Autor>> GetAutoresAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Autor> GetAutoresAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAutoresAsync(int id, Autor autor)
    {
        throw new NotImplementedException();
    }
}
