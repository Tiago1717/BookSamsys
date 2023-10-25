using Book;
using IBookRepository;

namespace BookRepository;

public class BookRepository : IBookRepository
{
    private readonly BookContext _contexto;

    public BookRepository(LivroContexto contexto)
    {
        _contexto = contexto;
    }

    
}