using RPGCharacterBuilderWebApp1.Shared.Models.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.Character
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync();
        Task<bool> CreateCharacterAsync(CharacterCreate model);
        Task<CharacterDetail> GetCharacterByIdAsync(int characterId);
        Task<bool> UpdateCharacterAsync(CharacterEdit model);
        Task<bool> DeleteCharacterAsync(int characterId);
        Task<bool> DeleteCharacterAsync(string userId);
        void SetUserId(string userId);
    }
}
