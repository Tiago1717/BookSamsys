
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Infrastructure.DTOs;
using WebAPI.Infrastructure.Services;
using Book;
using IBookRepository;
using IBookService;

namespace BookService;
public class BookService : IBookService
{
    public class BookService : IBookService
    {
        private readonly AppDBContext _appDbContext;
        private readonly IMapper _mapper;

        public BookService(AppDBContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<MessagingHelper<List<BookDTO>>> GetBooksAsync()
        {
            var response = new MessagingHelper<List<BookDTO>>();
            string errorMessage = "Error occurred while obtaining data";

            var checkBooks = await _appDbContext.Books.Include(x => x.Author).ToListAsync();

            if (checkBooks == null)
            {
                response.Success = false;
                response.Message = errorMessage;
                return response;
            }

            public async Task<MessagingHelper<List<BookDTO>>> GetBookAsync(string isbn)
            {
                var response = new MessagingHelper<List<BookDTO>>();
                string notFoundMessage = "Book not found.";
                string foundMessage = "Book found.";

                var book = await _appDbContext.Books.Include(x => x.Author).SingleOrDefaultAsync(x => x.Isbn == isbn);

                var bookDetailsDTO = _mapper.Map<BookDTO>(book);


                async Task<Book> IBookService.CreateBookAsync(Book book)
    {
        await _BookRepository.AddAsync(book);
        await _BookRepository.SaveChangesAsync();
        return book;
    }

    async Task IBookService.DeleteBookAsync(int id)
    {
        var book = await _BookRepository.FindAsync(id);
        if (book != null)
        {
            _BookRepository.Remove(book);
            await _BookRepository.SaveChangesAsync();
        }
    }
    async Task<Book> IBookService.GetBookAsync(int id)
    {
        return await _BookRepository.FindAsync(id);
    }

    async Task<IEnumerable<Book>> IBookService.GetBooksAsync()
    {
        return await _BookRepository.ToListAsync();
    }

    async Task IBookService.UpdateBookAsync(int id, Book book)
    {
        var existing = await _BookRepository.FindAsync(id);
        if (existing != null)
        {
            existing.name = book.name;
            existing.Author = book.Author;
            existing.Id = book.id;
            await _BookRepository.SaveChangesAsync();
        }
    }
}
