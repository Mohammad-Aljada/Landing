using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin , SuperAdmin")]


    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SlidersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<SliderVM>>(context.Sliders.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderFormVM sliderFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderFormVM);
            }
            sliderFormVM.ImageName = FileSettings.UploadFile(sliderFormVM.Image, "images");

            var slider = mapper.Map<Slider>(sliderFormVM);
            context.Add(slider);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var slider = context.Sliders.Find(Id);
            if (slider is null)
            {
                return NotFound();
            }

            return View(mapper.Map<SliderDetailsVM>(slider));
        }

        public IActionResult Edit(int Id)
        {
            var slider = context.Sliders.Find(Id);
            if (slider is null)
            {
                return NotFound();
            }

            return View(mapper.Map<SliderFormVM>(slider));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderFormVM sliderFormVM)
        {
            var slider = context.Sliders.Find(sliderFormVM.Id);
            if (slider is null)
            {
                return NotFound();
            }

            if (sliderFormVM.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(slider.ImageName, "images");
                sliderFormVM.ImageName = FileSettings.UploadFile(sliderFormVM.Image, "images");

            }
            if (!ModelState.IsValid)
            {
                return View(sliderFormVM);
            }
            
            mapper.Map(sliderFormVM, slider);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var slider = context.Sliders.Find(id);
            if (slider is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(slider.ImageName, "images");
            context.Sliders.Remove(slider);
            context.SaveChanges();

            return Ok(new { message = "Delete Slider Successfully" });
        }
    }
}
