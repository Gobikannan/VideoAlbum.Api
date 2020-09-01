using AutoMapper;
using Moq;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Commands.AddNewAlbum
{
    public class UpdateAlbumCommandHandlerTests
    {
        [Fact]
        public async void UpdateAlbumCommand_ShouldUpdateEntryInDatabase()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IAlbumRepository>();

            var command = new UpdateAlbumCommand
            {
                Artist  = "test",
                Label = "hello",
                Name = "Robot",
                Stock = 1,
                TypeId = 1,
                Id = 1

            };
            var album = new Album
            {
                Artist = "test",
                Label = "hello",
                Name = "Robot",
                Stock = 1,
                TypeId = 1,
                Id = 1
            };
            mapper.Setup(x => x.Map<Album>(command)).Returns(album);
            albumRepository.Setup(x => x.UpdateAlbum(album)).Returns(Task.CompletedTask);
            var handler = new UpdateAlbumHandler(albumRepository.Object, mapper.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.UpdateAlbum(album));
        }
    }
}
