
using Proiect_ASP.Models.Base;

namespace Proiect_ASP1.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllAsQueryable();

        void Create (TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        bool Save();
        Task<bool> SaveAsync();

    }
}
