
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class LivroContexto : DbContext
{
    public DbSet<Livro> Livros { get; set; } //base de dados- guarda todos os dados dos livros

    public LivroContexto(DbContextOptions<LivroContexto> options) : base(options)
    {
    }
}

[Route("api/livros")] //ajudam a definir como o controlador lida com as solicitações de uma API
[ApiController]
public class LivrosController : ControllerBase //É algo que responde aos pedidios feitos pelo HTML (utilizador)
{
    private readonly LivroContexto _Contexto;

    public LivrosController(LivroContexto contexto)
    {
        _Contexto = contexto;
    }
}

public class Livro
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Nome { get; set; }
    public string Autor { get; set; }
    public decimal Preço { get; set; }
}



