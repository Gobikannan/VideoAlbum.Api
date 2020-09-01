using Microsoft.AspNetCore.Mvc;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.DeleteAlbum;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Application.Albums.Queries.FetchAlbums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoAlbum.WebApi.Controllers
{
    /// <summary>
    /// ApiController for Album related api calls
    /// </summary>
    public class AlbumsController : ApiController
    {
        /// <summary>
        /// Fetch all available album types
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<FetchAlbumDetailByIdResult> FetchAlbum(int id)
        {
            var queryAlbumTypes = new FetchAlbumDetailByIdQuery { Id = id };
            var result = await Mediator.Send(queryAlbumTypes);
            return result;
        }

        /// <summary>
        /// Fetch all available album types
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IList<Application.Albums.Queries.FetchAlbumDetailResult>> FetchAllAlbums()
        {
            var queryAlbumTypes = new FetchAlbumsQuery();
            var result = await Mediator.Send(queryAlbumTypes);
            return result.Albums;
        }

        /// <summary>
        /// Adds new album
        /// </summary>
        /// <param name="newAlbumRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddNewAlbum([FromBody] AddNewAlbumCommand newAlbumRequest)
        {
            await Mediator.Send(newAlbumRequest);
            return Ok();
        }

        /// <summary>
        /// Updates existing album
        /// </summary>
        /// <param name="updateAlbumRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateAlbum([FromBody] UpdateAlbumCommand updateAlbumRequest)
        {
            await Mediator.Send(updateAlbumRequest);
            return Ok();
        }

        /// <summary>
        /// Deleted existing album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> UpdateAlbum(int id)
        {
            var request = new DeleteAlbumCommand { Id = id };
            await Mediator.Send(request);
            return Ok();
        }
    }
}
