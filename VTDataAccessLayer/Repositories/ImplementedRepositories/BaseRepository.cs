using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer;
using VTDataAccessLayer.Entities;

namespace Bussiness_layer.Repositories.ImplementedRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public VTDatabaseContext AccessLayer { get; set; }
        public DbSet<T> DbSet { get; set; }
        public BaseRepository(VTDatabaseContext context)
        {
            AccessLayer = context;
            DbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task CreateAndSaveAsync(T entity)
        {
            Create(entity);
            await SaveChangesAsync();

        }

        public void Delete(Guid id)
        {
            var result  = GetById(id);
            DbSet.Remove(result);
        }

        public async Task DeleteAndSaveAsync(Guid id)
        {
            Delete(id);
            await SaveChangesAsync();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return AccessLayer.Set<T>().Where(filter);
            }
            return DbSet;
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public async Task SaveChangesAsync()
        {
            await AccessLayer.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            Update(entity);
            await SaveChangesAsync();
        }
    }
}
