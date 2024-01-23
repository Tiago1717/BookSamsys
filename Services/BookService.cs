
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Book;
using IBookRepositorys;
using IBookServices;
using authors;
using Microsoft.AspNetCore.Mvc;
using Author_BookControllers;
using AuthorController;
using MessageHelper;
using AuthorD;
using BookD;
using AppDbcontext;
using StockSharp.Messages;
using MappingProfiles;
using Autofac.Core;

namespace BookService
{

    public class BooksService
    {
        private readonly IBookRepository _bookRepository;
        private object _appDbContext;
        private object _mapper;

        public BooksService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ActionResult<MessangingHelper<List<BookDTO>>>> GetBooksAsync()
        {
            var books = _bookRepository.GetAllBooksAsync();
            if (books == null || AppDbcontext.Books.Count == 0)
            {
                return new MessangingHelper<List<BookDTO>>
                {
                    Status = "No books found",
                    Data = null
                };
            }
            else
            {
                return new MessangingHelper<List<BookDTO>>
                {
                    Status = "Books retrieved successfully",
                    Data = books
                };
            }
        }

    public ActionResult<MessangingHelper<BookDTO>> GetBooksByIsbn(string isbn)
    {
        var book = _bookRepository.GetBookByIsbnAsync(isbn);
        if (book == null)
        {
            return new MessangingHelper<BookDTO>
            {
                Status = "Book not found",
                Data = null
            };
        }
        else
        {
            return new MessangingHelper<BookDTO>
            {
                Status = "Book retrieved successfully",
                Data = book
            };
        }
    }

    public async Task<ActionResult<MessangingHelper<BookDTO>>> PostBookAsync(BookDTO bookDTO, BookRepository bookRepository)
        {
            var book = bookRepository.AddBookAsync(bookDTO);
            if (book == null)
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book could not be added",
                    Data = null
                };
            }
            else
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book added successfully",
                    Data = book
                };
            }
        }

        public async Task<ActionResult<MessangingHelper<BookDTO>>> RemoveBook(string isbn)
        {
            var book = _bookRepository.DeleteBookAsync(isbn);
            if (book == null)
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book could not be deleted",
                    Data = null
                };
            }
            else
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book deleted successfully",
                    Data = book
                };
            }
        }

        public async Task<ActionResult<MessangingHelper<BookDTO>>> EditBook(string isbn, BookDTO books)
        {
            var book = _bookRepository.UpdateBookAsync(isbn, books);
            if (book == null)
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book could not be updated",
                    Data = null
                };
            }
            else
            {
                return new MessangingHelper<BookDTO>
                {
                    Status = "Book updated successfully",
                    Data = book
                };

            }

        }

        public async Task<ActionResult<MessangingHelper<BookDTO>>> PostBookAsync(BookDTO bookDTO)
        {
            var response = new MessangingHelper<BookDTO>();
            string errorMessage = "Error occurred while adding a book.";
            string createdMessage = "Book added successfully.";
           

            try
            {
                var book = _mapper.Map<Books>(bookDTO);
                await _bookRepository.AddBookAsync(book);

                response.Obj = _mapper.Map<BookDTO>(book);
                response.Success = true;
                response.Message = createdMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{errorMessage} Details: {ex.Message}";
            }

            return response;
        }

    }

}
