using Helperland.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IBlockedUser
    {
        Task<FavoriteAndBlocked> CreateAsync(FavoriteAndBlocked favoriteAndBlocked);
        Task<FavoriteAndBlocked> UpdateAsync(FavoriteAndBlocked favoriteAndBlocked);
        IEnumerable<FavoriteAndBlocked> GetAll(int SPId);
        FavoriteAndBlocked GetOneById(int Id);
    }
}
