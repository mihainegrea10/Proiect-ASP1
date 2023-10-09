using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models.Base;

namespace Proiect_ASP1.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(Context context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable() 
        {
            return _table.AsNoTracking().AsQueryable();
        }
        public void Create (TEntity entity)
        {
            _table.Add(entity);
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);

        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }
        public void Update(TEntity entity)
        {
            _table.Update(entity);

        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        public TEntity FindById(Guid id)
        {
            return _table.Find(id);
        }
        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }
        public bool Save()
        {
            return _context.SaveChanges()>0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
