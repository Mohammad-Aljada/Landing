using AutoMapper;
using Landing.DAL.Data;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AboutController(ILogger<AboutController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var cli = context.Clients.Where(s => !s.IsDeleted).ToList();

            var clients = mapper.Map<IEnumerable<ClientDisplayVM>>(cli);
            var skill = context.Skills.Where(s => !s.IsDeleted).ToList();

            var skills = mapper.Map<IEnumerable<SkillDisplayVM>>(skill);
            ViewData[nameof(clients)] = clients;
            ViewData[nameof(skills)] = skills;

            return View();
        }
    }
}
