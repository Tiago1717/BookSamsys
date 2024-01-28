
namespace DbContext
{
    using authors;
    using Book;
    using Author_Books;
    using BooksController;
    using System;
    using Microsoft.EntityFrameworkCore;
    using BookRepositorys;
    using Author_Book1;
    using System.Collections.Generic;
    using AppDbContex;
    using YamlDotNet.Core.Tokens;

    public class AuthorContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {
        }
    }

    public class BookContext : DbContext
    {
        internal object books;
        private Author_Books.Author_Book author;

        public DbSet<AppDbContex.Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public object Author_Books { get; internal set; }
        public object Book { get; internal set; }
        public object book { get; internal set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>().HasKey(a => a.Id);
            modelBuilder.Entity<Authors>().Property(a => a.AuthorName).IsRequired();

            modelBuilder.Entity<AppDbContex.Books>().HasKey(b => b.Id);
            modelBuilder.Entity<AppDbContex.Books>().Property(b => b.ISBN).IsRequired();
            modelBuilder.Entity<AppDbContex.Books>().Property(b => b.BookName).IsRequired();

            modelBuilder.Entity<AppDbContex.Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        internal List<Author_Books.Author_Book> AuthorBook()
        {
            return AuthorBook(author);
        }

        internal List<Author_Books.Author_Book> AuthorBook(Author_Books.Author_Book authorBook)
        {
            List<Author_Books.Author_Book> authorBooks = new List<Author_Books.Author_Book>();

            foreach (AppDbContex.Books book in Books)
            {
                
                authorBooks.Add(authorBook);
            }

            return authorBooks;
        }

       
    }
}

