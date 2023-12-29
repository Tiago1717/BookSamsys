using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Book;
using authors;
using BookRepositorys;
using Author_Books;

namespace Author_BookRepositorys
{
    public class Author_BookRepository
    {
        private readonly BookContext _context;

        public Author_BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Author_Books.Author_Book> PostRelationship(Author_Books.Author_Book author_Book)
        {
            await _context.AddAsync(author_Book);
            await _context.SaveChangesAsync();
            return author_Book;
        }

        public async Task<List<Author_Books.Author_Book>> GetRelationship()
        {
            var list = _context.Author_Books.ToList();
            return list;
        }

    }
}