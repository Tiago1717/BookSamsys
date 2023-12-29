namespace BookD
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }

    public class AddBookDTO
    {
        public string Isbn { get; internal set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}