using Helperland.IServices;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Services
{
    public class BlockedUser : IBlockedUser
    {
        private readonly HelperlandContext context;

        public BlockedUser(HelperlandContext context)
        {
            this.context = context;
        }

        public bool CheckRecord(FavoriteAndBlocked favoriteAndBlocked)
        {
            if (context.FavoriteAndBlockeds.Any(x => x.UserId == favoriteAndBlocked.UserId && x.TargetUserId == favoriteAndBlocked.TargetUserId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<FavoriteAndBlocked> CreateAsync(FavoriteAndBlocked favoriteAndBlocked)
        {
            await context.AddAsync(favoriteAndBlocked);
            await context.SaveChangesAsync();
            return favoriteAndBlocked;
        }

        public IEnumerable<FavoriteAndBlocked> GetAll(int SPId)
        {
            return context.FavoriteAndBlockeds.Include(x => x.TargetUser).Where(x => x.UserId == SPId);
        }

        public FavoriteAndBlocked GetOneById(int Id)
        {
            return context.FavoriteAndBlockeds.FirstOrDefault(x => x.Id == Id);
        }



        public async Task<FavoriteAndBlocked> UpdateAsync(FavoriteAndBlocked favoriteAndBlockedChanges)
        {
            var favoriteAndBlocked = context.FavoriteAndBlockeds.Attach(favoriteAndBlockedChanges);
            favoriteAndBlocked.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return favoriteAndBlockedChanges;
        }
    }
}
