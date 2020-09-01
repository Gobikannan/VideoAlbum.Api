using AutoMapper;
using Moq;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Commands.AddNewAlbum
{
    public class AddNewAlbumCommandHandlerTests
    {
        [Fact]
        public async void AddNewAlbumCommand_ShouldUpdatedOnDatabase()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IAlbumRepository>();

            var command = new AddNewAlbumCommand
            {
                Artist  = "test",
                Label = "hello",
                Name = "Robot",
                Stock = 1,
                TypeId = 1

            };
            var album = new Album
            {
                Artist = "test",
                Label = "hello",
                Name = "Robot",
                Stock = 1,
                TypeId = 1
            };
            mapper.Setup(x => x.Map<Album>(command)).Returns(album);
            albumRepository.Setup(x => x.AddNewAlbum(album)).Returns(Task.CompletedTask);
            var handler = new AddNewAlbumHandler(albumRepository.Object, mapper.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.AddNewAlbum(album));
        }
    }
}
