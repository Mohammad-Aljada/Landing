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


    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SkillsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<SkillVM>>(context.Skills.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SkillFormVM skillFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(skillFormVM);
            }

            var skill = mapper.Map<Skill>(skillFormVM);
            context.Add(skill);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var skill = context.Skills.Find(Id);
            if (skill is null)
            {
                return NotFound();
            }

            return View(mapper.Map<SkillDetailsVM>(skill));
        }

        public IActionResult Edit(int Id)
        {
            var skill = context.Skills.Find(Id);
            if (skill is null)
            {
                return NotFound();
            }

            return View(mapper.Map<SkillFormVM>(skill));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SkillFormVM skillFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(skillFormVM);
            }

            var skill = context.Skills.Find(skillFormVM.Id);
            if (skill is null)
            {
                return NotFound();
            }

            mapper.Map(skillFormVM, skill);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var skill = context.Skills.Find(id);
            if (skill is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Skills.Remove(skill);
            context.SaveChanges();

            return Ok(new { message = "Delete  Skill Successfully" });
        }

    }
}
