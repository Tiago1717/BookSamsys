namespace Author_BookD
{
    public class Author_bookDTO
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public DateTime RelationshipDate { get; set; }
        public required string PostRelationship { get; set; }
        public required string AuthorName { get; set; }
        public required string BookTitle { get; set; }
          
    }
}