using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TennisStats.Application.Interfaces;

namespace TennisStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var players = _playerService.GetAll();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var player = _playerService.GetById(id);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            var isDeleted = _playerService.DeleteById(id);
            if (isDeleted)
            {
                return Ok(new { message = "The player has been deleted" });
            }

            return BadRequest(new { message = "This player does not exist" });
        }
    }
}
