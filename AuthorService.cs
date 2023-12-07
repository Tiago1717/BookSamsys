
using author;
using System.Collections.Generic;
using System.Threading.Tasks;
using IAuthorService;

namespace AuthorService;
public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public Task<Author> CreateAutoresAsync(Author author)
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

