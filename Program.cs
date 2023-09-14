
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class LivroContexto : DbContext
{
    public DbSet<Livro> Livros { get; set; } //base de dados- guarda todos os dados dos livros

    public LivroContexto(DbContextOptions<LivroContexto> options) : base(options)
    {
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
