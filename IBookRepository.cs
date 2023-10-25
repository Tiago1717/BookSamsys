using Book;
using BookRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBookRepository;

    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task CreateBookAsync(Book Book);
        Task UpdateBookAsync(Book Book);
        Task DeleteBookAsync(int id);
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
