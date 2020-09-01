using AutoMapper;
using MediatR;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Commands.AddNewAlbum
{
    public class AddNewAlbumHandler : IRequestHandler<AddNewAlbumCommand>
    {
        private readonly IAlbumRepository albumsEntityRepo;
        private readonly IMapper mapper;

        public AddNewAlbumHandler(IAlbumRepository albumsEntityRepo, IMapper mapper)
        {
            this.albumsEntityRepo = albumsEntityRepo;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(AddNewAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = this.mapper.Map<Album>(request);
            await this.albumsEntityRepo.AddNewAlbum(album);

            return Unit.Value;
        }
    }
}
