using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderWebApp1.Server.Services.MagicItems;
using RPGCharacterBuilderWebApp1.Shared.Models.MagicItem;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicItemsController : ControllerBase
    {
        private readonly IMagicItemService _magicItemService;

        public MagicItemsController(IMagicItemService magicItemService)
        {
            _magicItemService = magicItemService;
        }

        public async Task<IActionResult> Index()
        {
            var magicItems = await _magicItemService.GetAllMagicItemsAsync();
            return Ok(magicItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MagicItem(int id)
        {
            var magicItem = await _magicItemService.GetMagicItemByIdAsync(id);

            if (magicItem == null) return NotFound();

            return Ok(magicItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MagicItemCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _magicItemService.CreateMagicItemAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }
    }
}
