using AutoMapper;
using Landing.DAL.Data;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TeamsController(ILogger<TeamsController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var teams = mapper.Map<IEnumerable<TeamDisplayVM>>(context.Teams.ToList());
            ViewData[nameof(teams)] = teams;
            return View();
        }
    }
}
