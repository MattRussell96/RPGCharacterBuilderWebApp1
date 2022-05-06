using Microsoft.EntityFrameworkCore;
using RPGCharacterBuilderWebApp1.Server.Data;
using RPGCharacterBuilderWebApp1.Server.Models;
using RPGCharacterBuilderWebApp1.Shared.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        private string _userId;
             
        public async Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync()
        {
            var characterQuery = _context
                .Characters
                .Where(n => n.OwnerId == _userId)
                .Select(n =>
                new CharacterListItem
                {
                    Id = n.Id,
                    Name = n.Name,
                    ArmorName = n.Armor.Name,
                    WeaponName = n.Weapon.Name,
                    MagicItemName = n.MagicItem.Name,
                    CreatedUtc = n.CreatedUtc,

                });

            return await characterQuery.ToListAsync();
        }

        public async Task<bool> CreateCharacterAsync(CharacterCreate model)
        {
            var characterEntity = new Character
            {
                Id = model.Id,
                Name = model.Name,
                Health = model.Health,
                Strength = model.Strength,
                Stamina = model.Stamina,
                Speed = model.Speed,
                Mana = model.Mana,
                OwnerId = _userId,
                CreatedUtc = DateTimeOffset.Now,
                ArmorId = model.ArmorId,
                WeaponId = model.WeaponId,
                MagicItemId = model.MagicItemId,
            };

            _context.Characters.Add(characterEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<CharacterDetail> GetCharacterByIdAsync(int characterId)
        {
            var characterEntity = await _context
                .Characters
                .Include(nameof(Armor))
                .FirstOrDefaultAsync(n => n.Id == characterId && n.OwnerId == _userId);

            if (characterEntity == null)
                return null;

            var detail = new CharacterDetail
            {
                Id = characterEntity.Id,
                Name = characterEntity.Name,
                Health = characterEntity.Health,
                Strength = characterEntity.Strength,
                Stamina = characterEntity.Stamina,
                Speed = characterEntity.Speed,
                Mana = characterEntity.Mana,
                CreatedUtc = characterEntity.CreatedUtc,
                ModifiedUtc = characterEntity.ModifiedUtc,
                ArmorName = characterEntity.Armor.Name,
                ArmorId = characterEntity.Armor.Id,
                WeaponName = characterEntity.Weapon.Name,
                WeaponId = characterEntity.Weapon.Id,
                MagicItemName = characterEntity.MagicItem.Name,
                MagicItemId = characterEntity.MagicItem.Id,
            };

            return detail;
        }

        public async Task<bool> UpdateCharacterAsync(CharacterEdit model)
        {
            if (model == null)
            {
                return false;
            }

            var entity = await _context.Characters.FindAsync(model.Id);

            if (entity?.OwnerId != _userId) return false;

            entity.Name = model.Name;
            entity.Health = model.Health;
            entity.Strength = model.Strength;
            entity.Stamina = model.Stamina;
            entity.Speed = model.Speed;
            entity.Mana = model.Mana;
            entity.ArmorId = model.ArmorId;
            entity.WeaponId = model.WeaponId;
            entity.MagicItemId = model.MagicItemId;
            entity.ModifiedUtc = DateTimeOffset.Now;

            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<bool> DeleteCharacterAsync(int characterId)
        {
            var entity = await _context.Characters.FindAsync(characterId);
            if (entity?.OwnerId != _userId) 
                return false;

            _context.Characters.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        //public Task<bool> DeleteCharacterAsync(string userId)
        //{
        //    throw new System.NotImplementedException();
        //}
        
        
        public void SetUserId(string userId) => _userId = userId;
    }
}
