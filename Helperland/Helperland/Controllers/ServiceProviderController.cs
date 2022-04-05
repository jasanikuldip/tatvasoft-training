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
    [Authorize(Roles = "2")]
    public class ServiceProviderController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserAddressService userAddressService;
        private readonly IServiceRequestService serviceRequestService;
        private readonly IBlockedUser blockedUser;

        public ServiceProviderController(IUserService userService,
                                         IUserAddressService userAddressService,
                                         IServiceRequestService serviceRequestService,
                                         IBlockedUser blockedUser)
        {
            this.userService = userService;
            this.userAddressService = userAddressService;
            this.serviceRequestService = serviceRequestService;
            this.blockedUser = blockedUser;
        }

        public IActionResult MyDashboard(int Id, bool AddressAlert = false)
        {
            ViewBag.Tab = Id;
            ViewBag.AddressAlert = false;
            if (Id == 9)
            {
                ViewBag.AddressAlert = AddressAlert;
            }
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
            return View("~/Views/ServiceProvider/MyDetails.cshtml", model);
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
                if (model.AddressId != null)
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

        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> NewServiceRequests(bool includePet)
        {
            int SPId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<UserAddress> userAddresses = userAddressService.GetByUserId(SPId);
            ViewBag.isAddressAvailable = false;
            IEnumerable<ServiceRequest> model = null;
            if (userAddresses.Count() > 0)
            {
                string postalcode = userAddresses.FirstOrDefault().PostalCode;
                if (includePet)
                {
                    model = serviceRequestService.GetAllNotAssignedService(SPId,postalcode).Where(x => x.ServiceStartDate > DateTime.Now && x.HasPets == true);
                }
                else
                {
                    model = serviceRequestService.GetAllNotAssignedService(SPId,postalcode).Where(x => x.ServiceStartDate > DateTime.Now && x.HasPets == false);
                }
                ViewBag.isAddressAvailable = true;
            }
            return View("~/Views/ServiceProvider/NewServiceRequests.cshtml", model);

        }


        [HttpGet]
        [NoDirectAccess]
        public IActionResult UpcomingServiceRequests()
        {
            int SPId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<ServiceRequest> model = serviceRequestService.UpcomingServicesForSP(SPId);
            return View("~/Views/ServiceProvider/UpcomingServiceRequests.cshtml", model);
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult ServiceHistory()
        {
            int SPId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<ServiceRequest> model = serviceRequestService.ServiceHistorySP(SPId);
            return View("~/Views/ServiceProvider/ServiceHistory.cshtml", model);
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult MyRatingSP()
        {
            int SPId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Rating> model = serviceRequestService.MyRatingsList(SPId);
            return View("~/Views/ServiceProvider/MyRatings.cshtml", model);
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult ServiceDetails(int Id, int requestOrigin)
        {
            ServiceRequest model = serviceRequestService.GetById(Id);
            ViewBag.RequestOrigin = requestOrigin;
            return View("~/Views/ServiceProvider/ServiceDetails.cshtml", model);
        }

        [HttpPost, HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AcceptService(int id)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(id);
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            DateTime ServiceStartDate = serviceRequest.ServiceStartDate;
            DateTime ServiceEndDate = ServiceStartDate.AddHours(serviceRequest.ServiceHours + 1);
            ServiceStartDate = ServiceStartDate.AddHours(-1);
            int? serviceIdFailId = null;

            IEnumerable<ServiceRequest> spServices = serviceRequestService.GetBySPId(UserId);
            bool isAvailable = true;
            DateTime ProblemDateStart = DateTime.MinValue;
            DateTime ProblemDateEnd = DateTime.MinValue;
            foreach (ServiceRequest spService in spServices)
            {
                DateTime spStartDate = spService.ServiceStartDate;
                DateTime spEndDate = spService.ServiceStartDate.AddHours(spService.ServiceHours);
                if ((spStartDate < ServiceStartDate && ServiceStartDate < spEndDate) || (spStartDate < ServiceEndDate && ServiceEndDate < spEndDate) || (ServiceStartDate <= spStartDate && spEndDate <= ServiceEndDate))
                {
                    ProblemDateStart = spStartDate;
                    ProblemDateEnd = spEndDate;
                    serviceIdFailId = spService.ServiceRequestId;
                    isAvailable = false; break;

                }
            }

            if (isAvailable)
            {
                if (serviceRequest.Status == 1)
                {
                    serviceRequest.Status = 2;
                    serviceRequest.ServiceProviderId = UserId;
                    _ = await serviceRequestService.UpdateAsync(serviceRequest);
                    FavoriteAndBlocked favoriteAndBlocked = new FavoriteAndBlocked
                    {
                        IsBlocked = false,
                        IsFavorite = false,
                        UserId = UserId,
                        TargetUserId = serviceRequest.UserId
                    };
                    if (!blockedUser.CheckRecord(favoriteAndBlocked))
                    {
                        await blockedUser.CreateAsync(favoriteAndBlocked);
                    }
                    return Json(new { isAvailable, serviceIdFailId });
                }
                else
                {
                    return Json(new { isAvailable, serviceIdFailId = 0 });
                }
            }
            else
            {
                return Json(new { isAvailable, serviceIdFailId });
            }
        }

        [HttpPost]
        [NoDirectAccess]
        public async Task<IActionResult> CompleteCancelServiceSP(int serviceId, int completeCancel)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(serviceId);
            if (completeCancel == 1)
            {
                serviceRequest.Status = 3;
            }
            else
            {
                serviceRequest.Status = 5;
            }
            await serviceRequestService.UpdateAsync(serviceRequest);
            return Json(new { isSuccess = true, isCompleteCancel = completeCancel });
        }

        [HttpGet]
        public IActionResult BlockedUserSp()
        {
            int SPId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<FavoriteAndBlocked> model = blockedUser.GetAll(SPId);
            return View("~/Views/ServiceProvider/BlockedUserSp.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> BlockedUserSp(int id)
        {
            try
            {
                FavoriteAndBlocked favoriteAndBlocked = blockedUser.GetOneById(id);
                favoriteAndBlocked.IsBlocked = !favoriteAndBlocked.IsBlocked;
                await blockedUser.UpdateAsync(favoriteAndBlocked);
                return Json(new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
