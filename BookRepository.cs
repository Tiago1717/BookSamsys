using Book;
using BooksController;
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
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("books")]
    public async Task<ActionResult<MessagingHelper<List<BookDTO>>>> GetBooks()
    {
        var result = await _bookService.GetBooks();
        return result;
    }
