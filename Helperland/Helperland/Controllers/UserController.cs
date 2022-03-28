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
        private readonly IEmailService emailService;

        public UserController(IUserService userService,
                              IUserAddressService userAddressService,
                              IServiceRequestService serviceRequestService,
                              IEmailService emailService)
        {
            this.userService = userService;
            this.userAddressService = userAddressService;
            this.serviceRequestService = serviceRequestService;
            this.emailService = emailService;
        }

        [Authorize(Roles = "1")]
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
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User cust = await userService.GetUserByIdAsync(UserId);
            ua.Email = cust.Email;
            ua.IsDefault = false;
            ua.UserId = UserId;
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
        [Authorize(Roles = "1,2")]
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
        [NoDirectAccess]
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
        [NoDirectAccess]
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
        [NoDirectAccess]
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
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public IActionResult CurrentServiceRequests()
        {
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.RatingAll = serviceRequestService.GetAllRating();
            IEnumerable<ServiceRequest> model = serviceRequestService.GetAllByUserIdNotCompletedCancelled(UserId);
            return View("~/Views/User/CurrentServiceRequests/CurrentServiceRequests.cshtml", model);
        }

        [HttpGet]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public IActionResult ServiceHistory()
        {
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<ServiceRequest> model = serviceRequestService.GetAllByUserIdCompletedCancelled(UserId);
            ViewBag.RatingAll = serviceRequestService.GetAllRating();
            return View("~/Views/User/ServiceHistory/ServiceHistory.cshtml", model);
        }

        [HttpGet]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public IActionResult ServiceDetails(int Id, int requestOrigin)
        {
            ServiceRequest model = serviceRequestService.GetById(Id);
            ViewBag.RequestOrigin = requestOrigin;
            return View("~/Views/User/CurrentServiceRequests/ServiceDetails.cshtml", model);
        }

        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> RescheduleService(string StartDate, string StartTime, string ServiceId)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(Convert.ToInt32(ServiceId));
            User serviceProvider = await userService.GetUserByIdAsync((int)serviceRequest.ServiceProviderId);
            DateTime ServiceStartDate = DateTime.Parse(StartDate.Replace('/', '-') + " " + StartTime);

            //get start time and end time
            if (serviceRequest.ServiceProviderId != null)
            {
                DateTime ServiceEndDate = ServiceStartDate.AddHours(serviceRequest.ServiceHours + 1);
                ServiceStartDate = ServiceStartDate.AddHours(-1);

                IEnumerable<ServiceRequest> spServices = serviceRequestService.GetBySPId((int)serviceRequest.ServiceProviderId);
                bool isAvailable = true;
                DateTime ProblemDateStart = DateTime.MinValue;
                DateTime ProblemDateEnd = DateTime.MinValue;
                foreach (ServiceRequest spService in spServices)
                {
                    DateTime spStartDate = spService.ServiceStartDate;
                    DateTime spEndDate = spService.ServiceStartDate.AddHours(spService.ServiceHours);
                    if ((spStartDate <= ServiceStartDate && ServiceStartDate <= spEndDate) || (spStartDate <= ServiceEndDate && ServiceEndDate <= spEndDate) || (ServiceStartDate < spStartDate && spEndDate < ServiceEndDate))
                    {
                        ProblemDateStart = spStartDate;
                        ProblemDateEnd = spEndDate;
                        isAvailable = false; break;
                    }
                }
                if (isAvailable)
                {
                    serviceRequest.ServiceStartDate = ServiceStartDate.AddHours(1);

                    string _url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    UserEmailOptions userEmailOptions = new UserEmailOptions
                    {
                        ToEmails = new List<string> { serviceProvider.Email.ToString() },
                        Subject = $"Service Rescheduled : {serviceRequest.ServiceRequestId} | Helperland",
                        Body = "serviceReschedule",
                        Replaces = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("[username]",serviceProvider.FirstName),
                            new KeyValuePair<string, string>("[ServiceId]",$"{serviceRequest.ServiceRequestId}"),
                            new KeyValuePair<string, string>("[ServiceTime]",$"{serviceRequest.ServiceStartDate.ToString("dd/MM/yyyy HH:mm").Replace('-','/')}-{serviceRequest.ServiceStartDate.AddHours(serviceRequest.ServiceHours).ToString("HH:mm")}"),
                            new KeyValuePair<string, string>("[url]",_url)
                        }
                    };
                    await emailService.SendEmail(userEmailOptions);

                    await serviceRequestService.UpdateAsync(serviceRequest);
                    return Json(new { isAvailable });
                }
                else
                {
                    return Json(new
                    {
                        isAvailable,
                        date = ProblemDateStart.ToString("dd-MM-yyyy").Replace('-', '/'),
                        startTime = ProblemDateStart.ToString("HH:mm"),
                        endTime = ProblemDateEnd.ToString("HH:mm")
                    });
                }
            }
            else
            {
                serviceRequest.ServiceStartDate = ServiceStartDate;
                await serviceRequestService.UpdateAsync(serviceRequest);
                return Json(new { isAvailable = true });
            }
        }

        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CancelService(string cancelReason, string cancelServiceId)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(Convert.ToInt32(cancelServiceId));
            serviceRequest.Status = 4;

            if (serviceRequest.ServiceProviderId != null)
            {
                User serviceProvider = await userService.GetUserByIdAsync((int)serviceRequest.ServiceProviderId);
                string _url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                UserEmailOptions userEmailOptions = new UserEmailOptions
                {
                    ToEmails = new List<string> { serviceProvider.Email.ToString() },
                    Subject = $"Service Cancel : {serviceRequest.ServiceRequestId} | Helperland",
                    Body = "serviceCancel",
                    Replaces = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("[username]",serviceProvider.FirstName),
                            new KeyValuePair<string, string>("[ServiceId]",$"{serviceRequest.ServiceRequestId}"),
                            new KeyValuePair<string, string>("[cancelReason]",cancelReason),
                            new KeyValuePair<string, string>("[url]",_url)
                        }
                };
                await emailService.SendEmail(userEmailOptions);
            }
            await serviceRequestService.UpdateAsync(serviceRequest);
            return Json(new { isSuccess = true });
        }

        [HttpGet]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public IActionResult RatingSP(int serviceRequestId)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(serviceRequestId);

            RatingViewModel model = new RatingViewModel
            {
                SPId = (int)serviceRequest.ServiceProviderId,
                SPProfile = serviceRequest.ServiceProvider.UserProfilePicture,
                SPName = serviceRequest.ServiceProvider.FirstName + " " + serviceRequest.ServiceProvider.LastName,
                ServiceRequestId = serviceRequestId
            };
            if (serviceRequest.ServiceProvider.RatingRatingToNavigations.Count != 0)
            {
                model.RatingId = serviceRequest.ServiceProvider.RatingRatingToNavigations.FirstOrDefault(x => x.ServiceRequestId == serviceRequestId).RatingId;
                model.SPRating = serviceRequest.ServiceProvider.RatingRatingToNavigations.Average(t => t.Ratings);
                model.RatingComments = serviceRequest.ServiceProvider.RatingRatingToNavigations.FirstOrDefault(x => x.ServiceRequestId == serviceRequestId).Comments;
                model.OnTimeArrival = Convert.ToInt32(serviceRequest.ServiceProvider.RatingRatingToNavigations.FirstOrDefault(x => x.ServiceRequestId == serviceRequestId).OnTimeArrival);
                model.QualityOfService = Convert.ToInt32(serviceRequest.ServiceProvider.RatingRatingToNavigations.FirstOrDefault(x => x.ServiceRequestId == serviceRequestId).QualityOfService);
                model.Friendly = Convert.ToInt32(serviceRequest.ServiceProvider.RatingRatingToNavigations.FirstOrDefault(x => x.ServiceRequestId == serviceRequestId).Friendly);
            }
            return View("~/Views/User/ServiceHistory/RatingSP.cshtml", model);
        }


        [HttpPost]
        [NoDirectAccess]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> RatingSP(RatingViewModel ratingViewModel)
        {
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid)
            {
                Rating rating = new Rating
                {
                    RatingId = ratingViewModel.RatingId,
                    RatingFrom = UserId,
                    RatingTo = ratingViewModel.SPId,
                    ServiceRequestId = ratingViewModel.ServiceRequestId,
                    Ratings = (ratingViewModel.QualityOfService + ratingViewModel.Friendly + ratingViewModel.OnTimeArrival) / 3.0M,
                    Comments = ratingViewModel.RatingComments,
                    RatingDate = DateTime.Now,
                    OnTimeArrival = ratingViewModel.OnTimeArrival,
                    QualityOfService = ratingViewModel.QualityOfService,
                    Friendly = ratingViewModel.Friendly
                };
                if (ratingViewModel.RatingId == 0)
                {
                    await serviceRequestService.AddRatingAsync(rating);
                }
                else
                {
                    await serviceRequestService.UpdateRatingAsync(rating);
                }
                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }
    }
}