using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace AppDB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Authors>().HasKey(a => a.Id);
            modelBuilder.Entity<Authors>().Property(a => a.AuthorName).IsRequired();  

            modelBuilder.Entity<Books>().HasKey(b => b.Id);
            modelBuilder.Entity<Books>().Property(b => b.ISBN).IsRequired();  
            modelBuilder.Entity<Books>().Property(b => b.BookName).IsRequired();  
            modelBuilder.Entity<Books>().Property(b => b.AuthorName).IsRequired();  

            modelBuilder.Entity<Books>()
                .HasOne(b => b.AuthorName)
                .WithMany(a => a.BookName)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Authors
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public object BookName { get; internal set; }
    }

    public class Books
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public bool Eliminated { get; set; }
        public int AuthorId { get; set; } 
    }
}