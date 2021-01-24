using Bussiness_layer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities;

namespace Bussiness_layer.RepServices.Interfaces
{
    interface IBaseService<TModel, TEntity> 
        where TModel : BaseModel
        where TEntity : BaseEntity  //защо изобщо го наследяваме
    {
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null);

        //защо тук е TModel, а не TEntity
        TModel GetById(Guid id);
        Task CreateAsync(TModel model);

        //защо тук е TModel, а не TEntity
        Task UpdateAsync(TModel entity);

        Task DeleteAsync(Guid id);
    }
}
