
using authors;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authors2;
using IAutor;

namespace Service;
public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _autorRepository;

    public AuthorService(IAuthorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public Task<Author> CreateAutoresAsync(Author autor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAutoresAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> GetAutoresAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetAutoresAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAutoresAsync(int id, Author autor)
    {
        throw new NotImplementedException();
    }
}
