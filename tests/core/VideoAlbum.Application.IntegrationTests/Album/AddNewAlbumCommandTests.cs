using FluentValidation;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName;
using System;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.IntegrationTests.Album
{
    using static TestFixture;

    public class AddNewAlbumCommandTests : IClassFixture<TestFixture>
    {
        [Fact]
        public async Task ShouldCreateNewAlbum()
        {
            var name = "ITest-" + DateTime.Now.ToString();
            var command = new AddNewAlbumCommand
            {
                Artist = "test",
                Label = "hello",
                Name = name,
                Stock = 1,
                TypeId = 1

            };
            await SendAsync(command);

            var result = await SendAsync(new FetchAlbumDetailByNameQuery { Name = name });
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
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
            var command = new AddNewAlbumCommand
            {
                Artist = artist,
                Label = label,
                Name = name,
                Stock = stock,
                TypeId = typeId

            };
            await Assert.ThrowsAsync<ValidationException>(() => SendAsync(command));
        }
    }
}
