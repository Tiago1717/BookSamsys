
using authors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IAuthorServices;
using IAuthorRepositorys;
using AuthorD;
using AuthorRepositorys;
using AutoMapper;
using MessageHelper;
using AppDbContex;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AuthorServices
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public AuthorService(AuthorRepository authorRepository, IMapper mapper, AppDbContext appDbContext)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public MessangingHelper<List<AuthorDTO>> GetAuthors()
        {
            var response = new MessangingHelper<List<AuthorDTO>>();
            string errorMessage = "Error occurred while obtaining authors";

            var authors = _appDbContext.Authors.ToList();

            if (authors == null)
            {
                response.Success = false;
                response.Message = errorMessage;
                return response;
            }

            var authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);

            response.Obj = authorDTOs;
            response.Success = true;
            return response;
        }

        public async Task<MessangingHelper<AuthorDTO>> GetAuthorById(int id)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string notFoundMessage = "Author not found.";

            var author = await _appDbContext.Authors.FindAsync(id);

            if (author == null)
            {
                response.Success = false;
                response.Message = notFoundMessage;
                return response;
            }

            var authorDTO = _mapper.Map<AuthorDTO>(author);

            response.Obj = authorDTO;
            response.Success = true;
            return response;
        }

        public async Task<MessangingHelper<AuthorDTO>> PostAuthorAsync(AuthorDTO authorDTO)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while adding an author.";
            string createdMessage = "Author created.";

            try
            {
                var author = _mapper.Map<Author>(authorDTO);
                var entityEntry = _appDbContext.Entry(author);
                entityEntry.State = EntityState.Added;
                await _appDbContext.SaveChangesAsync();

                response.Obj = _mapper.Map<AuthorDTO>(author);
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


        public async Task<MessangingHelper<AuthorDTO>> RemoveAuthor(int id, AppDbContex.AppDbContext _appDbContext)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while removing an author.";
            string notFoundMessage = "Author not found.";
            string deletedMessage = "Author deleted.";

            try
            {
                var author = await _appDbContext.Authors.FindAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                _appDbContext.Authors.Remove(author);
                await _appDbContext.SaveChangesAsync();

                response.Obj = _mapper.Map<AuthorDTO>(author);
                response.Success = true;
                response.Message = deletedMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{errorMessage} Details: {ex.Message}";
            }

            return response;
        }

        public async Task<MessangingHelper<AuthorDTO>> EditAuthor(int id, AuthorDTO authorDTO, AppDbContext _appDbContext)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while updating an author.";
            string notFoundMessage = "Author not found.";
            string updatedMessage = "Author updated.";

            try
            {
                var author = await _appDbContext.Authors.FindAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                _mapper.Map(authorDTO, author);

                _appDbContext.Entry(author).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();

                response.Obj = _mapper.Map<AuthorDTO>(author);
                response.Success = true;
                response.Message = updatedMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{errorMessage} Details: {ex.Message}";
            }

            return response;
        }

        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> EditAuthor(int id, AuthorDTO author, AppDbContext appDbContext1, AppDbContext appDbContext2)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while updating an author.";
            string notFoundMessage = "Author not found.";
            string updatedMessage = "Author updated.";

            try
            {
                var authorEntity = await appDbContext1.Authors.FindAsync(id);

                if (authorEntity == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                _mapper.Map(author, authorEntity);

                appDbContext1.Entry(authorEntity).State = EntityState.Modified;
                await appDbContext1.SaveChangesAsync();

                response.Obj = _mapper.Map<AuthorDTO>(authorEntity);
                response.Success = true;
                response.Message = updatedMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"{errorMessage} Details: {ex.Message}";
            }

            return response;
        }

        public async Task<ActionResult<MessangingHelper<AuthorDTO>>> RemoveAuthor(int id, AppDbContext appDbContext1, AppDbContext appDbContext2)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while removing an author.";
            string notFoundMessage = "Author not found.";
            string deletedMessage = "Author deleted.";

            try
            {
                var authorEntity = await appDbContext1.Authors.FindAsync(id);

                if (authorEntity == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                appDbContext1.Authors.Remove(authorEntity);
                await appDbContext1.SaveChangesAsync();

                response.Obj = _mapper.Map<AuthorDTO>(authorEntity);
                response.Success = true;
                response.Message = deletedMessage;
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


