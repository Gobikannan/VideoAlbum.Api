using Microsoft.AspNetCore.Mvc;
using VideoAlbum.Application.Albums.Commands.AddNewAlbum;
using VideoAlbum.Application.Albums.Commands.DeleteAlbum;
using VideoAlbum.Application.Albums.Commands.UpdateAlbum;
using VideoAlbum.Application.Albums.Queries.FetchAlbumDetailById;
using VideoAlbum.Application.Albums.Queries.FetchAlbums;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace VideoAlbum.WebApi.Controllers
{
    /// <summary>
    /// ApiController for Album related api calls
    /// </summary>
    public class AlbumsController : ApiController
    {
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public AlbumsController(IMapper mapper)
        {
            this.mapper = mapper;
        }
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
        /// Updates existing album
        /// </summary>
        /// <param name="updateAlbumRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> CreateOrUpdateAlbum([FromBody] UpdateAlbumCommand updateAlbumRequest)
        {
            if (updateAlbumRequest.Id > 0)
            {
                await Mediator.Send(updateAlbumRequest);
            } else
            {
                var album = this.mapper.Map<AddNewAlbumCommand>(updateAlbumRequest);
                await Mediator.Send(album);
            }
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
