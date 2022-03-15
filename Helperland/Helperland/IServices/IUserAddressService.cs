using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IUserAddressService
    {
        bool CheckPincodeAvaiblity(string PincodeAvaiblity);

        IEnumerable<UserAddress> GetByUserIdAndPincode(int UserId, string Pincode);

        string GetCityNameByPostalcode(string Postalcode);

        Task<UserAddress> AddAsync(UserAddress ua);
        Task<UserAddress> GetById(int Id);
        IEnumerable<UserAddress> GetByUserId(int Id);
        Task<UserAddress> UpdateAsync(UserAddress uaChange);
        Task<UserAddress> removeAsync(int Id);

        Task<UserAddress> GetByUserIdOne(int Id);
    }
}
