using author;
using Book;
using BooksController;
using BookRepository;
using Microsoft.EntityFrameworkCore;

public class AuthorContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {
        }
    }

public class BookContext : DbContext
{
    public DbSet<Books> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Book)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
