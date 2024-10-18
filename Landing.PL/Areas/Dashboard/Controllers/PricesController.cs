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

    public class PricesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PricesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<PriceVM>>(context.Prices.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PriceFormVM priceFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(priceFormVM);
            }

            if (priceFormVM.Discount > 0 && priceFormVM.Discount <= 100)
            {
                priceFormVM.FinalPrice = priceFormVM.InitalPrice * (1 - (priceFormVM.Discount / 100m));
            }
            else
            {
                priceFormVM.FinalPrice = priceFormVM.InitalPrice; 
            }

            var price = mapper.Map<Price>(priceFormVM);
            context.Add(price);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var price = context.Prices.Find(Id);
            if (price is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PriceDetailsVM>(price));
        }

        public IActionResult Edit(int Id)
        {
            var price = context.Prices.Find(Id);
            if (price is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PriceFormVM>(price));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PriceFormVM priceFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(priceFormVM);
            }

            var price = context.Prices.Find(priceFormVM.Id);
            if (price is null)
            {
                return NotFound();
            }
            if (priceFormVM.Discount > 0 && priceFormVM.Discount <= 100)
            {
                priceFormVM.FinalPrice = priceFormVM.InitalPrice * (1 - (priceFormVM.Discount / 100m));
            }
            else
            {
                priceFormVM.FinalPrice = priceFormVM.InitalPrice;
            }
            mapper.Map(priceFormVM, price);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var price = context.Prices.Find(id);
            if (price is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Prices.Remove(price);
            context.SaveChanges();

            return Ok(new { message = "Delete  price Successfully" });
        }
    }
}
