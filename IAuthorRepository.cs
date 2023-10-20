using autores;
using Livros;
using Autores2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autores
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAutoresAsync();
        Task<Author> GetAutorAsync(int id);
        Task CreateAutorAsync(Author autor);
        Task UpdateAutorAsync(Author autor);
        Task DeleteAutorAsync(int id);
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
