using author;
using BookService;
using AuthorRepository;
using IAuthorRepository;
using IAuthorService;
using AuthorController;
using Microsoft.AspNetCore.Mvc;

namespace AuthorController;

public class AuthorsController : ControllerBase
{
    private readonly BooksService _bookService;

    public AuthorsController(BooksService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("authors")]
    public async Task<ActionResult<MessagingHelper<List<AuthorDTO>>>> GetAuthors()
    {
        var result = await _bookService.GetAuthors();
        return result;
    }

    [HttpGet("authors/{id}")]
    public async Task<ActionResult<MessagingHelper<AuthorDTO>>> GetAuthor(int id)
    {
        var result = await _bookService.GetAuthorById(id);
        return result;
    }

    [HttpPost("authors")]
    public async Task<ActionResult<MessagingHelper<AuthorDTO>>> PostAuthor([FromBody] AuthorDTO authorDTO)
    {
        var result = await _bookService.PostAuthorAsync(authorDTO);
        return result;
    }

    [HttpDelete("authors/{id}")]
    public async Task<ActionResult<MessagingHelper<AuthorDTO>>> DeleteAuthor(int id)
    {
        var result = await _bookService.RemoveAuthor(id);
        return result;
    }

    [HttpPut("authors/{id}")]
    public async Task<ActionResult<MessagingHelper<AuthorDTO>>> PutAuthor(int id, [FromBody] AuthorDTO author)
    {
        var result = await _bookService.EditAuthor(id, author);
        return result;
    }
}

