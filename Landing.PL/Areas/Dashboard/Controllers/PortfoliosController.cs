using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin , SuperAdmin")]


    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoliosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<PortfolioVM>>(context.Portfolios.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioFormVM portfolioFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioFormVM);
            }

            var portfolio = mapper.Map<Portfolio>(portfolioFormVM);
            context.Add(portfolio);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var portfolio = context.Portfolios.Find(Id);
            if (portfolio is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PortfolioDetailsVM>(portfolio));
        }

        public IActionResult Edit(int Id)
        {
            var portfolio = context.Portfolios.Find(Id);
            if (portfolio is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PortfolioFormVM>(portfolio));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PortfolioFormVM portfolioFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(portfolioFormVM);
            }

            var portfolio = context.Portfolios.Find(portfolioFormVM.Id);
            if (portfolio is null)
            {
                return NotFound();
            }
         
            mapper.Map(portfolioFormVM, portfolio);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var portfolio = context.Portfolios.Find(id);
            if (portfolio is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Portfolios.Remove(portfolio);
            context.SaveChanges();

            return Ok(new { message = "Delete  portfolio Successfully" });
        }
    }
}
