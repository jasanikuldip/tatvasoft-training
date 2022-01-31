using Helperland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Helperland.ViewModels;
using Helperland.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactUs contactUs;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IContactUs contactUs,
                              IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.contactUs = contactUs;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactUsCreateViewModel contactUsCreateViewModel)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(contactUsCreateViewModel.UploadFile != null)
                {
                    string folderPath = Path.Combine(webHostEnvironment.WebRootPath,"Documents/ContactUsAttachment");
                    uniqueFileName = Guid.NewGuid() + "_" + contactUsCreateViewModel.UploadFile.FileName;
                    string filePath = Path.Combine(folderPath,uniqueFileName);
                    using (var filestream = new FileStream(filePath, FileMode.Create))
                    {
                        contactUsCreateViewModel.UploadFile.CopyTo(filestream);
                    }
                }
                ContactU contactU = new ContactU
                {
                    Name = contactUsCreateViewModel.FirstName + " " + contactUsCreateViewModel.LastName,
                    Email = contactUsCreateViewModel.Email,
                    Subject = contactUsCreateViewModel.Subject,
                    PhoneNumber = contactUsCreateViewModel.PhoneNumber,
                    Message = contactUsCreateViewModel.Message,
                    UploadFileName = uniqueFileName,
                    CreatedOn = DateTime.Now,
                    CreatedBy = null
                };
                contactUs.Create(contactU);
                ViewData["IsFormSubmitted"] = true;
                ModelState.Clear();
                return View();
            }
            return View();
        }

        public IActionResult Faqs()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
