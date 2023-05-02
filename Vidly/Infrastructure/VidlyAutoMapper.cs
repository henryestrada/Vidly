using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Infrastructure;

public class VidlyAutoMapper
{
    public static IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Movie, MovieFormViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));


        cfg.CreateMap<MovieFormViewModel, Movie>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));
    }).CreateMapper();
}
