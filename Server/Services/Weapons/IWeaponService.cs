using RPGCharacterBuilderWebApp1.Shared.Models.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Weapons
{
    public interface IWeaponService
    {
        Task<IEnumerable<WeaponListItem>> GetAllWeaponsAsync();
        Task<bool> CreateWeaponAsync(WeaponCreate model);
        Task<WeaponDetail> GetWeaponByIdAsync(int weaponId);
        Task<bool> UpdateWeaponAsync(WeaponEdit model);
        Task<bool> DeleteWeaponAsync(int weaponId);
    }
}
