
using System.Collections.Generic;
using System.Threading.Tasks;
using Book;
using IBookRepository;

namespace BookService;
public class BookService : IBookService
{
    private readonly IBookRepository _BookRepository;

    public BookService(IBookRepository BookRepository)
    {
        _BookRepository = BookRepository;
    }

    Task<Livro> IBookService.CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    Task IBookService.DeleteBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Livro> IBookService.GetBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Book>> IBookService.GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    Task IBookService.UpdateBookAsync(int id, Book Book)
    {
        throw new NotImplementedException();
    }
}
