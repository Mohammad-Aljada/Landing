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
    [Authorize(Roles ="Admin , SuperAdmin")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {        
            return View(mapper.Map<IEnumerable<ServiceVM>>(context.Services.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM serviceFormVM)
        {
            if (!ModelState.IsValid) { 
                return View(serviceFormVM);
            }
          serviceFormVM.ImageName = FileSettings.UploadFile(serviceFormVM.Image, "images");
            
            var service = mapper.Map<Service>(serviceFormVM);
            context.Add(service);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var service = context.Services.Find(Id);
            if(service is null)
            {
                return NotFound();
            }

            return View(mapper.Map<ServiceDetailsVM>(service));
        }

        public IActionResult Edit(int Id)
        {
            var service = context.Services.Find(Id);
            if (service is null)
            {
                return NotFound();
            }

            return View(mapper.Map<ServiceFormVM>(service));
        }
     [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ServiceFormVM serviceFormVM)
        {

            var service = context.Services.Find(serviceFormVM.Id);
            if (service is null)
            {
                return NotFound();
            }
            if(serviceFormVM.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
               FileSettings.DeleteFile(service.ImageName, "images");
               serviceFormVM.ImageName = FileSettings.UploadFile(serviceFormVM.Image, "images");

            }

            if (!ModelState.IsValid) {
                return View(serviceFormVM);
            }
           

            mapper.Map(serviceFormVM, service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(service.ImageName , "images");
            context.Services.Remove(service);
            context.SaveChanges();

            return Ok(new {message="Delete Service Successfully"});
        }


        }


    }
