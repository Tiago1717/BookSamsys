using autores;
using Livros;
using Autores2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autores
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutoresAsync();
        Task<Autor> GetAutorAsync(int id);
        Task CreateAutorAsync(Autor autor);
        Task UpdateAutorAsync(Autor autor);
        Task DeleteAutorAsync(int id);
    }

    public class AutorRepository : IAutorRepository
    {
        private readonly AutoresContexto _contexto;

        public AutorRepository(AutoresContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Autor>> GetAutoresAsync()
        {
            return _contexto.Autores.ToList();
        }

        public async Task<Autor> GetAutorAsync(int id)
        {
            return _contexto.Autores.FirstOrDefault(a => a.Id == id);
        }

        public async Task CreateAutorAsync(Autor autor)
        {
            _contexto.Autores.Add(autor);
            await _contexto.SaveChangesAsync();
        }

        public async Task UpdateAutorAsync(Autor autor)
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
