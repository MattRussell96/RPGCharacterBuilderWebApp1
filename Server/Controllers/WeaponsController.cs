using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderWebApp1.Server.Services.Weapons;
using RPGCharacterBuilderWebApp1.Shared.Models.Weapon;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponsController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        public async Task<IActionResult> Index()
        {
            var weapons = await _weaponService.GetAllWeaponsAsync();
            return Ok(weapons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Weapon(int id)
        {
            var weapon = await _weaponService.GetWeaponByIdAsync(id);

            if (weapon == null) return NotFound();

            return Ok(weapon);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeaponCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _weaponService.CreateWeaponAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }
    }
}
