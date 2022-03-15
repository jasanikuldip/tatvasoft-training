﻿using Helperland.IServices;
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
    [Authorize(Roles ="1")]
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
            try
            {
                if (ModelState.GetFieldValidationState("pincodeCheck") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
                {
                    bool check = userAddressService.CheckPincodeAvaiblity(pincodeCheck);
                    return Json(new { isAvailable = check });
                }
                return Json(new { isAvailable = false });
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        [HttpGet]
        [NoDirectAccess]
        public IActionResult ServiceRequestAddress(string postalCode)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ViewBag.UAList = userAddressService.GetByUserIdAndPincode(userId, postalCode);
                UserAddress model = new UserAddress
                {
                    PostalCode = postalCode,
                    City = userAddressService.GetCityNameByPostalcode(postalCode)
                };
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ServiceBook(ServiceRequestViewModel serviceRequestViewModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                UserAddress userAddressObject = await userAddressService.GetById(serviceRequestViewModel.AddressId);
                ServiceRequestAddress serviceRequestAddressObject = new ServiceRequestAddress
                {
                    AddressLine1 = userAddressObject.AddressLine1,
                    AddressLine2 = userAddressObject.AddressLine2,
                    City = userAddressObject.City,
                    PostalCode = userAddressObject.PostalCode,
                    Mobile = userAddressObject.Mobile,
                    Email = userAddressObject.Email
                };
                ServiceRequest serviceRequestObject = new ServiceRequest
                {
                    UserId = userId,
                    HasPets = serviceRequestViewModel.HasPets,
                    ServiceStartDate = DateTime.Parse(serviceRequestViewModel.StartDate.Replace('/', '-') + " " + serviceRequestViewModel.StartTime),
                    ServiceId = 1,
                    ZipCode = userAddressObject.PostalCode,
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
                foreach (bool extra in serviceRequestViewModel.Extras)
                {
                    ServiceRequestExtra serviceRequestExtraObject = new ServiceRequestExtra
                    {
                        ServiceExtraId = extra ? 1 : 0
                    };
                    serviceRequestObject.ServiceRequestExtras.Add(serviceRequestExtraObject);
                }
                serviceRequestObject.ServiceRequestAddresses.Add(serviceRequestAddressObject);
                serviceRequestObject = await serviceRequestService.AddAsync(serviceRequestObject);
                return Json(new { isSuccess = true, serviceRequestId = serviceRequestObject.ServiceRequestId });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
