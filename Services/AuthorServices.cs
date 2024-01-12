
using authors;
using System.Collections.Generic;
using System.Threading.Tasks;
using IAuthorServices;
using IAuthorRepositorys;
using AuthorD;
using AuthorRepositorys;
using AutoMapper;
using MessageHelper;
using AppDB;
using System.Data.Entity;

namespace AuthorServices
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private object _appDbContext;

        public AuthorService(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }


        public async Task<MessangingHelper<List<AuthorDTO>>> GetAuthors()
        {
            var response = new MessangingHelper<List<AuthorDTO>>();
            string errorMessage = "Error occurred while obtaining authors";

            var authors = await _appDbContext.Authors.ToListAsync();

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
                _appDbContext.Authors.Add(author);
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

        public async Task<MessangingHelper<AuthorDTO>> RemoveAuthor(int id)
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

        public async Task<MessangingHelper<AuthorDTO>> EditAuthor(int id, AuthorDTO authorDTO)
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
                object value = await _appDbContext.SaveChangesAsync();

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

    }
}

