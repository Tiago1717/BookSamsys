using Book;
using author;
using BooksController;
using IBookService;
using BookService;
using IBookRepository;
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

namespace BookRepository;

[Route("api")]
[ApiController]
public class BookRepository : ControllerBase
{
    private readonly BookContext _context;
    private BookContext context;

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
    }


