using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Helper;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ContactController(ILogger<ContactController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactFormVM form)
        {
            if (ModelState.IsValid)
            {
                string emailBody = $"Name: {form.UserName}\nEmail: {form.Email}\n\nMessage:\n{form.Body}";

                var emailMessage = new Email
                {
                    Recivers = "mohammadaljad.1234@gmail.com",
                    Subject = form.Subject,
                    Body = emailBody
                    
                };

                try
                {
                    EmailSettings.SendEmail(emailMessage);
                    TempData["Message"] = "Your message has been sent successfully!";
                   
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "There was an error sending your message. Please try again later.";
                    return View(form);

                }
            }

            return View(form);
        }
    }
}
