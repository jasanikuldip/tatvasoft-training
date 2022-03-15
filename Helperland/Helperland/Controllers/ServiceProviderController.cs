using Helperland.IServices;
using Helperland.Models;
using Helperland.Security;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserAddressService userAddressService;

        public ServiceProviderController(IUserService userService, IUserAddressService userAddressService)
        {
            this.userService = userService;
            this.userAddressService = userAddressService;
        }

        public IActionResult MyDashboard(int Id)
        {
            ViewBag.Tab = Id;
            return View();
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> MyDetails()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await userService.GetUserByIdAsync(userId);
            UserAddress userAddress = await userAddressService.GetByUserIdOne(userId);
            DateTime dob = (DateTime)user.DateOfBirth;
            SPMyDetailsViewModel model = new SPMyDetailsViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Email = user.Email,
                Day = dob.Day,
                Months = (Models.Enum.Months)dob.Month - 1,
                Year = dob.Year,
                Gender = user.Gender,
                UserProfilePicture = Convert.ToInt32(user.UserProfilePicture)
            };
            if (userAddress != null)
            {
                model.AddressId = userAddress.AddressId;
                model.AddressLine1 = userAddress.AddressLine1;
                model.AddressLine2 = userAddress.AddressLine2;
                model.PostalCode = userAddress.PostalCode;
                model.City = userAddress.City;
            }
            return View("~/Views/ServiceProvider/MyDashboard/MyDetails.cshtml", model);
        }

        [HttpPost]
        [NoDirectAccess]
        public async Task<IActionResult> MyDetails(SPMyDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string day = model.Day < 10 ? $"0{model.Day}" : $"{model.Day}";
                string month = 1 + (int)model.Months < 10 ? $"0{1 + (int)model.Months}" : $"{1 + (int)model.Months}";

                int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = await userService.GetUserByIdAsync(userId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Mobile = model.Mobile;
                user.DateOfBirth = DateTime.Parse($"{day}-{month}-{model.Year} 00:00:00");
                user.Gender = model.Gender;
                user.UserProfilePicture = Convert.ToString(model.UserProfilePicture);
                if(model.AddressId != null)
                {
                    UserAddress userAddress = await userAddressService.GetByUserIdOne((int)model.AddressId);
                    userAddress.AddressLine1 = model.AddressLine1;
                    userAddress.AddressLine2 = model.AddressLine2;
                    userAddress.PostalCode = model.PostalCode;
                    userAddress.City = model.City;
                    UserAddress ua = await userAddressService.UpdateAsync(userAddress);
                } 
                else
                {
                    UserAddress userAddress = new UserAddress
                    {
                        UserId = userId,
                        IsDefault = true,
                        IsDeleted = false,
                        AddressLine1 = model.AddressLine1,
                        AddressLine2 = model.AddressLine2,
                        PostalCode = model.PostalCode,
                        City = model.City,
                        Mobile = user.Mobile,
                        Email = user.Email
                    };
                    UserAddress ua = await userAddressService.AddAsync(userAddress);
                }
                User us = await userService.UpdateAsync(user);
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}
