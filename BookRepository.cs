using Books;

namespace livrorep;

public class BookRepository : IBookRepository
{
    private readonly LivroContexto _contexto;

    public BookRepository(LivroContexto contexto)
    {
        _contexto = contexto;
    }

    
}