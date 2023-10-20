using authors;
using Autores;
using Authors2;

namespace AutorRepository;

public class AuthorRepository : IAuthorRepository
{
    private readonly AuthorContexto _contexto;

    public AuthorRepository(AuthorContexto contexto)
    {
        _contexto = contexto;
    }

    public class AutorRepository : IAuthorRepository
    {
        private readonly AutoresContexto _contexto;

        public AutorRepository(AutoresContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Author>> GetAutoresAsync()
        {
            return _contexto.Autores.ToList();
        }

        public async Task<Author> GetAutorAsync(int id)
        {
            return _contexto.Autores.FirstOrDefault(a => a.Id == id);
        }

        public async Task CreateAutorAsync(Author autor)
        {
            _contexto.Autores.Add(autor);
            await _contexto.SaveChangesAsync();
        }

        public async Task UpdateAutorAsync(Author autor)
        {
            _contexto.Autores.Update(autor);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeleteAutorAsync(int id)
        {
            var autor = _contexto.Autores.FirstOrDefault(a => a.Id == id);
            if (autor != null)
            {
                _contexto.Autores.Remove(autor);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
}