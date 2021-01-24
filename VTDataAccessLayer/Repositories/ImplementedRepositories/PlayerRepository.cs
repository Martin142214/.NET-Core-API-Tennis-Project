using Bussiness_layer.Models.ManyToManyModel;
using Bussiness_layer.Repositories.ImplementedRepositories;
using Bussiness_layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTDataAccessLayer.Entities;
using VTDataAccessLayer.Entities.AddedModels;

namespace VTDataAccessLayer.Repositories.ImplementedRepositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        private ITournamentRepository _repository;
        public PlayerRepository(VTDatabaseContext context, ITournamentRepository repository) : base(context)
        {
            _repository = repository;
        }

        public IEnumerable<Player> GetAllPlayersTakingPartInTournament(Expression<Func<Player, bool>> filter = null)
        {
            if (filter != null)
            {
                DbSet.Where(filter).Include(x => x.PlayersTournament).ThenInclude(y=>y.Tournament);
            }
            return DbSet.Include(x => x.PlayersTournament).ThenInclude(y=>y.Tournament);
        }

        public Player GetPlayer(Guid id)
        {
            var result = DbSet.Include(x => x.PlayersTournament).ThenInclude(y => y.Player)
                .FirstOrDefault(x => x.ID == id);

            return result;
        }

        public async Task TakePartInTournament(Guid playerId, Guid tournamentId)
        {
            var player = GetById(playerId);
            var tournament = _repository.GetById(tournamentId);
            var tournamentPlayed = new PlayersTournaments { TournamentId = tournament.ID };
            player.TournamentsPlayed += 1;
            player.RankListPoints += tournament.Award;
            player.PlayersTournament.Add(tournamentPlayed);

            await SaveChangesAsync();
        }

        public async Task QuitTournament(Guid playerId, Guid tournamentId)
        {
            var player = GetById(playerId);
            var tournament = _repository.GetById(tournamentId);
            var quitedTournament = tournament.PlayersTournament.FirstOrDefault(x => x.TournamentId == tournamentId);
            player.PlayersTournament.Remove(quitedTournament);
            player.RankListPoints -= 1000;
            player.TournamentsPlayed -= 1;

            await SaveChangesAsync();
        }

        public Player GetUserByName(string name)
        {
            var result = DbSet.FirstOrDefault(u => u.Name == name);
            return result;
        }

    }
}
