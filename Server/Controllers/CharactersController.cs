using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderWebApp1.Server.Services.Characters;
using RPGCharacterBuilderWebApp1.Shared.Models.Character;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;

            if (userIdClaim == null) return null;

            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null) return false;

            _characterService.SetUserId(userId);
            return true;
        }

        [HttpGet]
        public async Task<List<CharacterListItem>> Index()
        {
            if (!SetUserIdInService()) return new List<CharacterListItem>();

            var characters = await _characterService.GetAllCharactersAsync();
            return characters.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Character(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null) return NotFound();

            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _characterService.CreateCharacterAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CharacterEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if (model == null || !ModelState.IsValid) return BadRequest();

            if (model.Id != id) return BadRequest();

            bool wasSuccessful = await _characterService.UpdateCharacterAsync(model);

            if (wasSuccessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null) return NotFound();

            bool wasSuccessful = await _characterService.DeleteCharacterAsync(id);

            if (!wasSuccessful) return BadRequest();

            return Ok();
        }

     }
}
