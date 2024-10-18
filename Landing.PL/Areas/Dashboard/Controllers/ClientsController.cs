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


    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ClientVM>>(context.Clients.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientFormVM clientFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(clientFormVM);
            }
            clientFormVM.ImageName = FileSettings.UploadFile(clientFormVM.Image, "images");

            var client = mapper.Map<Client>(clientFormVM);
            context.Add(client);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var client = context.Clients.Find(Id);
            if (client is null)
            {
                return NotFound();
            }

            return View(mapper.Map<ClientDetailsVM>(client));
        }

        public IActionResult Edit(int Id)
        {
            var client = context.Clients.Find(Id);
            if (client is null)
            {
                return NotFound();
            }

            return View(mapper.Map<ClientFormVM>(client));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientFormVM clientFormVM)
        {

            var client = context.Clients.Find(clientFormVM.Id);
            if (client is null)
            {
                return NotFound();
            }
            if (clientFormVM.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(client.ImageName, "images");
                clientFormVM.ImageName = FileSettings.UploadFile(clientFormVM.Image, "images");

            }

            if (!ModelState.IsValid)
            {
                return View(clientFormVM);
            }


            mapper.Map(clientFormVM, client);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var client = context.Clients.Find(id);
            if (client is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(client.ImageName, "images");
            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok(new { message = "Delete Client Successfully" });
        }


    }
}
