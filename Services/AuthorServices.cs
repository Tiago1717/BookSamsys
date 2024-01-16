
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
using DbContex;
using System.Data.Entity;

namespace AuthorServices
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private object AppDbContext;

        public AuthorService(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }


        public MessangingHelper<List<AuthorDTO>> GetAuthors()
        {
            var response = new MessangingHelper<List<AuthorDTO>>();
            string errorMessage = "Error occurred while obtaining authors";

            var authors = AppDB.AppDbContext.ToListAsync();

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

            var author = await AppDbContext.Authors.FindAsync(id);

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
                AppDbContext.Authors.Add(author);
                object value = await AppDbContext.SaveChangesAsync();

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

        public async Task<MessangingHelper<AuthorDTO>> RemoveAuthor(int id, AppDBContext appDBContext, AppDBContext appDBContext)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while removing an author.";
            string notFoundMessage = "Author not found.";
            string deletedMessage = "Author deleted.";

            try
            {
                object authors = AppDbContext.Authors;
                var author = await authors.FindAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AppDB.Author> entityEntry = AppDB.AppDbContext.authors.Remove(author);
                await AppDbContext.SaveChangesAsync();

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

        public async Task<MessangingHelper<AuthorDTO>> EditAuthor(int id, AuthorDTO authorDTO, AppDBContext appDBContext, AppDBContext appDBContext)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string errorMessage = "Error occurred while updating an author.";
            string notFoundMessage = "Author not found.";
            string updatedMessage = "Author updated.";

            try
            {
                var author = AppDbContext.Authors.FindAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = notFoundMessage;
                    return response;
                }

                _mapper.Map(authorDTO, author);

                AppDB.AppDbContext.Entry(author).State = EntityState.Modified;
                object value = await AppDbContext.SaveChangesAsync();

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

