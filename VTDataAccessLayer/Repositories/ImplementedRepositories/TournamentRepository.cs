using Bussiness_layer.Repositories.ImplementedRepositories;
using Bussiness_layer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using VTDataAccessLayer.Entities.AddedModels;

namespace VTDataAccessLayer.Repositories.ImplementedRepositories
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(VTDatabaseContext context) : base(context)
        {

        }
    }
}
