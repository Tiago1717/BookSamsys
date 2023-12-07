using author;
using IAuthorRepository;
using AuthorController;
using AuthorService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorRepository;

[Route("api/authors")]
[ApiController]
public class AuthorRepository : ControllerBase
{
    private readonly AuthorRepository _authorRepository;

    public AuthorRepository(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public async Task<MessagingHelper<List<Author>>> GetAuthors()
    {
        return new MessagingHelper<List<Author>> { Obj = await _authorRepository.GetAuthorsAsync(), Success = true };
    }

    [HttpGet("{id}")]
    public async Task<MessagingHelper<Author>> GetAuthor(int id)
    {
        return new MessagingHelper<Author> { Obj = await _authorRepository.GetAuthorByIdAsync(id), Success = true };
    }

    [HttpPost]
    public async Task<MessagingHelper<Author>> PostAuthor([FromBody] Author newAuthor)
    {
        return new MessagingHelper<Author> { Obj = await _authorRepository.PostNewAuthorAsync(newAuthor), Success = true };
    }

    [HttpDelete("{id}")]
    public async Task<MessagingHelper<Author>> DeleteAuthor(int id)
    {
        return new MessagingHelper<Author> { Obj = await _authorRepository.RemoveOneAuthorAsync(id), Success = true };
    }

    [HttpPut("{id}")]
    public async Task<MessagingHelper<Author>> PutAuthor(int id, [FromBody] Author author)
    {
        return new MessagingHelper<Author> { Obj = await _authorRepository.EditOneAuthorAsync(id, author), Success = true };
    }
}

        [HttpGet]
        public async Task<MessagingHelper<List<Author>>> GetAuthors()
        {
            return new MessagingHelper<List<Author>> { Obj = await _authorRepository.GetAuthorsAsync(), Success = true };
        }

        [HttpGet("{id}")]
        public async Task<MessagingHelper<Author>> GetAuthor(int id)
        {
            return new MessagingHelper<Author> { Obj = await _authorRepository.GetAuthorByIdAsync(id), Success = true };
        }

        [HttpPost]
        public async Task<MessagingHelper<Author>> PostAuthor([FromBody] Author newAuthor)
        {
            return new MessagingHelper<Author> { Obj = await _authorRepository.PostNewAuthorAsync(newAuthor), Success = true };
        }

        [HttpDelete("{id}")]
        public async Task<MessagingHelper<Author>> DeleteAuthor(int id)
        {
            return new MessagingHelper<Author> { Obj = await _authorRepository.RemoveOneAuthorAsync(id), Success = true };
        }

        [HttpPut("{id}")]
        public async Task<MessagingHelper<Author>> PutAuthor(int id, [FromBody] Author author)
        {
            return new MessagingHelper<Author> { Obj = await _authorRepository.EditOneAuthorAsync(id, author), Success = true };
        }
