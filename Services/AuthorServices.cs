
using authors;
using System.Collections.Generic;
using System.Threading.Tasks;
using IAuthorServices;
using IAuthorRepositorys;
using AuthorD;
using AuthorRepositorys;
using AutoMapper;
using MessageHelper;

namespace AuthorServices
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<MessangingHelper<List<AuthorDTO>>> GetAuthorsAsync()
        {
            var response = new MessangingHelper<List<AuthorDTO>>();
            string errorMessage = "Error occurred while obtaining data";

            var authors = await _authorRepository.GetAuthorsAsync();

            if (authors == null)
            {
                response.Success = false;
                response.Message = errorMessage;
                return response;
            }

            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);

            response.Obj = authorsDTO;
            response.Success = true;
            return response;
        }

        public async Task<MessangingHelper<AuthorDTO>> GetAuthorAsync(int id)
        {
            var response = new MessangingHelper<AuthorDTO>();
            string notFoundMessage = "Author not found.";
            string foundMessage = "Author found.";

            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
            {
                response.Success = false;
                response.Message = notFoundMessage;
                return response;
            }

            var authorDTO = _mapper.Map<AuthorDTO>(author);

            response.Obj = authorDTO;
            response.Success = true;
            response.Message = foundMessage;
            return response;
        }

    }
}

