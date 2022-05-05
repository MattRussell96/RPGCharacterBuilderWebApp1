using Microsoft.EntityFrameworkCore;
using RPGCharacterBuilderWebApp1.Server.Data;
using RPGCharacterBuilderWebApp1.Server.Models;
using RPGCharacterBuilderWebApp1.Shared.Models.Armor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Armors
{
    public class ArmorService : IArmorService
    {
        private readonly ApplicationDbContext _context;

        public ArmorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateArmorAsync(ArmorCreate model)
        {
            if (model == null) return false;

            var armorEntity = new Armor
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                DamageNegation = model.DamageNegation,
                Weight = model.Weight,
            };

            _context.Armors.Add(armorEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteArmorAsync(int armorId)
        {
            var armorEntity = new Armor { Id = armorId };
            _context.Remove(armorEntity);
            await _context.SaveChangesAsync();
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<ArmorListItem>> GetAllArmorAsync()
        {
            var armorQuery =
                _context
                .Armors
                .Select(entity =>
                new ArmorListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                });

            return await armorQuery.ToListAsync();
        }

        public Task<ArmorDetail> GetArmorByIdAsync(int armorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateArmorAsync(ArmorEdit model)
        {
            throw new System.NotImplementedException();
        }
    }
}
