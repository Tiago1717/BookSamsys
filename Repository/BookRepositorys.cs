using Book;
using authors;
using BooksController;
using IBookServices;
using BookService;
using IBookRepositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NuGet.Versioning;
using Ninject.Activation;
using BookD;
using Ecng.ComponentModel;
using DbContex;
using static Book.Books;

namespace BookRepositorys
{

    [Route("api")]
    [ApiController]
    public class BookRepository : ControllerBase
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("books")]
        public async Task<ActionResult<List<Books>>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        [HttpGet("books/{isbn}")]
        public async Task<ActionResult<Books>> GetBookByIsbn(string isbn)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost("books")]
        public async Task<ActionResult<Books>> PostNewBook([FromBody] Books newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByIsbn), new { isbn = newBook.ISBN }, newBook);
        }

        [HttpDelete("books/{isbn}")]
        public async Task<ActionResult<Books>> RemoveOneBook(string isbn)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        [HttpPut("books")]
        public async Task<ActionResult<Books>> EditOneBook([FromBody] Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _context.Entry(book).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();

            return book;
        }

        [HttpPost("addbook")]
        public async Task<ActionResult<Books>> AddBookAsync([FromBody] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest();
            }

            var book = new Books
            {
                ISBN = bookDTO.ISBN,
                BookName = bookDTO.BookName,
                AuthorId = bookDTO.AuthorId,
                Price = bookDTO.Price
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByIsbn), new { isbn = book.ISBN }, book);
        }
    }
}