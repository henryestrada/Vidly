using AutoMapper;
using Vidly.DTO;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Domain to Dto

        CreateMap<Movie, MovieFormViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));

        CreateMap<Customer, CustomerDto>();

        CreateMap<Movie, MovieDto>();

        CreateMap<Movie, AddMovieRequest>();

        CreateMap<MembershipType, MembershipTypeDto>();

        CreateMap<Genre, GenreDto>();

        #endregion

        #region Dto to Domain

        CreateMap<MovieFormViewModel, Movie>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock));

        CreateMap<CustomerDto, Customer>();

        CreateMap<MovieDto, Movie>();

        CreateMap<AddMovieRequest, Movie>();

        CreateMap<MembershipTypeDto, MembershipType>();

        CreateMap<GenreDto, Genre>();

        #endregion
    }
}
