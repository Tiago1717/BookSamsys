
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
            var booksDTO = _mapper.Map<List<BookDTO>>(checkBooks);

            response.Obj = booksDTO;
            response.Success = true;
            return response;
        }
        
        response.Obj = new List<BookDTO> { bookDetailsDTO
    };
    response.Success = true;
            response.Message = foundMessage;
            return response;
        }

public async Task<MessagingHelper<List<AddBookDTO>>> AddBookAsync(AddBookDTO objBook)
{
    var response = new MessagingHelper<List<AddBookDTO>>();
    string errorMessage = "Error occurred while adding data";
    string isbnAlreadyExistsMessage = "Book with the provided ISBN already exists.";
    string authorNotExists = "Author provided does not exist.";
    string createdMessage = "Book created.";



    public async Task<MessagingHelper<List<BookDTO>>> GetBookAsync(string isbn)
        {
            var response = new MessagingHelper<List<BookDTO>>();
            string notFoundMessage = "Book not found.";
            string foundMessage = "Book found.";

            var book = await _appDbContext.Books.Include(x => x.Author).SingleOrDefaultAsync(x => x.Isbn == isbn);

            var bookDetailsDTO = _mapper.Map<BookDTO>(book);

            if (book == null)
            {
                response.Success = false;
                response.Message = notFoundMessage;
                return response;
            }

        public async Task<MessagingHelper<List<AddBookDTO>>> AddBookAsync(AddBookDTO objBook)
        {
            var response = new MessagingHelper<List<AddBookDTO>>();
            string errorMessage = "Error occurred while adding data";
            string isbnAlreadyExistsMessage = "Book with the provided ISBN already exists.";
            string authorNotExists = "Author provided does not exist.";
            string createdMessage = "Book created.";

            if (objBook.Isbn.Length != 13 || objBook.Price < 0 || objBook == null)
            {
                response.Success = false;
                response.Message = errorMessage;
                return response;
            }
            var checkIfBookExists = await _appDbContext.Books.FindAsync(objBook.Isbn);
            if (checkIfBookExists != null && checkIfBookExists.Isbn == objBook.Isbn)
            {
                response.Success = false;
                response.Message = isbnAlreadyExistsMessage;
                return response;
            }

            var checkIfAuthorExists = await _appDbContext.Authors.FindAsync(objBook.AuthorId);
            if (checkIfAuthorExists == null)
            {
                response.Success = false;
                response.Message = authorNotExists;
                return response;
                var book = _mapper.Map<Book>(objBook);

                _appDbContext.Books.Add(book);
                await _appDbContext.SaveChangesAsync();

                response.Obj = new List<AddBookDTO> { objBook };
                response.Success = true;
                response.Message = createdMessage;
                return response;
            }










            //
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
