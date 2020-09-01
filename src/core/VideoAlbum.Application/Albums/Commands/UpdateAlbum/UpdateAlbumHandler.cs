using AutoMapper;
using MediatR;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Commands.AddNewAlbum
{
    public class UpdateAlbumHandler : IRequestHandler<UpdateAlbumCommand>
    {
        private readonly IAlbumRepository albumsEntityRepo;
        private readonly IMapper mapper;

        public UpdateAlbumHandler(IAlbumRepository albumsEntityRepo, IMapper mapper)
        {
            this.albumsEntityRepo = albumsEntityRepo;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = this.mapper.Map<Album>(request);
            await this.albumsEntityRepo.UpdateAlbum(album);

            return Unit.Value;
        }
    }
}
