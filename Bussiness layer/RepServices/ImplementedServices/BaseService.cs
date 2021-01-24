using AutoMapper;
using Bussiness_layer.Models;
using Bussiness_layer.Repositories;
using Bussiness_layer.RepServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities;

namespace Bussiness_layer.RepServices
{
    //директно подадох параметри в интерфейса
    class BaseService : IBaseService<BaseModel, BaseEntity>
    {
        public IBaseRepository<BaseEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<BaseEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BaseModel model)
        {
            var obj = _mapper.Map<BaseEntity>(model);
            await _repository.CreateAndSaveAsync(obj);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAndSaveAsync(id);
        }
        
        public IEnumerable<BaseModel> GetAll(Expression<Func<BaseModel, bool>> filter = null)
        {
            var obj = _mapper.Map<Expression<Func<BaseEntity, bool>>>(filter);
            var result = _repository.GetAll(obj);
            return _mapper.Map<List<BaseModel>>(result); // защо List, а не IEnumerable            
        }

        public BaseModel GetById(Guid id)
        {
            var result = _repository.GetById(id);
            return _mapper.Map<BaseModel>(result);
        }

        public async Task UpdateAsync(BaseModel entity)
        {
            var obj = _mapper.Map<BaseEntity>(entity);
            await _repository.UpdateAndSaveAsync(obj);                     
        }
    }
}
