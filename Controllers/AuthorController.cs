using authors;
using BookService;
using AuthorServices;
using AuthorRepositorys;
using IAuthorRepositorys;
using IAuthorServices;
using AuthorController;
using Microsoft.AspNetCore.Mvc;
using Author_BookControllers;
using MessageHelper;
using AuthorD;
using IBookServices;

namespace AuthorController
{

    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("authors")]
        public async Task<ActionResult<MessangingHelper<List<AuthorDTO>>>> GetAuthors()
        {
            var result = await _authorService.GetAuthors();
            return result;
        }

        [HttpGet("authors/{id}")]
        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> GetAuthor(int id)
        {
            var result = await _authorService.GetAuthorById(id);
            return result;
        }

        [HttpPost("authors")]
        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> PostAuthor([FromBody] AuthorDTO authorDTO)
        {
            var result = await _authorService.PostAuthorAsync(authorDTO);
            return result;
        }

        [HttpDelete("authors/{id}")]
        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> DeleteAuthor(int id)
        {
            var result = await _authorService.RemoveAuthor(id);
            return result;
        }

        [HttpPut("authors/{id}")]
        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> PutAuthor(int id, [FromBody] AuthorDTO author)
        {
            var result = await _authorService.EditAuthor(id, author);
            return result;
        }

    }
}

