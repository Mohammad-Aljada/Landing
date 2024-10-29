using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Helper;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;

        public ServicesController(ILogger<ServicesController> logger, ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var ser = context.Services.Where(s=>!s.IsDeleted).ToList();
            var services = mapper.Map<IEnumerable<ServiceDisplayVM>>(ser);
            var prices = mapper.Map<IEnumerable<PriceDisplayVM>>(context.Prices.ToList());
            ViewData[nameof(services)] = services;
            ViewData[nameof(prices)] = prices;
            return View();
        }

        public IActionResult Details(int Id)
        {
            var service = context.Services.Find(Id);
            if (service == null)
            {
                return NotFound();
            }
            var serviceDisplay = mapper.Map<ServiceDisplayVM>(service);
            var services = ViewData["services"] as IEnumerable<ServiceDisplayVM>;

            ViewData[nameof(serviceDisplay)] = serviceDisplay;
            ViewData[nameof(services)] = services;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpgradePlan(int priceId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found."); 
            }

            var selectedPrice = await context.Prices.FirstOrDefaultAsync(p => p.Id == priceId);
            if (selectedPrice == null)
            {
                return BadRequest("Selected plan does not exist."); 
            }

            user.PriceId = selectedPrice.Id;
            user.Price = selectedPrice;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
               
                var email = new Email
                {
                    Recivers = user.Email,
                    Subject = "Plan Upgrade Confirmation",
                    Body = $"Hello {user.UserName},\n\n" +
                           $"Your account has been successfully upgraded to the {selectedPrice.Name}, {selectedPrice.FinalPrice}$ plan.\n\n" +
                           $"For Payment Purches Contact us by Email or PhoneNumber" +
                           $"Thank you for upgrading!\n\nBest Regards,\nYour Company Team"
                };
                EmailSettings.SendEmail(email);

                return Ok();
            }

            return BadRequest("Failed to upgrade plan."); 
        }




    }
}