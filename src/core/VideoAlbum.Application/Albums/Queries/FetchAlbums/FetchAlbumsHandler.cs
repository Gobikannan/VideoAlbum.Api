using AutoMapper;
using MediatR;
using VideoAlbum.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Queries.FetchAlbums
{
    public class FetchAlbumsHandler : IRequestHandler<FetchAlbumsQuery, FetchAlbumsResult>
    {
        private readonly IAlbumRepository albumsEntityRepo;
        private readonly IMapper mapper;

        public FetchAlbumsHandler(IAlbumRepository albumsEntityRepo, IMapper mapper)
        {
            this.albumsEntityRepo = albumsEntityRepo;
            this.mapper = mapper;
        }

        public async Task<FetchAlbumsResult> Handle(FetchAlbumsQuery request, CancellationToken cancellationToken)
        {
            var response = await this.albumsEntityRepo.FetchAllAlbums();

            var result = new FetchAlbumsResult
            {
                Albums = response.Select(x => this.mapper.Map<FetchAlbumDetailResult>(x)).ToList()
            };
            return result;
        }
    }
}
