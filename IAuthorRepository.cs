using author;
using AuthorController;
using IAuthorService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAuthorRepository;

public interface IAuthorRepository
{
    Task<List<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> PostNewAuthorAsync(Author newAuthor);
    Task<Author> RemoveOneAuthorAsync(int id);
    Task<Author> EditOneAuthorAsync(int id, Author author);
}
