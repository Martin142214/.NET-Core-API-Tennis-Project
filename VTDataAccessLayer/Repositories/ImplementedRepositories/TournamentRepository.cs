using Bussiness_layer.Repositories.ImplementedRepositories;
using Bussiness_layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTDataAccessLayer.Entities.AddedModels;

namespace VTDataAccessLayer.Repositories.ImplementedRepositories
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(VTDatabaseContext context) : base(context)
        {

        }
        public Tournament GetAllPlayersOfTournament(Guid id)
        {
            var result = DbSet.Include(u => u.PlayersTournament)
                .ThenInclude(bu => bu.Player)
                .FirstOrDefault(x => x.ID == id);

            return result;
        }
    }
}
