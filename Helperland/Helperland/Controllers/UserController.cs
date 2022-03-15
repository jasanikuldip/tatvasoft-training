using Helperland.IServices;
using Helperland.Models;
using Helperland.Security;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserAddressService userAddressService;
        private readonly IServiceRequestService serviceRequestService;

        public UserController(IUserService userService, 
                              IUserAddressService userAddressService,
                              IServiceRequestService serviceRequestService)
        {
            this.userService = userService;
            this.userAddressService = userAddressService;
            this.serviceRequestService = serviceRequestService;
        }

        public IActionResult MyDashboard(int Id)
        {
            ViewBag.Tab = Id;
            return View();
        }

        [NoDirectAccess]
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> MyDetails()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await userService.GetUserByIdAsync(userId);
            DateTime dob = (DateTime)user.DateOfBirth;
            MyDetailsViewModel model = new MyDetailsViewModel 
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Email = user.Email,
                Day = dob.Day,
                Months = (Models.Enum.Months)dob.Month - 1,
                Year = dob.Year
            };
            return View("~/Views/User/MyDashboard/MyDetails.cshtml", model);
        }

        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> AddUserAddress(UserAddress ua)
        {
            ua.IsDefault = false;
            ua.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ua.IsDeleted = false;
            UserAddress u = await userAddressService.AddAsync(ua);
            return Json(new { isSuccess = true });
        }

        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> MyDetails(MyDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string day = model.Day < 10 ? $"0{model.Day}" : $"{model.Day}";
                string month = 1 + (int)model.Months < 10 ? $"0{1 + (int)model.Months}" : $"{1 + (int)model.Months}";

                int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await userService.GetUserByIdAsync(userId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Mobile = model.Mobile;
                user.DateOfBirth = DateTime.Parse($"{day}-{month}-{model.Year} 00:00:00");
                User us = await userService.UpdateAsync(user);
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }

        [NoDirectAccess]
        [HttpGet]
        [Authorize(Roles ="1,2")]
        public IActionResult ResetPassword()
        {
            return View("~/Views/User/MyDashboard/ResetPassword.cshtml");
        }

        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = await userService.GetUserByIdAsync(userId);
                if (PasswordHashHelper.VerifyPassword(user.Password, resetPasswordViewModel.oldPassword))
                {
                    user.Password = PasswordHashHelper.HashPassword(resetPasswordViewModel.Password);
                    var uu = await userService.UpdateAsync(user);
                    return Json(new { isSuccess = true, isPassSame = true });
                }
                return Json(new { isSuccess = false, isPassSame = false });
            }
            return Json(new { isSuccess = false });
        }

        [NoDirectAccess]
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListAddtess()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<UserAddress> model = userAddressService.GetByUserId(userId);
            return View("~/Views/User/MyDashboard/ListAddress.cshtml", model);
        }

        [NoDirectAccess]
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> AddEditAddress(int Id = 0)
        {
            UserAddress model = new UserAddress();
            if (Id != 0)
            {
                model = await userAddressService.GetById(Id);
            }
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View("~/Views/User/MyDashboard/AddEditAddress.cshtml", model);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> AddEditAddress(UserAddress userAddress)
        {
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = await userService.GetUserByIdAsync(UserId);
            if (ModelState.IsValid)
            {
                userAddress.IsDefault = false;
                userAddress.IsDeleted = false;
                userAddress.UserId = UserId;
                userAddress.Email = user.Email;
                if (userAddress.AddressId != 0)
                {
                    await userAddressService.UpdateAsync(userAddress);
                    return Json(new { isSuccess = true, isNew = false });
                }
                else
                {
                    await userAddressService.AddAsync(userAddress);
                    return Json(new { isSuccess = true, isNew = true });
                }
            }
            return Json(new { isSuccess = false });
        }

        [HttpPost, HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            UserAddress userAddress = await userAddressService.removeAsync(Id);
            if (userAddress != null)
            {
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult GetCityNameAddress(string PostalCode)
        {
            string CityName = userAddressService.GetCityNameByPostalcode(PostalCode);
            if (CityName != null)
            {
                return Json(new { cityName = CityName });
            }
            else
            {
                return Json(new { cityName = "" });
            }
        }

        [HttpGet]
        public IActionResult CurrentServiceRequests()
        {
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<ServiceRequest> model = serviceRequestService.GetAllByUserIdNotCompleted(UserId);
            return View("~/Views/User/CurrentServiceRequests.cshtml", model);
            //return Json(new { model });
        }

    }
}