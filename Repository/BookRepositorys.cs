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

namespace BookRepositorys
{

    [Route("api")]
    [ApiController]
    public class BookRepository : ControllerBase
    {
        private readonly BookContext _context;
        private BookContext context;
        private int AuthorId;

        public decimal Price { get; private set; }
        public string ISBN { get; private set; }
        public string BookName { get; private set; }

        public BookRepository(BookContext _context)
        {
            _context = context;
        }

        public async Task<List<Books>> GetBookAsync()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public async Task<Books> GetBookByIsbn(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            return book;
        }

        public async Task<Books> PostNewBook([FromBody] Books newBook)
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }


        public async Task<Books> RemoveOneBook(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Books> EditOneBook(Books book)
        {
            await _context.SaveChangesAsync();

            return book;
        }
        [HttpPost("addbook")]
        public async Task<ActionResult<Books>> AddBookAsync(BookDTO bookDTO)
        {
            Books book = new Books
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

