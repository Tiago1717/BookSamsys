using authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Authors2
{

    public class AuthorsContext : DbContext
    {
        public DbSet<Author> Autores { get; set; }

        public AuthorsContext(DbContextOptions<AuthorsContext> options) : base(options)
        {
        }
    }

    [Route("api/livros")] 
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorsContext _context;

        public AuthorController(AuthorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAutores()
        {
            var authors = await _context.Autores.ToListAsync();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAutor(Author autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutor), new { ida = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Author autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}

