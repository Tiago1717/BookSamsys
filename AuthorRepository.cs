using authors;
using AuthorRepository;
using IAuthorRepository;
using IAuthorService;
using AuthorController;

namespace AuthorRepository;

public class AuthorRepository : IAuthorRepository
{
    private readonly AuthorContext _context;

    public AuthorRepository(AuthorContext context)
    {
        _context = context;
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
}
}
