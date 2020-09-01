using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAlbum.Application.AlbumTypes.Queries.FetchAlbumTypes
{
    public class FetchAlbumTypesResult
    {
        public List<FetchAlbumTypeResult> AlbumTypes { get; set; }
    }

    public class FetchAlbumTypeResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
