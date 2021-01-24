using AutoMapper;
using Bussiness_layer.Models;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;
using Bussiness_layer.Models.LoginModels;
using Bussiness_layer.Models.ManyToManyModel;
using Bussiness_layer.Repositories.Interfaces;
using Bussiness_layer.RepServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities.AddedModels;

namespace Bussiness_layer.RepServices.ImplementedServices
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;
        private IMapper _mapper;
        public PlayerService(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(PlayerCreateModel model)
        {
            model.AuthenticationCode = AuthService.HashPassword(model.AuthenticationCode);
            var obj = _mapper.Map<Player>(model);
            await _repository.CreateAndSaveAsync(obj);

        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAndSaveAsync(id);          
        }

        public PlayerModel GetById(Guid id)
        {
            var result = _repository.GetById(id);
            return _mapper.Map<PlayerModel>(result);
        }

        public IEnumerable<PlayerModel> players(Expression<Func<PlayerModel, bool>> filter = null)
        {
            var obj = _mapper.Map<Expression<Func<Player, bool>>>(filter);
            var result = _repository.GetAll(obj);
            return _mapper.Map<IEnumerable<PlayerModel>>(result);
        }

        public async Task Update(PlayerEditModel model)
        {
            var obj = _mapper.Map<Player>(model);
            model.AuthenticationCode = AuthService.HashPassword(model.AuthenticationCode);
            await _repository.UpdateAndSaveAsync(obj);          
        }

        public PlayerAuthModel GetUserByName(string name)
        {
            var result = _repository.GetUserByName(name);

            return _mapper.Map<PlayerAuthModel>(result);
        }

        public async Task TakePartInTournament(Guid playerId, Guid tournamentId)
        {
            await _repository.TakePartInTournament(playerId, tournamentId);
        }
        public async Task QuitTournament(Guid playerId, Guid tournamentId)
        {
            await _repository.QuitTournament(playerId, tournamentId);
        }
    }
}
