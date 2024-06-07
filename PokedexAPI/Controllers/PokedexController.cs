using Microsoft.AspNetCore.Mvc;
using PokedexAPI.Data;

namespace PokedexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokedexController : ControllerBase
    {
        private readonly PokemonRepository _repository;

        public PokedexController()
        {
            _repository = new PokemonRepository();
        }

        [HttpGet("find_message")]
        public IActionResult FindMessage([FromQuery] string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("Please provide a number.");
            }

            var message = _repository.GetMessageByNumber(number);

            if (message == null)
            {
                return NotFound("Message not found.");
            }

            return Ok(message);
        }
    }
}
