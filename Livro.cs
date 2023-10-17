

namespace livros;
public class Livro
{
    public decimal Id { get; set; }
    public string ISBN { get; set; }
    public string Nome { get; set; }
    public string Autor { get; set; }
    public decimal Preço { get; set; }
    public bool Eliminado { get; set; }
    public int AutorId { get; set; }
}