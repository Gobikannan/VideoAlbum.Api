using MediatR;
using VideoAlbum.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumHandler : IRequestHandler<DeleteAlbumCommand>
    {
        private readonly IAlbumRepository albumsEntityRepo;

        public DeleteAlbumHandler(IAlbumRepository albumsEntityRepo)
        {
            this.albumsEntityRepo = albumsEntityRepo;
        }

        public async Task<Unit> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            await this.albumsEntityRepo.DeleteAlbum(request.Id);

            return Unit.Value;
        }
    }
}
