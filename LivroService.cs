
using System.Collections.Generic;
using System.Threading.Tasks;
using ILivro;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    Task<Livro> ILivroService.CreateLivroAsync(Livro livro)
    {
        throw new NotImplementedException();
    }

    Task ILivroService.DeleteLivroAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Livro> ILivroService.GetLivroAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Livro>> ILivroService.GetLivrosAsync()
    {
        throw new NotImplementedException();
    }

    Task ILivroService.UpdateLivroAsync(int id, Livro livro)
    {
        throw new NotImplementedException();
    }
}
