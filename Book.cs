using authors;

namespace Book;
public class Book
{
    public decimal Id { get; set; }
    public string ISBN { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public bool Eliminated { get; set; }
    public int AuthorId { get; set; }
}