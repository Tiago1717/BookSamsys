using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorController;
using authors;
using Book;
using AuthorServices;
using Author_BookServices;

namespace Author_BookControllers;

[Route("api/")]
[ApiController]
public class Author_BookController : ControllerBase
{
    private readonly Author_BookService _author_BookService;

    public Author_BookController(Author_BookService author_BookService)
    {
        _author_BookService = author_BookService;
    }

    [HttpPost("autor-livro")]
    public async Task<MessangingHelper<Author_bookDTO>> PostRelationship([FromBody] Author_bookDTO author_BookDTO)
    {
        return await _author_BookService.PostRelationship(author_BookDTO);
    }

}