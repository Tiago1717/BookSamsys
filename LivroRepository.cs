using Livros;

public class LivroRepository : ILivroRepository
{
    private readonly LivroContexto _contexto;

    public LivroRepository(LivroContexto contexto)
    {
        _contexto = contexto;
    }

    
}