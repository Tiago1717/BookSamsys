using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using authors;
using Book;

namespace Author_Books
{

    public class Author_Book
    {
        private Author author;
        private AppDbContex.Books book;

        public Author_Book(Author author, AppDbContex.Books book)
        {
            this.author=author;
            this.book=book;
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("Book")]
        public string ISBN { get; set; }

        [ForeignKey("Author")]
        public long IdAuthor { get; set; }

    }
}