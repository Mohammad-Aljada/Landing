using Landing.DAL.Models;
using Landing.PL.Helper;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Common;

namespace Landing.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email,
                    Address = registerVM.Address,
                    PhoneNumber = registerVM.PhoneNumber,
                };
                user.ImageName = FileSettings.UploadFile(registerVM.Image, "images");
                var result = await userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmEmailUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);
                    var email = new Email()
                    {
                        Subject = "Confirm Email",
                        Recivers = registerVM.Email,
                        Body = $"please confirm for account on click in this link :{confirmEmailUrl}"
                    };
                    EmailSettings.SendEmail(email);
                    await userManager.AddToRoleAsync(user, "User");
                    return Ok(new { success = true, message = "Registration successful. Please check your email to confirm your account." });
                }
                return BadRequest(new { success = false, message = "Registration failed. Please check the input data." });

            }
            return BadRequest(new { success = false, message = "Invalid registration data." });
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user is not null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var check = await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return Ok(new { success = true, message = "Login successful. Welcome." });
                        }
                        else
                        {
                            return BadRequest(new { success = false, message = "Login failed. Please check the input data." });
                        }
                    }
                    return BadRequest(new { success = false, message = "Invalid login data." });
                }
                return BadRequest(new { success = false, message = "User not found." });
            }
            return BadRequest(new { success = false, message = "Invalid input. Please check the data and try again." });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> SendResetPasswordUrl(ForgotPasswordVM forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgotPassword.Email);
                if (user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPassordUrl = Url.Action("ResetPassword", "Account", new { email = forgotPassword.Email, token = token }, protocol: HttpContext.Request.Scheme);
                    var email = new Email()
                    {
                        Subject = "Reset Password",
                        Recivers = forgotPassword.Email,
                        Body = resetPassordUrl
                    };
                    EmailSettings.SendEmail(email);
                }
            }

            return View(forgotPassword);
        }

        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user is not null)
            {
                var result = await userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(resetPasswordVM);
        }
        public async Task<IActionResult> Profile()
        {
            var userId = userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login"); 
            }

            var user = await userManager.Users.Include(u => u.Price)
                .FirstOrDefaultAsync(u => u.Id == userId); if (user == null)
            {
                return NotFound();
            }

            var profileViewModel = new ProfileVM
            {
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                ImageName = user.ImageName,
                Price = user.Price != null ? user.Price.Name : "Not Available", 
            };

            return View(profileViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Login", "Account", new { area = "" });
        }

    }
}
