using Helperland.IServices;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly HelperlandContext context;

        public UserAddressService(HelperlandContext context)
        {
            this.context = context;
        }

        public async Task<UserAddress> AddAsync(UserAddress ua)
        {
            await context.UserAddresses.AddAsync(ua);
            await context.SaveChangesAsync();
            return ua;
        }

        public bool CheckPincodeAvaiblity(string PincodeAvaiblity)
        {
            var userlist = (from us in context.Users
                            where (us.UserTypeId == 2)
                            join ua in context.UserAddresses on us.UserId equals ua.UserId
                            where (ua.PostalCode == PincodeAvaiblity)
                            select new { ua.AddressId }).ToList().Count;
            if (userlist > 0)
                return true;
            return false;
        }

        public async Task<UserAddress> GetById(int Id)
        {
            return await context.UserAddresses.FirstOrDefaultAsync(x => x.AddressId == Id);
        }

        public IEnumerable<UserAddress> GetByUserId(int Id)
        {
            return context.UserAddresses.Where(x => x.UserId == Id);
        }

        public async Task<UserAddress> GetByUserIdOne(int Id)
        {
            return await context.UserAddresses.FirstOrDefaultAsync(x => x.UserId == Id);
        }

        public IEnumerable<UserAddress> GetByUserIdAndPincode(int UserId, string Pincode)
        {
            return context.UserAddresses.Where(x => x.UserId == UserId && x.PostalCode == Pincode);
        }

        public string GetCityNameByPostalcode(string Postalcode)
        {
            string city = null;

            var cityColl = (from zc in context.Zipcodes
                            where (zc.ZipcodeValue == Postalcode)
                            join ct in context.Cities on zc.CityId equals ct.Id
                            select ct.CityName ?? string.Empty).ToList();
            if (cityColl.Count != 0)
            {
                city = cityColl[0];
            }
            return city;
        }

        public async Task<UserAddress> removeAsync(int Id)
        {
            UserAddress userAddress = context.UserAddresses.Find(Id);
            if (userAddress != null)
            {
                context.UserAddresses.Remove(userAddress);
                await context.SaveChangesAsync();
            }
            return userAddress;
        }

        public async Task<UserAddress> UpdateAsync(UserAddress userAddressChange)
        {
            var userAddress = context.UserAddresses.Attach(userAddressChange);
            userAddress.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return userAddressChange;
        }
    }
}
