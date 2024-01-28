using Author_Books;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Author_BookRepositorys;
using Author_BookControllers;
using BookRepositorys;
using authors;
using MessageHelper;
using Author_Book1;
using AuthorRepositorys;
using Book;
using Author_BookD;

namespace Author_BookServices
{
    public class Author_BookService
    {
        private readonly Author_BookRepository _author_BookRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly BookRepository _bookRepository;
        private readonly IMapper _mapper;

        public Author_BookService(Author_BookRepository author_BookRepository, AuthorRepository authorRepository, BookRepository bookRepository, IMapper mapper)
        {
            _author_BookRepository = author_BookRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public MessangingHelper<Author_Book1.Author_Book> PostRelationship([FromBody] Author_Book1.Author_Book author_Book)
        {
            MessangingHelper<Author_Book1.Author_Book> response = new();


            var mappedRelationship = _mapper.Map<Author>(author_Book);
            var newRelationship = _author_BookRepository.PostRelationship(mappedRelationship);
            response.Message = "Relação livro e autor criada com sucesso";
            response.Obj = _mapper.Map<Author_Book1.Author_Book>(newRelationship);
            response.Success = true;
            return response;
        }

        internal MessangingHelper<Author_bookDTO> PostRelationship(Author_bookDTO author_BookDTO)
        {
            throw new NotImplementedException();
        }
    }
}