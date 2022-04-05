using Helperland.IServices;
using Helperland.Models;
using Helperland.Security;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    [Authorize(Roles = "3")]
    public class AdminController : Controller
    {
        private readonly IServiceRequestService serviceRequestService;
        private readonly IUserService userService;

        public AdminController(IServiceRequestService serviceRequestService, IUserService userService)
        {
            this.serviceRequestService = serviceRequestService;
            this.userService = userService;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public async Task<IActionResult> CancelServiceForCust(int serviceRequestId)
        {
            try
            {
                ServiceRequest serviceRequest = serviceRequestService.GetById(serviceRequestId);
                serviceRequest.Status = 4;
                await serviceRequestService.UpdateAsync(serviceRequest);
                return Json(new { isSucceed = true, serviceRequestId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { isSucceed = false, serviceRequestId });
            }
        }

        public async Task<IActionResult> ActivateUser(int UserId)
        {
            try
            {
                User user = await userService.GetUserByIdAsync(UserId);
                user.Status = 2;
                await userService.UpdateAsync(user);
                return Json(new { isSucceed = true});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { isSucceed = false });
            }
        }

        [NoDirectAccess]
        public IActionResult ServiceRequestsAdmin(string serviceIdFilter, string statusFilter, string postalCodeFilter, string emailFilter, string fromDate, string toDate, string customerFieled, string SPField)
        {
            IEnumerable<ServiceRequest> model = null;

            model = serviceRequestService.GetAll();

            if (postalCodeFilter != null)
            {
                model = model.Where(x => x.ServiceRequestAddresses.Any(x => x.PostalCode == postalCodeFilter));
            }

            if (statusFilter != null)
            {
                model = model.Where(x => x.Status.ToString() == statusFilter);
            }

            if (serviceIdFilter != null)
            {
                model = model.Where(x => x.ServiceRequestId.ToString() == serviceIdFilter);
            }

            if (emailFilter != null)
            {
                model = model.Where(x => x.ServiceRequestAddresses.Any(x => x.Email == emailFilter));
            }

            if (fromDate != null)
            {
                model = model.Where(x => x.ServiceStartDate > DateTime.Parse(fromDate.Replace('/', '-')));
            }

            if (toDate != null)
            {
                model = model.Where(x => x.ServiceStartDate < DateTime.Parse(toDate.Replace('/', '-')));
            }

            if (customerFieled != null)
            {
                model = model.Where(x => x.User.FirstName + " " + x.User.LastName == customerFieled);
            }

            if (SPField != null)
            {
                model = model.Where(x => x.ServiceProvider.FirstName + " " + x.ServiceProvider.LastName == SPField);
            }

            return View(model);
        }

        [NoDirectAccess]
        public IActionResult UserManagement(string UserManagementUserField, string userTypeFilter, string phoneNumberFilter, string postalCodeUMFilter, string emailUMFilter, string fromUMDate, string toUMDate)
        {
            IEnumerable<User> model = null;

            model = userService.GetAll();

            if (UserManagementUserField != null)
            {
                model = model.Where(x => Convert.ToString(x.FirstName + " " + x.LastName) == UserManagementUserField);
            }

            if (userTypeFilter != null)
            {
                model = model.Where(x => x.UserTypeId.ToString() == userTypeFilter);
            }

            if (phoneNumberFilter != null)
            {
                model = model.Where(x => x.Mobile.ToString() == phoneNumberFilter);
            }

            if (postalCodeUMFilter != null)
            {
                model = model.Where(x => x.UserAddresses.Any(x => x.PostalCode == postalCodeUMFilter));
            }

            if (emailUMFilter != null)
            {
                model = model.Where(x => x.UserAddresses.Any(x => x.Email == emailUMFilter));
            }

            if (fromUMDate != null)
            {
                model = model.Where(x => x.CreatedDate > DateTime.Parse(fromUMDate.Replace('/', '-')));
            }

            if (toUMDate != null)
            {
                model = model.Where(x => x.CreatedDate < DateTime.Parse(toUMDate.Replace('/', '-')));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditServiceRequest(int id)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(id);
            EditAdminService model = new EditAdminService
            {
                AddressLine1 = serviceRequest.ServiceRequestAddresses.ElementAt(0).AddressLine1,
                AddressLine2 = serviceRequest.ServiceRequestAddresses.ElementAt(0).AddressLine2,
                PostalCode = serviceRequest.ServiceRequestAddresses.ElementAt(0).PostalCode,
                City = serviceRequest.ServiceRequestAddresses.ElementAt(0).City,
                StartTime = serviceRequest.ServiceStartDate.ToString("HH:mm:ss"),
                Date = serviceRequest.ServiceStartDate.ToString("dd-MM-yyyy").Replace('-', '/'),
                ServiceRequestId = serviceRequest.ServiceRequestId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditServiceRequest(EditAdminService adminService)
        {
            ServiceRequest serviceRequest = serviceRequestService.GetById(adminService.ServiceRequestId);
            IEnumerable<ServiceRequest> spServices = serviceRequestService.GetBySPId((int)serviceRequest.ServiceProviderId);

            DateTime ServiceStartDate = DateTime.Parse(adminService.Date.Replace('/', '-') + " " + adminService.StartTime);
            DateTime ServiceEndDate = ServiceStartDate.AddHours(serviceRequest.ServiceHours + 1);
            ServiceStartDate = ServiceStartDate.AddHours(-1);

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
                    isAvailable = false; break;
                }
            }

            if (isAvailable)
            {
                serviceRequest.ServiceStartDate.AddHours(1);
                serviceRequest.ServiceRequestAddresses.ElementAt(0).AddressLine1 = adminService.AddressLine1;
                serviceRequest.ServiceRequestAddresses.ElementAt(0).AddressLine2 = adminService.AddressLine2;
                serviceRequest.ServiceRequestAddresses.ElementAt(0).PostalCode = adminService.PostalCode;
                serviceRequest.ServiceRequestAddresses.ElementAt(0).City = adminService.City;
                await serviceRequestService.UpdateAsync(serviceRequest);
                return Json(new { isSucceed = true });
            }
            else
            {
                return Json(new { isSucceed = false });
            }
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult ServiceDetails(int Id)
        {
            ServiceRequest model = serviceRequestService.GetById(Id);
            return View("~/Views/Admin/ServiceDetails.cshtml", model);
        }

        public IActionResult FetchCustomerNames(string name)
        {
            var users = userService.GetAll();
            List<string> names = users.Where(x => Convert.ToString(x.FirstName + " " + x.LastName).Contains(name) && x.UserTypeId == 1).Select(x => x.FirstName + " " + x.LastName).Distinct().ToList();
            return Json(names);
        }

        public IActionResult FetchSPNames(string name)
        {
            var users = userService.GetAll();
            List<string> names = users.Where(x => Convert.ToString(x.FirstName + " " + x.LastName).Contains(name) && x.UserTypeId == 2).Select(x => x.FirstName + " " + x.LastName).Distinct().ToList();
            return Json(names);
        }

        public IActionResult UserManagementUser(string name)
        {
            var users = userService.GetAll();
            List<string> names = users.Where(x => Convert.ToString(x.FirstName + " " + x.LastName).Contains(name)).Select(x => x.FirstName + " " + x.LastName).Distinct().ToList();
            return Json(names);
        }

    }
}
