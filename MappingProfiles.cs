namespace MappingProfiles
{
    using AutoMapper;
    using BookD;
    using AuthorD;
    using authors;
    using Book;
   

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Books, BookDTO>().ReverseMap();
            CreateMap<BookDTO, Books>();
            CreateMap<Books, BookDTO>();
        }

    }

}

