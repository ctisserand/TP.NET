using ASP.Server.Database;
using ASP.Server.Dtos;
using ASP.Server.Models;
using AutoMapper;


namespace ASP.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Rajouter autant de ligne ici que vous avez de mapping Model <-> DTO
            // https://docs.automapper.org/en/latest/
            
            CreateMap<Genre, GenreDto>();
            CreateMap<Genre, GenreWithoutBooksDto>();
            
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorWithoutBooksDto>();
            
            CreateMap<Book, BookDto>();
            CreateMap<Book, BookWithoutContentDto>();
            CreateMap<Book, BookWithoutGenresDto>();
            CreateMap<Book, BookWithoutAuthorsDto>();
            CreateMap<Book, BookWithoutAuthorsAndGenresDto>();
            CreateMap<Book, BookWithoutAllDto>();
        }
    }
}