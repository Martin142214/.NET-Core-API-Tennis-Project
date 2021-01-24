using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities;

namespace Bussiness_layer.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Guid id);
        Task SaveChangesAsync();
        void Create(T entity);
        Task CreateAndSaveAsync(T entity);
        void Update(T entity);
        Task UpdateAndSaveAsync(T entity);
        void Delete(Guid id);
        Task DeleteAndSaveAsync(Guid id);
    }
}
