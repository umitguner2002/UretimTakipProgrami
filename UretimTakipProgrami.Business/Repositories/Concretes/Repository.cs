using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly private ProductionDbContext _context;

        public Repository(ProductionDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {            
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable().Where(p => p.IsDeleted == false);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable().Where(p => p.IsDeleted == false);
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public T GetById(string id, bool tracking = true)
        {
            var query = Table.AsQueryable().Where(p => p.IsDeleted == false);
            if (!tracking)
                query = Table.AsNoTracking();
            return query.FirstOrDefault(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entityToRemove = Table.SingleOrDefault(p => p.Id == Guid.Parse(id));

            if (entityToRemove != null)
            {
                entityToRemove.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(string id)
        {
            var entityToRemove = Table.SingleOrDefault(p => p.Id == Guid.Parse(id));

            if (entityToRemove != null)
            {
                _context.Remove(entityToRemove);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public void Save() => _context.SaveChanges();
    }
}
