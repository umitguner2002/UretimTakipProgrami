using System.Linq.Expressions;
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(string id, bool tracking = true);

        T GetById(string id, bool tracking = true);

        Task<bool> AddAsync(T model);

        Task<bool> RemoveAsync(string id);

        bool Delete(string id);

        bool Update(T model);

        Task<int> SaveAsync();

        void Save();
    }
}
