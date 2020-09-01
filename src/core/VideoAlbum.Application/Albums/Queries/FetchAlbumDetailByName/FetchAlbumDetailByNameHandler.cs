using AutoMapper;
using MediatR;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName
{
    public class FetchAlbumDetailByNameHandler : IRequestHandler<FetchAlbumDetailByNameQuery, FetchAlbumDetailByNameResult>
    {
        private readonly IAlbumRepository albumsEntityRepo;
        private readonly IMapper mapper;

        public FetchAlbumDetailByNameHandler(IAlbumRepository albumsEntityRepo, IMapper mapper)
        {
            this.albumsEntityRepo = albumsEntityRepo;
            this.mapper = mapper;
        }

        public async Task<FetchAlbumDetailByNameResult> Handle(FetchAlbumDetailByNameQuery request, CancellationToken cancellationToken)
        {
            var response = await this.albumsEntityRepo.FetchAlbumDetailByName(request.Name);

            var result = this.mapper.Map<FetchAlbumDetailByNameResult>(response);
            return result;
        }
    }
}
