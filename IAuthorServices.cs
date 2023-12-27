
using authors;

namespace IAuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorsAsync(int id);
        Task<Author> CreateAuthorsAsync(Author author);
        Task UpdateAuthorsAsync(int id, Author author);
        Task DeleteAuthorsAsync(int id);
    }
}
