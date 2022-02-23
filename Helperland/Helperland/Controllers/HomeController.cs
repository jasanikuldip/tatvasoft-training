using Helperland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Helperland.ViewModels;
using Helperland.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Helperland.IServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Helperland.Security;
using Microsoft.AspNetCore.Http;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactUsService contactUs;
        private readonly IUserService userService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger,
                              IContactUsService contactUs,
                              IUserService userService,
                              IEmailService emailService,
                              IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.contactUs = contactUs;
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
            this.emailService = emailService;

        }

        public IActionResult Index(int Id)
        {
            if(Id == 1)
            {
                ViewBag.login = 1;
            }
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
        public async Task<IActionResult> Contact(ContactUsCreateViewModel contactUsCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (contactUsCreateViewModel.UploadFile != null)
                {
                    string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Documents/ContactUsAttachment");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + contactUsCreateViewModel.UploadFile.FileName;
                    string filePath = Path.Combine(folderPath, uniqueFileName);
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
                await contactUs.CreateAsync(contactU);
                return Json(new { issuccess = true });
            }
            return Json(new { issuccess = false });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userService.GetUserByEmailAsync(loginModel.EmailLogin);
                if (user != null)
                {
                    if (PasswordHashHelper.VerifyPassword(user.Password, loginModel.PasswordLogin))
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.UserId)),
                            new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
                            new Claim(ClaimTypes.Role,Convert.ToString(user.UserTypeId))
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                            new AuthenticationProperties()
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTime.UtcNow.AddHours(1)
                            });

                        if (loginModel.RememberMe)
                        {
                            CookieOptions ckOptions = new CookieOptions();
                            ckOptions.Expires = DateTime.UtcNow.AddDays(1);
                            Response.Cookies.Append("user_email", user.Email, ckOptions);
                            Response.Cookies.Append("user_password", loginModel.PasswordLogin, ckOptions);
                        }

                        return Json(new { isSuccess = true, _email = loginModel.EmailLogin, _password = loginModel.PasswordLogin, _rememberme = loginModel.RememberMe });
                    }
                }
            }
            return Json(new { isSuccess = false, _email = loginModel.EmailLogin, _password = loginModel.PasswordLogin, _rememberme = loginModel.RememberMe });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        public IActionResult Faqs()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(User user)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = PasswordHashHelper.HashPassword(user.Password);
                user.Password = passwordHash;
                user.UserTypeId = 1;
                user.Gender = 1;
                user.IsRegisteredUser = true;
                user.WorksWithPets = true;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = 1;
                user.IsApproved = true;
                user.IsActive = true;
                user.IsDeleted = false;
                user.DateOfBirth = new DateTime(2000, 8, 25);
                await userService.CreateAsync(user);
                return RedirectToAction("Registred", "Home");
            }
            return View();
        }


        public IActionResult BecomePro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomePro(User user)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = PasswordHashHelper.HashPassword(user.Password);
                user.Password = passwordHash;
                user.UserTypeId = 2;
                user.Gender = 1;
                user.IsRegisteredUser = true;
                user.WorksWithPets = true;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = 1;
                user.IsApproved = true;
                user.IsActive = true;
                user.IsDeleted = false;
                user.DateOfBirth = new DateTime(2000, 8, 25);
                await userService.CreateAsync(user);
                return RedirectToAction("Registred", "Home");
            }
            return View();
        }

        public IActionResult Registred()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            return Json("Email Address is already registered.");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsRegistredEmail(string emailForgot)
        {
            var user = await userService.GetUserByEmailAsync(emailForgot);
            if (user != null)
            {
                return Json(true);
            }
            return Json("Email Address is not registered.");
        }

        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsMobileInUse(string mobile)
        {
            var user = await userService.GetUserByMobileAsync(mobile);
            if (user == null)
            {
                return Json(true);
            }
            return Json("Mobile number is already registered.");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                User _user = await userService.GetUserByEmailAsync(forgotPasswordViewModel.EmailForgot);
                string token = AesTokenHelper.EncryptString($"{_user.UserId},{_user.Email}");
                string _url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Home/ForgotPasswordReset?token={token}";

                UserEmailOptions userEmailOptions = new UserEmailOptions
                {
                    ToEmails = new List<string> { _user.Email.ToString() },
                    Subject = "Password Reset | Helperland",
                    Body = "forgotTemplate",
                    Replaces = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("[Username]",_user.FirstName),
                        new KeyValuePair<string, string>("[Email]",_user.Email),
                        new KeyValuePair<string, string>("[url]",_url)
                    }
                };
                await emailService.SendEmail(userEmailOptions);
                return Json(new { isSuccessFP = true, _email = forgotPasswordViewModel.EmailForgot, user = _user });
            }
            return Json(new { isSuccessFP = false, _email = forgotPasswordViewModel.EmailForgot });
        }

        public IActionResult ForgotPasswordReset(string token)
        {
            ForgotPasswordResetViewModel forgotPassword = new ForgotPasswordResetViewModel
            {
                token = token
            };
            return View(forgotPassword);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPasswordReset(ForgotPasswordResetViewModel forgotPassword)
        {
            if (ModelState.IsValid)
            {
                string decPass = AesTokenHelper.DecryptString(forgotPassword.token);
                string[] userIdPass = decPass.Split(',');

                    if (userIdPass[0] != null)
                    {
                        User user = await userService.GetUserByIdAsync(int.Parse(userIdPass[0]));
                        if (user.Email == userIdPass[1])
                        {
                            user.Password = PasswordHashHelper.HashPassword(forgotPassword.Password);
                            User UpdatedUser = await userService.UpdateAsync(user);
                            return Json(new { isSuccessRP = true, isExpired = false });
                        }
                    }
                
            }
            return Json(new { isSuccessRP = false, isExpired = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
