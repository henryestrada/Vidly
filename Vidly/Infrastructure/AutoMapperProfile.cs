using AutoMapper;
using Vidly.DTO;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Movie, MovieFormViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));


        CreateMap<MovieFormViewModel, Movie>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));

        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();

        CreateMap<Movie, UpdateMovieRequest>();
        CreateMap<UpdateMovieRequest, Movie>();

        CreateMap<Movie, AddMovieRequest>();
        CreateMap<AddMovieRequest, Movie>();
    }
}
