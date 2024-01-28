using AppDbContex;
using authors;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbContext
{
    public class AuthorBook
    {
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public Author Author { get; set; }

        public Books Book { get; set; }
    }
}
