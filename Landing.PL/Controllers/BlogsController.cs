using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Landing.PL.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BlogsController(ILogger<BlogsController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5; // Number of blogs per page
            var totalBlogs = context.Blogs.Count(); // Total number of blogs

            // Fetch the current page of blogs
            var blogs = context.Blogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var blogVMs = mapper.Map<IEnumerable<BlogDisplayVM>>(blogs);

            // Pass pagination data using ViewData
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalBlogs / (double)pageSize);
            ViewData["PageSize"] = pageSize;

            ViewData[nameof(blogVMs)] = blogVMs;
            return View();
        }
        public IActionResult Details(int Id)
        {
            var blog = context.Blogs.Include(b => b.Comments).ThenInclude(c => c.User)
                                          .FirstOrDefault(b => b.Id == Id);
            if (blog == null)
            {
                return NotFound();
            }
            var blogDetails = mapper.Map<BlogDisplayVM>(blog);

            ViewData[nameof(blogDetails)] = blogDetails;

            return View();
        }
        [HttpPost]
        public IActionResult AddComment(CommentVM commentVM)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (commentVM.BlogId == 0)
            {
                return BadRequest(ModelState);
            }

            var blogExists = context.Blogs.Any(b => b.Id == commentVM.BlogId);
            if (!blogExists)
            {
                return BadRequest(ModelState);
            }

            var comment = new Comment
            {
                BlogId = commentVM.BlogId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Content = commentVM.Content,
                CreatedAt = DateTime.Now
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            return RedirectToAction("Details", new { id = commentVM.BlogId });
        }




    }

}
