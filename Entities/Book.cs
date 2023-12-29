using authors;

namespace Book
{
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