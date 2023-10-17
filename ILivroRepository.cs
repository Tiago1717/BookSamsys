using Livros;

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

    //continuar
}