using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        IEnumerable<User> GetAll();
        Task<User> GetUserByIdAsync(int Id);
        Task<User> GetUserByEmailAsync(string Email);
        Task<User> GetUserByMobileAsync(string Mobile);
        Task<User> UpdateAsync(User userChange);
        Task<User> DeleteAsync(int Id);
        IEnumerable<User> GetSPByPostalCode(string PostalCode);
    }
}
