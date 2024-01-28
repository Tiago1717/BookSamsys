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
using DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookRepositorys
{

    [ApiController]
    [Route("api/books")]
    public class BookRepository : ControllerBase
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return Books.books;
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<Books>> GetBookByIsbn(string isbn)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }

            return Books.book;
        }

        [HttpPost]
        public async Task<ActionResult<Books>> PostNewBook(Books newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            await _context.Books.AddAsync(Books.newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookByIsbn), new { isbn = newBook.ISBN }, newBook);
        }

        [HttpDelete("{isbn}")]
        public async Task<ActionResult<Books>> RemoveOneBook(string isbn)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Books.book;
        }

        [HttpPut]
        public async Task<ActionResult<Books>> EditOneBook(Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return book;
        }
    }
}