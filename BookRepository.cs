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

namespace BookRepository;

[Route("api")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksService _bookService;

    public BooksController(BooksService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("books")]
    public async Task<ActionResult<MessagingHelper<List<BookDTO>>>> GetBooks()
    {
        var result = await _bookService.GetBooks();
        return result;
    }

    [HttpGet("{isbn}")]
    public async Task<ActionResult<MessagingHelper<BookDTO>>> GetBook(string isbn)
    {
        var result = await _bookService.GetBookByIsbn(isbn);
        return result;
    }

[HttpPost("books")]
public async Task<ActionResult<MessagingHelper<BookDTO>>> PostBook([FromBody] BookDTO bookDTO)
{
    var result = await _bookService.PostBookAsync(bookDTO);
    return result;
}

[HttpDelete("{isbn}")]
public async Task<ActionResult<MessagingHelper<BookDTO>>> DeleteBook(string isbn)
{
    var result = await _bookService.RemoveBook(isbn);
        return result;
    }


[HttpPut("{isbn}")]
public async Task<ActionResult<MessagingHelper<BookDTO>>> PutBook(string isbn, [FromBody] BookDTO book)
{
    var result = await _bookService.EditBook(isbn, book);
        return result;
    }

}

