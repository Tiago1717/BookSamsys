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
using MessageHelper;
using BookD;

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
        public async Task<ActionResult<MessangingHelper<List<BookDTO>>>> GetBooks()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<MessangingHelper<BookDTO>>> GetBook(string isbn)
        {
            return await _bookService.GetBookByIsbn(isbn);
        }

        [HttpPost("PatchBook")]
        public async Task<ActionResult<MessangingHelper<BookDTO>>> PatchBook([FromBody] BookDTO bookDTO)
        {
            return await _bookService.PostBookAsync(bookDTO);
        }

        [HttpDelete("{isbn}")]
        public async Task<ActionResult<MessangingHelper<BookDTO>>> DeleteBook(string isbn)
        {
            return await _bookService.RemoveBook(isbn);
        }

        [HttpPut("{isbn}")]
        public async Task<ActionResult<MessangingHelper<BookDTO>>> PutBook(string isbn, [FromBody] BookDTO book)
        {
            return await _bookService.EditBook(isbn, book);
        }
    }
}


