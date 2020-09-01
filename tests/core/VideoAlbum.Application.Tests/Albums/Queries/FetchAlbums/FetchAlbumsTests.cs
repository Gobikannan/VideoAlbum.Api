using AutoMapper;
using Moq;
using VideoAlbum.Application.Albums.Queries.FetchAlbums;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Queries.FetchAlbumDetail
{
   public class FetchAlbumsTests
    {
        [Fact]
        public async void FetchAlbumsQuery_ShouldFetchAllRecords()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IAlbumRepository>();

            var command = new FetchAlbumsQuery();
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
            IReadOnlyList<Album> output = (new List<Album> { album }).AsReadOnly();
            albumRepository.Setup(x => x.FetchAllAlbums()).Returns(Task.FromResult(output));
            var handler = new FetchAlbumsHandler(albumRepository.Object, mapper.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.FetchAllAlbums());
        }
    }
}
