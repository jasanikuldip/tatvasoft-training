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

        public async Task<UserAddress> AddUAAsync(UserAddress ua)
        {
            await context.UserAddresses.AddAsync(ua);
            await context.SaveChangesAsync();
            return ua;
        }

        public bool CheckPincodeAvaiblity(string PincodeAvaiblity)
        {
            var userlist = (from us in context.Users
                            where (us.UserTypeId == 1)
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

        public IEnumerable<UserAddress> GetByUserIdAndPincode(int UserId, string Pincode)
        {
            return context.UserAddresses.Where(x => x.UserId == UserId && x.PostalCode == Pincode);
        }

        public string GetCityNameByPostalcode(string Postalcode)
        {
            string city = (from zc in context.Zipcodes
                                 where(zc.ZipcodeValue == Postalcode)
                     join ct in context.Cities on zc.CityId equals ct.Id
                     select ct.CityName).ToList()[0];
            return city;
        }


    }
}
