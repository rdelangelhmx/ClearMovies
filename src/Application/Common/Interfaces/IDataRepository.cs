using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IDataRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(TEntity item);
        IEnumerable<TEntity> GetAllPaging(TEntity item, int? _PagNo, int? _RecordsPerPage);
        int GetAllRecords(TEntity item);

        Task<IEnumerable<TEntity>> GetAllAsync(TEntity item);
        Task<IEnumerable<TEntity>> GetAllPagingAsync(TEntity item, int? _PagNo, int? _RecordsPerPage);
        Task<int> GetAllRecordsAsync(TEntity item);
    }
}
