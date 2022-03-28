using Helperland.IServices;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Services
{
    public class UserService : IUserService
    {
        private readonly HelperlandContext context;

        public UserService(HelperlandContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int Id)
        {
            User delUser = await context.Users.FirstOrDefaultAsync(_user => _user.UserId == Id);
            if(delUser != null)
            {
                context.Users.Remove(delUser);
                await context.SaveChangesAsync();
            }
            return delUser;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == Email);
        }

        public async  Task<User> GetUserByIdAsync(int Id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == Id);
        }

        public async Task<User> GetUserByMobileAsync(string Mobile)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Mobile == Mobile);
        }

        public IEnumerable<User> GetSPByPostalCode (string PostalCode)
        {
            return context.Users.Include(x=>x.UserAddresses.Where(y=>y.PostalCode == PostalCode)).Where(x=>x.UserTypeId==2);
        }

        public async Task<User> UpdateAsync(User userchange)
        {
            var user = context.Users.Attach(userchange);
            user.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return userchange;
        }
    }
}
