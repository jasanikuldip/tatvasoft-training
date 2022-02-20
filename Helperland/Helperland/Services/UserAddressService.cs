using Helperland.IServices;
using Helperland.Models;
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
    }
}
