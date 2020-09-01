using AutoMapper;
using Moq;
using VideoAlbum.Application.Albums.Commands.DeleteAlbum;
using VideoAlbum.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandlerTests
    {
        [Fact]
        public async void DeleteAlbumCommand_ShouldDeleteEntryOnDatabase()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IAlbumRepository>();

            var command = new DeleteAlbumCommand
            {
                Id = 1

            };
            albumRepository.Setup(x => x.DeleteAlbum(1)).Returns(Task.CompletedTask);
            var handler = new DeleteAlbumHandler(albumRepository.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.DeleteAlbum(1));
        }
    }
}
