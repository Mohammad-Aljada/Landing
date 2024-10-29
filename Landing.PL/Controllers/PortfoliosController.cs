using AutoMapper;
using Landing.DAL.Data;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly ILogger<PortfoliosController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoliosController(ILogger<PortfoliosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var por = context.Portfolios.Where(s => !s.IsDeleted).ToList();
            var portfolios = mapper.Map<IEnumerable<PortfolioDisplayVM>>(por);
            var Items = mapper.Map<IEnumerable<ItemDisplayVM>>(context.Items.ToList());
            ViewData[nameof(portfolios)] = portfolios;
            ViewData[nameof(Items)] = Items;
            return View();
        }
        public IActionResult Details(int Id)
        {
            var item = context.Items.Include(i => i.Portfolio).FirstOrDefault(p=>p.Id==Id);
            if (item == null)
            {
                return NotFound();
            }
            var itemDetails = mapper.Map<ItemDisplayVM>(item);

            ViewData[nameof(itemDetails)] = itemDetails;

            return View();
        }
    }
}
