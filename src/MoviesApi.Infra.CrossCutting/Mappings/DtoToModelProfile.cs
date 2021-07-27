using AutoMapper;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
