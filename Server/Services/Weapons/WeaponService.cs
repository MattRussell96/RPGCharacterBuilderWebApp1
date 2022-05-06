using Microsoft.EntityFrameworkCore;
using RPGCharacterBuilderWebApp1.Server.Data;
using RPGCharacterBuilderWebApp1.Server.Models;
using RPGCharacterBuilderWebApp1.Shared.Models.Weapon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Weapons
{
    public class WeaponService : IWeaponService
    {
        private readonly ApplicationDbContext _context;

        public WeaponService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateWeaponAsync(WeaponCreate model)
        {
            if (model == null) return false;

            var weaponEntity = new Weapon
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                DamageIncreasedBy = model.DamageIncreasedBy,
                MagicDamage = model.MagicDamage,
                Weight = model.Weight,
            };

            _context.Weapons.Add(weaponEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeleteWeaponAsync(int weaponId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<WeaponListItem>> GetAllWeaponsAsync()
        {
            var weaponQuery =
                _context
                .Weapons
                .Select(entity =>
                new WeaponListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Type = entity.Type,
                });

            return await weaponQuery.ToListAsync();
        }

        public Task<WeaponDetail> GetWeaponByIdAsync(int weaponId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateWeaponAsync(WeaponEdit model)
        {
            throw new System.NotImplementedException();
        }
    }
}
