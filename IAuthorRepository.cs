using authors;
using Authors2;
using IAuthorService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAuthorRepository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorAsync(int id);
    Task CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
}

public class AuthorRepository : IAuthorRepository
{
    private readonly AuthorsContext _context;

    public AuthorRepository(AuthorsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return _context.Authors.ToList();
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        return _context.Authors.FirstOrDefault(a => a.Id == id);
    }

    public async Task CreateAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
