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
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult MyDashboard(int Id)
        {
            if(Id == 1)
            {
                ViewBag.Setting = "true";
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyDetails()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
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
        public async Task<IActionResult> MyDetails(MyDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string day = model.Day < 10 ? $"0{model.Day}" : $"{model.Day}";
                string month = 1 + (int)model.Months < 10 ? $"0{1 + (int)model.Months}" : $"{1 + (int)model.Months}";

                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
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

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View("~/Views/User/MyDashboard/ResetPassword.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if(ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
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

    }
}