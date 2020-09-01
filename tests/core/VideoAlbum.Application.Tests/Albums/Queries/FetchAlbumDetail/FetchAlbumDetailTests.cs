using AutoMapper;
using Moq;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Queries.FetchAlbumDetail
{
   public class FetchAlbumDetailTests
    {
        [Fact]
        public async void FetchAlbumDetailQuery_ShouldFetchParticularRecord()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IGenericDataRepository<Album>>();

            var command = new FetchAlbumDetailByIdQuery
            {
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
            albumRepository.Setup(x => x.GetByIdAsync(1)).Returns(Task.FromResult(album));
            var handler = new FetchAlbumDetailByIdHandler(albumRepository.Object, mapper.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.GetByIdAsync(1));
        }
    }
}
