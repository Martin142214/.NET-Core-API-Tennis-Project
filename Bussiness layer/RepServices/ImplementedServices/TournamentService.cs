using AutoMapper;
using Bussiness_layer.Models.AddedModels;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;
using Bussiness_layer.Repositories.Interfaces;
using Bussiness_layer.RepServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities.AddedModels;

namespace Bussiness_layer.RepServices.ImplementedServices
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _repository;
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(TournamentCreateModel model)
        {
            var obj = _mapper.Map<Tournament>(model);          
            await _repository.CreateAndSaveAsync(obj);          

        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAndSaveAsync(id);
        }

        public List<TournamentModel> GetAll(Expression<Func<TournamentModel, bool>> filter = null)
        {
            var repFilter = _mapper.Map<Expression<Func<Tournament, bool>>>(filter);

            var result = _repository.GetAll(repFilter);
            var a = _mapper.Map<List<TournamentModel>>(result);

            return a;
        }

        public TournamentModel GetById(Guid id)
        {
            var result = _repository.GetById(id);
            return _mapper.Map<TournamentModel>(result);
        }

        public async Task Update(TournamentEditModel model)
        {
            var obj = _mapper.Map<Tournament>(model);
            await _repository.UpdateAndSaveAsync(obj);
        }
    }
}
