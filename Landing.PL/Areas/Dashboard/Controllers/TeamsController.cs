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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TeamsController(ApplicationDbContext context, IMapper mapper)
  {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<TeamVM>>(context.Teams.ToList()));
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamFormVM teamFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(teamFormVM);
            }
            teamFormVM.ImageName = FileSettings.UploadFile(teamFormVM.Image, "images");

            var Team = mapper.Map<Team>(teamFormVM);
            context.Add(Team);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var Team = context.Teams.Find(Id);
            if (Team is null)
            {
                return NotFound();
            }

            return View(mapper.Map<TeamDetailsVM>(Team));
        }

        public IActionResult Edit(int Id)
        {
            var Team = context.Teams.Find(Id);
            if (Team is null)
            {
                return NotFound();
            }

            return View(mapper.Map<TeamFormVM>(Team));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamFormVM TeamFormVM)
        {

            var Team = context.Teams.Find(TeamFormVM.Id);
            if (Team is null)
            {
                return NotFound();
            }
            if (TeamFormVM.Image is null)
            {
                TeamFormVM.ImageName = Team.ImageName;
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(Team.ImageName, "images");
                TeamFormVM.ImageName = FileSettings.UploadFile(TeamFormVM.Image, "images");

            }

            if (!ModelState.IsValid)
            {
                return View(TeamFormVM);
            }


            mapper.Map(TeamFormVM, Team);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var Team = context.Teams.Find(id);
            if (Team is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(Team.ImageName, "images");
            context.Teams.Remove(Team);
            context.SaveChanges();

            return Ok(new { message = "Delete Team Successfully" });
        }
    }
}
