using MediatR;

namespace VideoAlbum.Application.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest
    {
        public int Id { get; set; }
    }
}
