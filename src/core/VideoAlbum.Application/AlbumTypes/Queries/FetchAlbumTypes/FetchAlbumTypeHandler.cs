using AutoMapper;
using MediatR;
using VideoAlbum.Domain.Entities;
using VideoAlbum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoAlbum.Application.AlbumTypes.Queries.FetchAlbumTypes
{
    public class FetchAlbumTypeHandler : IRequestHandler<FetchAlbumTypeQuery, FetchAlbumTypesResult>
    {
        private readonly IGenericDataRepository<AlbumType> albumTypesEntityRepo;
        private readonly IMapper mapper;

        public FetchAlbumTypeHandler(IGenericDataRepository<AlbumType> albumTypesEntityRepo, IMapper mapper)
        {
            this.albumTypesEntityRepo = albumTypesEntityRepo;
            this.mapper = mapper;
        }

        public async Task<FetchAlbumTypesResult> Handle(FetchAlbumTypeQuery request, CancellationToken cancellationToken)
        {
            var response = await this.albumTypesEntityRepo.GetAllAsync();

            var result = new FetchAlbumTypesResult();
            result.AlbumTypes = response.Select(x => this.mapper.Map<FetchAlbumTypeResult>(x)).ToList();
            return result;
        }
    }
}
