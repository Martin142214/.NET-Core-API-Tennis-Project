using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness_layer.Models.AddedModels;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.EditModels;
using Bussiness_layer.RepServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTDataAccessLayer.UserRoles;

namespace VirtualTennisApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TournamentsController : ControllerBase
    {
        private IPlayerService _playerService;
        private ITournamentService _tournamentService;

        public TournamentsController(IPlayerService playerService, ITournamentService tournamentService)
        {
            _playerService = playerService;
            _tournamentService = tournamentService;
        }

        [HttpGet]
        //[Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public IActionResult GetAll()
        {
            var result = _tournamentService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public IActionResult Get(Guid id)
        {
            var result = _tournamentService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Create(TournamentCreateModel model)
        {
            await _tournamentService.Create(model);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Update(TournamentEditModel model)
        {
            await _tournamentService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _tournamentService.GetById(id);

            if (result == null)
            {
                return BadRequest();
            }

            await _tournamentService.Delete(result.Id);
            return Ok();
        }

        [HttpGet("{tournamentId}/players")]
        public IActionResult GetAllPlayersOfTournament(Guid tournamentId)
        {
            var tournament = _tournamentService.GetAllPlayersOfTournament(tournamentId);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament.players);
        }
    }
}