namespace BookD
{
    public class BookDTO
    {
        public decimal Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }

    public class AddBookDTO
    {
        public string ISBN { get; set; }
        public string Isbn { get; internal set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}