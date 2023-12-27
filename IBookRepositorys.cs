using Book;
using BookRepositorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using authors;
using BookD;

namespace IBookRepositorys
{

    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetBooksAsync();
        Task<Books> GetBookAsync(int id);
        Task CreateBookAsync(Books book);
        Task UpdateBookAsync(Books book);
        Task DeleteBookAsync(int id);
        Task<bool> ISBNExistsAsync(string isbn);
        Task<bool> ISBNExistsForOtherBookAsync(int bookId, string isbn);
        Task GetAllBooksAsync();
        Task AddBookAsync(BookDTO bookDTO);
        Task GetBookByIsbnAsync(string isbn);
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
            return _context.Books.ToList();
        }

        public async Task<Books> GetBookAsync(int id)
        {
            return _context.Books.FirstOrDefault(l => l.Id == id);
        }

        public async Task CreateBookAsync(Books Book)
        {
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Books Book)
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

    }
}
