using Book;
using BookService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using authors;

namespace BooksController
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _bookService;

        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult<MessagingHelper<List<BookDTO>>>> GetBooks()
        {
            return await _bookService.GetBooks();
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<MessagingHelper<BookDTO>>> GetBook(string isbn)
        {
            return await _bookService.GetBookByIsbn(isbn);
        }

        [HttpPost("PostBook")]
        public async Task<ActionResult<MessagingHelper<BookDTO>>> PostBook([FromBody] BookDTO bookDTO)
        {
            return await _bookService.PostBookAsync(bookDTO);
        }

        [HttpDelete("{isbn}")]
        public async Task<ActionResult<MessagingHelper<BookDTO>>> DeleteBook(string isbn)
        {
            return await _bookService.RemoveBook(isbn);
        }

        [HttpPut("{isbn}")]
        public async Task<ActionResult<MessagingHelper<BookDTO>>> PutBook(string isbn, [FromBody] BookDTO book)
        {
            return await _bookService.EditBook(isbn, book);
        }
    }
}


