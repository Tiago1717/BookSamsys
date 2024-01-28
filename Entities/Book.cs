using authors;
using AppDbContex; // Make sure to include the correct namespace for AppDbContex
using Microsoft.AspNetCore.Mvc;

namespace Book
{
    public class Books
    {
        internal static AppDbContex.Books newBook;
        internal static ActionResult<Books> book;
        internal static ActionResult<List<Books>> books;

        public static int Count { get; internal set; }
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public bool Eliminated { get; set; }
        public int AuthorId { get; set; }


        public static explicit operator Books(AppDbContex.Books v)
        {

            return new Books
            {
                Id = v.Id,
                ISBN = v.ISBN,
                BookName = v.BookName,
                AuthorName = v.AuthorName,
                Price = v.Price,
                Eliminated = v.Eliminated,
                AuthorId = v.AuthorId
            };
        }
    }
}
