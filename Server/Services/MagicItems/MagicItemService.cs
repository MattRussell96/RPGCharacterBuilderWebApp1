using Microsoft.EntityFrameworkCore;
using RPGCharacterBuilderWebApp1.Server.Data;
using RPGCharacterBuilderWebApp1.Server.Models;
using RPGCharacterBuilderWebApp1.Shared.Models.MagicItem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.MagicItems
{
    public class MagicItemService : IMagicItemService
    {
        private readonly ApplicationDbContext _context;

        public MagicItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMagicItemAsync(MagicItemCreate model)
        {
            if (model == null) return false;

            var magicItemEntity = new MagicItem
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                MagicDamageIncreasedBy = model.MagicDamageIncreasedBy,
                Weight = model.Weight,
            };

            _context.MagicItems.Add(magicItemEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeleteMagicItemAsync(int magicItemId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MagicItemListItem>> GetAllMagicItemsAsync()
        {
            var magicItemQuery =
                _context
                .MagicItems
                .Select(entity =>
                new MagicItemListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Type = entity.Type,
                });

            return await magicItemQuery.ToListAsync();
        }

        public Task<MagicItemDetail> GetMagicItemByIdAsync(int magicItemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateMagicItemAsync(MagicItemEdit model)
        {
            throw new System.NotImplementedException();
        }
    }
}
