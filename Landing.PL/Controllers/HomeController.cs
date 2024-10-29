using AutoMapper;
using Landing.DAL.Data;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Landing.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context , IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var sli = context.Sliders.Where(s => !s.IsDeleted).ToList();

            var sliders = mapper.Map<IEnumerable<SliderDisplayVM>>(sli);
            var ser = context.Services.Where(s => !s.IsDeleted).ToList();
            var services = mapper.Map<IEnumerable<ServiceDisplayVM>>(ser); ViewData[nameof(sliders)] = sliders;
            ViewData[nameof (services)] = services;
            return View();
        }

        public IActionResult Privacy()
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
