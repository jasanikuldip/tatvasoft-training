using Helperland.IServices;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public ServiceController(IUserAddressService userAddressService)
        {
            this.userAddressService = userAddressService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Avaiblity(string pincodeCheck)
        {
            if (ModelState.GetFieldValidationState("pincodeCheck") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                bool check = userAddressService.CheckPincodeAvaiblity(pincodeCheck);
                return Json(new { isAvailable = check });
            }
            return Json(new { isAvailable = false });
        }
    }
}
