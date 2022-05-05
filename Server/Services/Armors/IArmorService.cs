using RPGCharacterBuilderWebApp1.Shared.Models.Armor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Armors
{
    public interface IArmorService
    {
        Task<IEnumerable<ArmorListItem>> GetAllArmorAsync();
        Task<bool> CreateArmorAsync(ArmorCreate model);
        Task<ArmorDetail> GetArmorByIdAsync(int armorId);
        Task<bool> UpdateArmorAsync(ArmorEdit model);
        Task<bool> DeleteArmorAsync(int armorId);
    }
}
