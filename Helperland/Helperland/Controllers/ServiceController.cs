using Helperland.IServices;
using Helperland.Models;
using Helperland.Security;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IUserAddressService userAddressService;
        private readonly IServiceRequestService serviceRequestService;

        public ServiceController(IUserAddressService userAddressService, IServiceRequestService serviceRequestService)
        {
            this.userAddressService = userAddressService;
            this.serviceRequestService = serviceRequestService;
        }

        public IActionResult Index()
        {
            return View("ServiceRequest");
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


        [HttpGet]
        [NoDirectAccess]
        public IActionResult ServiceRequestAddress(string postalCode)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            ViewBag.UAList = userAddressService.GetByUserIdAndPincode(userId, postalCode);
            UserAddress model = new UserAddress
            {
                PostalCode = postalCode,
                City = userAddressService.GetCityNameByPostalcode(postalCode)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceBook(ServiceRequestViewModel serviceRequestViewModel)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            UserAddress ua = await userAddressService.GetById(serviceRequestViewModel.AddressId);
            ServiceRequestAddress sra = new ServiceRequestAddress
            {
                AddressLine1 = ua.AddressLine1,
                AddressLine2 = ua.AddressLine2,
                City = ua.City,
                PostalCode = ua.PostalCode,
                Mobile = ua.Mobile,
                Email = ua.Email
            };
            ServiceRequest sr = new ServiceRequest
            {
                UserId = userId,
                HasPets = serviceRequestViewModel.HasPets,
                ServiceStartDate = DateTime.Parse(serviceRequestViewModel.StartDate.Replace('/', '-') + " " + serviceRequestViewModel.StartTime),
                ServiceId = 1,
                ZipCode = ua.PostalCode,
                ServiceHourlyRate = 18,
                ServiceHours = serviceRequestViewModel.ServiceHours,
                SubTotal = Convert.ToDecimal(18 * serviceRequestViewModel.ServiceHours),
                TotalCost = Convert.ToDecimal(18 * serviceRequestViewModel.ServiceHours),
                Comments = serviceRequestViewModel.Comments,
                PaymentDue = false,
                Status = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
                Distance = 0
            };
            //sr.ServiceRequestAddresses.Add(sra);
            sr = await serviceRequestService.AddAsync(sr);
            ServiceRequestAddress(ua.PostalCode);
            //sra.ServiceRequestId = sr.ServiceRequestId;
            //var a = await serviceRequestService.AddAddressAsync(sra);
            return Json(new { t = "Succeed", sr = sr });
        }

    }
}
