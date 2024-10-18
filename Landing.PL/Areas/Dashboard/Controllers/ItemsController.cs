using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin , SuperAdmin")]

    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = context.Items.Include(i=>i.Portfolio).ToList();
            return View(mapper.Map<IEnumerable<ItemVM>>(items));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var portfolios = context.Portfolios.ToList();
            var vm = new ItemFormVM
            {
                Portfolios = new SelectList(portfolios, "Id", "Name")
            }; 
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemFormVM ItemFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ItemFormVM);
            }
            ItemFormVM.ImageName = FileSettings.UploadFile(ItemFormVM.Image, "images");

            var Item = mapper.Map<Item>(ItemFormVM);
            context.Add(Item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var Item = context.Items.Include(i=>i.Portfolio).FirstOrDefault(i=>i.Id==Id);
            if (Item is null)
            {
                return NotFound();
            }

            return View(mapper.Map<ItemDetailsVM>(Item));
        }

        public IActionResult Edit(int Id)
        {
            var item = context.Items
                    .Include(i => i.Portfolio) // Adjust to your navigation property for portfolios
                    .FirstOrDefault(i => i.Id == Id);
            if (item is null)
            {
                return NotFound();
            }
            var itemFormVM = mapper.Map<ItemFormVM>(item);

            var portfolios = context.Portfolios.ToList();
            itemFormVM.Portfolios = new SelectList(portfolios, "Id", "Name");

            itemFormVM.PortfolioId = item.PortfolioId; 

            return View(itemFormVM);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemFormVM itemFormVM)
        {
            var item = context.Items.Include(i => i.Portfolio).FirstOrDefault(i => i.Id == itemFormVM.Id);

            if (item is null)
            {
                return NotFound();
            }
            if (itemFormVM.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(item.ImageName, "images");
                itemFormVM.ImageName = FileSettings.UploadFile(itemFormVM.Image, "images");

            }

            if (!ModelState.IsValid)
            {
                return View(itemFormVM);
            }


            mapper.Map(itemFormVM, item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var item = context.Items.Find(id);
            if (item is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(item.ImageName, "images");
            context.Items.Remove(item);
            context.SaveChanges();

            return Ok(new { message = "Delete Item Successfully" });
        }

    }
}
