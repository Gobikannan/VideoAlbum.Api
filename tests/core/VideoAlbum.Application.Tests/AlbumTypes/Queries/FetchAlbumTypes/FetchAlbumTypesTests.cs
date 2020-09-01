using AutoMapper;
using Moq;
using VideoAlbum.Application.AlbumTypes.Queries.FetchAlbumTypes;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.Tests.Albums.Queries.FetchAlbumDetail
{
   public class FetchAlbumTypesTests
    {
        [Fact]
        public async void FetchAlbumTypes_ShouldFetchAllAlbumTypes()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var albumRepository = new Mock<IGenericDataRepository<AlbumType>>();

            var command = new FetchAlbumTypeQuery();
            var album = new AlbumType
            {
                Name = "vinyl",
                Id = 1
            };
            mapper.Setup(x => x.Map<AlbumType>(command)).Returns(album);
            IReadOnlyList<AlbumType> output = (new List<AlbumType> { album }).AsReadOnly();
            albumRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(output));
            var handler = new FetchAlbumTypeHandler(albumRepository.Object, mapper.Object);

            //Act
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            albumRepository.Verify(albRep => albRep.GetAllAsync());
        }
    }
}
