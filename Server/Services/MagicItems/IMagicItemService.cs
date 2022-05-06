using RPGCharacterBuilderWebApp1.Shared.Models.MagicItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Server.Services.MagicItems
{
    public interface IMagicItemService
    {
        Task<IEnumerable<MagicItemListItem>> GetAllMagicItemsAsync();
        Task<bool> CreateMagicItemAsync(MagicItemCreate model);
        Task<MagicItemDetail> GetMagicItemByIdAsync(int magicItemId);
        Task<bool> UpdateMagicItemAsync(MagicItemEdit model);
        Task<bool> DeleteMagicItemAsync(int magicItemId);
    }
}
