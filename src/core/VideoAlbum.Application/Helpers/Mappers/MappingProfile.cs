using AutoMapper;
using Microsoft.Extensions.Configuration;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName;
using VideoAlbum.Application.AlbumTypes.Queries.FetchAlbumTypes;
using VideoAlbum.Domain.Entities;

namespace VideoAlbum.Application.Helpers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IConfiguration configuration)
        {
            CreateMap<AlbumType, FetchAlbumTypeResult>();
            CreateMap<Album, Albums.Queries.FetchAlbumDetailResult>();
            CreateMap<AddNewAlbumCommand, Album>();
            CreateMap<UpdateAlbumCommand, Album>();
            CreateMap<Album, FetchAlbumDetailByIdResult>();
            CreateMap<Album, FetchAlbumDetailByNameResult>();
        }
    }
}
