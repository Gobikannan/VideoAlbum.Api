using FluentValidation;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.DeleteAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailByName;
using System;
using System.Threading.Tasks;
using Xunit;

namespace VideoAlbum.Application.IntegrationTests.Album
{
    using static TestFixture;

    public class DeleteAlbumCommandTests : IClassFixture<TestFixture>
    {
        private async Task<AddNewAlbumCommand> CreateAlbumForDeleteTests()
        {
            var name = "ITestDeleteReq-" + DateTime.Now.ToString();
            var testAlbum = new AddNewAlbumCommand
            {
                Artist = "test",
                Label = "hello",
                Name = name,
                Stock = 1,
                TypeId = 1

            };
            await SendAsync(testAlbum);
            return testAlbum;
        }

        [Fact]
        public async Task ShouldDeleteAlbum()
        {
            var testAlbum = await CreateAlbumForDeleteTests();

            var existingItem = await SendAsync(new FetchAlbumDetailByNameQuery { Name = testAlbum.Name });

            var command = new DeleteAlbumCommand
            {
                Id = existingItem.Id

            };
            await SendAsync(command);

            var result = await SendAsync(new FetchAlbumDetailByIdQuery { Id = existingItem.Id });

            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldThrowErrorForInvalidId()
        {
            var command = new DeleteAlbumCommand
            {
                Id = 0
            };
            await Assert.ThrowsAsync<ValidationException>(() => SendAsync(command));
        }
    }
}
