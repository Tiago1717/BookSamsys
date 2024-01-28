
namespace AppDbContex
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DbContext;
    using authors;
    using Book;
    public class AppDbContext : DbContext 
    {
        internal static Books Book;

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>().HasKey(a => a.Id);
            modelBuilder.Entity<Authors>().Property(a => a.AuthorName).IsRequired();

            modelBuilder.Entity<Books>().HasKey(b => b.Id);
            modelBuilder.Entity<Books>().Property(b => b.ISBN).IsRequired();
            modelBuilder.Entity<Books>().Property(b => b.BookName).IsRequired();

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving changes.", ex);
            }
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }
    }

    public class Authors
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Books> Books { get; set; }
    }

    public class Books
    {
        public static int Count { get; internal set; }
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public bool Eliminated { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
        public string AuthorName { get; internal set; }
    }
}
