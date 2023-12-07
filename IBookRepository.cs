using Book;
using BookRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using author;

namespace IBookRepository;

public interface IBookRepository
{
    Task<IEnumerable<Books>> GetBooksAsync();
    Task<Books> GetBookAsync(int id);
    Task CreateBookAsync(Books book);
    Task UpdateBookAsync(Books book);
    Task DeleteBookAsync(int id);
    Task<bool> ISBNExistsAsync(string isbn);
    Task<bool> ISBNExistsForOtherBookAsync(int bookId, string isbn);
}


public class BookRepository : IBookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Books>> GetBooksAsync()
    {
        return _context.Book.ToList(); 
    }

    public async Task<Books> GetBookAsync(int id)
    {
        return _context.Book.FirstOrDefault(l => l.Id == id); 
    }

    public async Task CreateBookAsync(book Book)
    {
        _context.Books.Add(Book); 
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(book Book)
    {
        _context.Books.Update(Book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = _context.Books.FirstOrDefault(l => l.Id == id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateBookAsync(Book Book)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookAsync(Book Book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(int id)
    {
        throw new NotImplementedException();
    }
}
