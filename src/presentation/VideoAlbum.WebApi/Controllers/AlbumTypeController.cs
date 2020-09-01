using Microsoft.AspNetCore.Mvc;
using VideoAlbum.Application.AlbumTypes.Queries.FetchAlbumTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoAlbum.WebApi.Controllers
{
    /// <summary>
    /// ApiController for Album Type related api calls
    /// </summary>
    public class AlbumTypeController : ApiController
    {
        /// <summary>
        /// Fetch all available album types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<FetchAlbumTypeResult>> FetchAllAlbumTypes()
        {
            var queryAlbumTypes = new FetchAlbumTypeQuery();
            var result = await Mediator.Send(queryAlbumTypes);
            return result.AlbumTypes;
        }
    }
}
