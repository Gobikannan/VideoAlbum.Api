using AutoMapper;
using MediatR;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById
{
    public class FetchAlbumDetailByIdHandler : IRequestHandler<FetchAlbumDetailByIdQuery, FetchAlbumDetailByIdResult>
    {
        private readonly IGenericDataRepository<Album> albumsEntityRepo;
        private readonly IMapper mapper;

        public FetchAlbumDetailByIdHandler(IGenericDataRepository<Album> albumsEntityRepo, IMapper mapper)
        {
            this.albumsEntityRepo = albumsEntityRepo;
            this.mapper = mapper;
        }

        public async Task<FetchAlbumDetailByIdResult> Handle(FetchAlbumDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await this.albumsEntityRepo.GetByIdAsync(request.Id);

            var result = this.mapper.Map<FetchAlbumDetailByIdResult>(response);
            return result;
        }
    }
}
