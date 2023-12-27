using authors;
using AuthorController;
using IAuthorServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAuthorRepositorys
{

    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> PostNewAuthorAsync(Author newAuthor);
        Task<Author> RemoveOneAuthorAsync(int id);
        Task<Author> EditOneAuthorAsync(int id, Author author);
    }
}
