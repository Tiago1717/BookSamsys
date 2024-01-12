using authors;

namespace Book
{
    public class Books
    {
        public static int Count { get; internal set; }
        public int Id { get; set; }
        public required string ISBN { get; set; }
        public required string BookName { get; set; }
        public required string AuthorName { get; set; }
        public decimal Price { get; set; }
        public bool Eliminated { get; set; }
        public int AuthorId { get; set; }
    }
}