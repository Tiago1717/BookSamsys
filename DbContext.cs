using authors;
using Book;
using BooksController;
using BookRepository;
using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }
}
