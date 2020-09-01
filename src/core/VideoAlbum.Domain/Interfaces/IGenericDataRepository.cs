using VideoAlbum.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoAlbum.Domain.Interfaces
{
    public interface IGenericDataRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
