using Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booksc
{
    public class LivroContexto : DbContext
    {
        public DbSet<Livro> Livros { get; set; } //base de dados- guarda todos os dados dos livros

        public LivroContexto(DbContextOptions<LivroContexto> options) : base(options)
        {
        }
    }

    [Route($"{nameof(Livros)}")] //ajudam a definir como o controlador lida com as solicitações de uma API
    [ApiController]
    public class BookController : ControllerBase //É algo que responde aos pedidios feitos pelo HTML (utilizador)
    {
        private readonly LivroContexto _contexto;

        public BookController(LivroContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet] //fica com os dados e permite o GetLivros();
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _contexto.Livros.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _contexto.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            _contexto.Livros.Add(livro);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction($"{nameof(GetLivro)}", new { id = livro.Id }, livro);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(livro).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool livroExists = await _contexto.Livros.AnyAsync(l => l.Id == id);

                if (!livroExists)
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
            var livro = await _contexto.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            livro.Eliminado = true;
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExiste(int id) => _contexto.Livros.Any(e => e.Id == id);
    }
}
