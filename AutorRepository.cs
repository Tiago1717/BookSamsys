using Livros;

namespace AutorRepository;

public class AutorRepository : IAutorRepository
{
    private readonly AutorContexto _contexto;

    public AutorRepository(AutorContexto contexto)
    {
        _contexto = contexto;
    }

    
}