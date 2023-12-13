using Book;
using author;
using IAuthorRepository;
using IAuthorService;
using AuthorController;
using AuthorService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NuGet.Versioning;
using Ninject.Activation;
using System.Data.Entity;

namespace AuthorRepository;

[Route("api/authors")]
[ApiController]
public class AuthorRepository : ControllerBase
{
    private readonly AuthorContext _context;

    public AuthorRepository(AuthorContext context)
    {
        _context = context;
    }
    public async Task<List<Author>> GetAuthorsAsync()
    {
        var authors = await _context.Authors.ToListAsync();
        return authors;
    }

    public async Task<Author> GetAuthorById(int authorId)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        return author;
    }

    public async Task<Author> PostNewAuthor([FromBody] Author newAuthor)
    {
        await _context.Authors.AddAsync(newAuthor);
        await _context.SaveChangesAsync();
        return newAuthor;
    }

    public async Task<Author> RemoveOneAuthor(int authorId)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> EditOneAuthor(Author author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
        return author;
    }

}
   