using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderWebApp1.Server.Services.Armors;
using RPGCharacterBuilderWebApp1.Shared.Models.Armor;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorController : ControllerBase
    {
        private readonly IArmorService _armorService;

        public ArmorController(IArmorService armorService)
        {
            _armorService = armorService;
        }

        public async Task<IActionResult> Index()
        {
            var armors = await _armorService.GetAllArmorAsync();
            return Ok(armors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Armor(int id)
        {
            var armor = await _armorService.GetArmorByIdAsync(id);

            if (armor == null) return NotFound();

            return Ok(armor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArmorCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _armorService.CreateArmorAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }
    }
}
