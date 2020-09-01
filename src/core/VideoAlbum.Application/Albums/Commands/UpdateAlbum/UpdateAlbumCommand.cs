using MediatR;
using System.ComponentModel.DataAnnotations;

namespace VideoAlbum.Application.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : AlbumDetail, IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
