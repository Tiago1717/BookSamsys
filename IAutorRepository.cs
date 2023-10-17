using autores;

namespace Iautor;
public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetautoresAsync();
    Task<Livro> GetautoresAsync(int id);
    Task CreateacutoresAsync(autores autor);
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

    //continuar
}