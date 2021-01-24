using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness_layer.Models;
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
    public class PlayersController : ControllerBase
    {
        private IPlayerService _playerService;
        private ITournamentService _tournamentService;

        public PlayersController(IPlayerService playerService, ITournamentService tournamentService)
        {
            _playerService = playerService;
            _tournamentService = tournamentService;
        }
        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var result = _playerService.players();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public IActionResult GetPlayerById(Guid id)
        {
            var result = _playerService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Create(PlayerCreateModel model)
        {
            await _playerService.Create(model);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Update(PlayerEditModel model)
        {
            await _playerService.Update(model);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = PlayerRolesConst.MainPlayer)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _playerService.Delete(id);
            return Ok();
        }

        [HttpGet("{playerId}/tournaments")]
        public IActionResult ShowTournamentsPlayed(Guid playerId)
        {
            var player = _playerService.GetById(playerId);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player.tournaments);
        }

        [HttpPost("{playerId}/tournaments/{tournamentId}")]
        public async Task<IActionResult> TakePartInTournament(Guid playerId, Guid tournamentId)
        {
            var player = _playerService.GetById(playerId);
            var tournament = _tournamentService.GetById(tournamentId);

            if (player == null || tournament == null)
            {
                return NotFound("Player or tournament is not found");
            }

            if (player.tournaments.Any(t => t.Id == tournamentId))
            {
                return BadRequest();
            }

            player.tournaments.Add(tournament);
            tournament.players.Add(player);

            await _playerService.TakePartInTournament(playerId, tournamentId);

            return Ok(player.tournaments);
        }

        [HttpDelete("{playerId}/tournaments/{tournamentId}")]
        public async Task<IActionResult> QuitTournament(Guid playerId, Guid tournamentId)
        {
            var player = _playerService.GetById(playerId);
            var tournament = _tournamentService.GetById(tournamentId);

            if (player == null || tournament == null)
            {
                return NotFound("Player or tournament is not found");
            }

            if (player.tournaments.Any(b => b.Id == tournamentId))
            {
                return BadRequest();
            }

            player.tournaments.Remove(tournament);
            tournament.players.Remove(player);

            await _playerService.QuitTournament(playerId, tournamentId);

            return Ok();
        }
    }
}