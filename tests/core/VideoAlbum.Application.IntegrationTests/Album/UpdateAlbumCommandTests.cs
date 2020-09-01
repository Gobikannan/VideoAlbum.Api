using FluentValidation;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName;
using System;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.IntegrationTests.Album
{
    using static TestFixture;

    public class UpdateAlbumCommandTests : IClassFixture<TestFixture>
    {
        AddNewAlbumCommand testAlbum;
        public UpdateAlbumCommandTests()
        {
            CreateAlbumForUpdateTests().Wait();
        }

        private async Task CreateAlbumForUpdateTests()
        {
            var name = "ITestUpdateReq-" + DateTime.Now.ToString();
            testAlbum = new AddNewAlbumCommand
            {
                Artist = "test",
                Label = "hello",
                Name = name,
                Stock = 10,
                TypeId = 2

            };
            await SendAsync(testAlbum);
        }

        [Fact]
        public async Task ShouldUpdateAlbum()
        {
            var existingItem = await SendAsync(new FetchAlbumDetailByNameQuery { Name = testAlbum.Name });

            var command = new UpdateAlbumCommand
            {
                Artist = "ArtistUpdated",
                Label = "LabelUpdated",
                Name = "ITestUpdatedAlbum-" + DateTime.Now.ToString(),
                Stock = 10,
                TypeId = 2,
                Id = existingItem.Id

            };
            await SendAsync(command);

            var result = await SendAsync(new FetchAlbumDetailByIdQuery { Id = existingItem.Id });

            Assert.NotNull(result);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Label, result.Label);
            Assert.Equal(command.Stock, result.Stock);
            Assert.Equal(command.TypeId, result.TypeId);
            Assert.Equal(command.Artist, result.Artist);
        }

        [Theory]
        [InlineData("", "Hello Label", "Hello Artist", 1, 1)]
        [InlineData("Hello Name", "", "Hello Artist", 1, 1)]
        [InlineData("Hello Name", "Hello Label", "", 1, 1)]
        [InlineData("Hello Name", "Hello Label", "Hello Artist", 0, 1)]
        [InlineData("Hello Name", "Hello Label", "Hello Artist", 1, -1)]
        public async Task ShouldThrowErrorForBadRequest(string name, string label, string artist, int typeId, int stock)
        {
            var existingItem = await SendAsync(new FetchAlbumDetailByNameQuery { Name = testAlbum.Name });
            var command = new UpdateAlbumCommand
            {
                Artist = artist,
                Label = label,
                Name = name,
                Stock = stock,
                TypeId = typeId,
                Id = existingItem.Id

            };
            await Assert.ThrowsAsync<ValidationException>(() => SendAsync(command));

            var result = await SendAsync(new FetchAlbumDetailByIdQuery { Id = existingItem.Id });

            Assert.NotNull(result);
            Assert.NotEqual(command.Name, result.Name);
            Assert.NotEqual(command.Label, result.Label);
            Assert.NotEqual(command.Stock, result.Stock);
            Assert.NotEqual(command.TypeId, result.TypeId);
            Assert.NotEqual(command.Artist, result.Artist);
        }

        [Fact]
        public async Task ShouldThrowErrorForInvalidId()
        {
            var command = new UpdateAlbumCommand
            {
                Artist = "Artist",
                Label = "Label",
                Name = "name",
                Stock = 0,
                TypeId = 1,
                Id = 0
            };
            await Assert.ThrowsAsync<ValidationException>(() => SendAsync(command));
        }
    }
}
