using Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksController
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } //base de dados- guarda todos os dados dos livros

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }

    [Route($"{nameof(Book)}")] //ajudam a definir como o controlador lida com as solicitações de uma API
    [ApiController]
    public class BookController : ControllerBase //É algo que responde aos pedidios feitos pelo HTML (utilizador)
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet] //fica com os dados e permite o GetLivros();
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
        [HttpPost]
        public async Task<ActionResult<book>> PostLivro(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"{nameof(GetBook)}", new { id = book.Id }, book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool BookExists = await _context.Books.AnyAsync(l => l.Id == id);

                if (!BookExists)
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExiste(int id) => _context.Books.Any(e => e.Id == id);
    }
}
