
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
    private readonly IBookRepository _BookRepository;

    public BookService(IBookRepository BookRepository)
    {
        _BookRepository = BookRepository;
    }

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
