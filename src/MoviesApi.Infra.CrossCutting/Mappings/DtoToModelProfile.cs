using AutoMapper;
using MoviesApi.Domain.DTOs.Movies;
using MoviesApi.Domain.DTOs.MovieViewer;
using MoviesApi.Domain.DTOs.Viewers;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Viewer, ViewerDTO>().ReverseMap();
            CreateMap<Viewer, ViewerDetailsDTO>().ReverseMap();
            CreateMap<MovieViewer, MovieViewerDTO>().ReverseMap();
        }
    }
}
