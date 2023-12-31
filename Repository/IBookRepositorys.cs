using Book;
using BookRepositorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using authors;
using BookD;
using System.Data.Entity;
using Abp.Extensions;

namespace IBookRepositorys
{

    public interface IBookRepository
    {
        Task<bool> ISBNExistsAsync(string ISBN);
        Task<IEnumerable<Books>> GetBooksAsync();
        Task CreateBookAsync(Books book);
        Task UpdateBookAsync(Books book);
        Task DeleteBookAsync(int id);
        Task<bool> ISBNExistsForOtherBookAsync(int bookId, string isbn);
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task AddBookAsync(BookDTO bookDTO);
        Task<Books> GetBookByIsbnAsync(string isbn);
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
            return (IEnumerable<Books>)_context.Books.ToListAsync();
        }

        public async Task<Books> GetBookByIsbnAsync(int id)
        {
            return _context.Books.FirstOrDefault(isbn => isbn.Id == id);
        }

        public async Task CreateBookAsync(Books Book)
        {
            if (await ISBNExistsAsync(Book.ISBN))
            {
                throw new InvalidOperationException("Book with the provided ISBN already exists.");
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Books Book)
        {
            var existingBook = await _context.Books.FindAsync(Book.Id);

            if (existingBook == null)
            {
                throw new InvalidOperationException("Book not found.");
            }

            if (!string.Equals(existingBook.ISBN, Book.ISBN, StringComparison.OrdinalIgnoreCase) &&
                await ISBNExistsAsync(Book.ISBN))
            {
                throw new InvalidOperationException("Book with the provided ISBN already exists.");
            }

            existingBook.BookName = Book.BookName;
            existingBook.AuthorId = Book.AuthorId;
            existingBook.Price = Book.Price;

            _context.Entry(existingBook).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook != null)
            {
                _context.Books.Remove(existingBook);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ISBNExistsAsync(string isbn)
        {
            return await _context.Books.AnyAsync(book => string.Equals(book.ISBN, isbn, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> ISBNExistsForOtherBookAsync(int bookId, string isbn)
        {
            return await _context.Books.AnyAsync(book => book.Id != bookId && string.Equals(book.ISBN, isbn, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddBookAsync(BookDTO bookDTO)
        {
            var book = new Books
            {
                ISBN = bookDTO.ISBN,
                BookName = bookDTO.BookName,
                AuthorId = bookDTO.AuthorId,
                Price = bookDTO.Price
            };

            await CreateBookAsync(book);
        }

        public async Task<Books> GetBookByIsbnAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(book => string.Equals(book.ISBN, isbn, StringComparison.OrdinalIgnoreCase));
        }
    }
}
