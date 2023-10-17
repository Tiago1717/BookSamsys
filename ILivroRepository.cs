using Livros;
using livrorep;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livros;

    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetLivrosAsync();
        Task<Livro> GetLivroAsync(int id);
        Task CreateLivroAsync(Livro livro);
        Task UpdateLivroAsync(Livro livro);
        Task DeleteLivroAsync(int id);
    }

public class LivroRepository : ILivroRepository
{
    private readonly LivroContexto _contexto;

    public LivroRepository(LivroContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<IEnumerable<Livro>> GetLivrosAsync()
    {
        return _contexto.Livros.ToList(); 
    }

    public async Task<Livro> GetLivroAsync(int id)
    {
        return _contexto.Livros.FirstOrDefault(l => l.Id == id); 
    }

    public async Task CreateLivroAsync(Livro livro)
    {
        _contexto.Livros.Add(livro); 
        await _contexto.SaveChangesAsync();
    }

    public async Task UpdateLivroAsync(Livro livro)
    {
        _contexto.Livros.Update(livro);
        await _contexto.SaveChangesAsync();
    }

    public async Task DeleteLivroAsync(int id)
    {
        var livro = _contexto.Livros.FirstOrDefault(l => l.Id == id);
        if (livro != null)
        {
            _contexto.Livros.Remove(livro);
            await _contexto.SaveChangesAsync();
        }
    }
}
}