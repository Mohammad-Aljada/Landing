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


    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BlogsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<BlogVM>>(context.Blogs.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogFormVM blogFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(blogFormVM);
            }


            blogFormVM.ImageName = FileSettings.UploadFile(blogFormVM.Image, "images");

            var blog = mapper.Map<Blog>(blogFormVM);
            context.Add(blog);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var blog = context.Blogs.Find(Id);
            if (blog is null)
            {
                return NotFound();
            }

            return View(mapper.Map<BlogDetailsVM>(blog));
        }

        public IActionResult Edit(int Id)
        {
            var blog = context.Blogs.Find(Id);
            if (blog is null)
            {
                return NotFound();
            }

            return View(mapper.Map<BlogFormVM>(blog));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogFormVM blogFormVM)
        {
          

            var blog = context.Blogs.Find(blogFormVM.Id);
            if (blog is null)
            {
                return NotFound();
            }
            if (blogFormVM.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(blog.ImageName, "images");
                blogFormVM.ImageName = FileSettings.UploadFile(blogFormVM.Image, "images");

            }

            if (!ModelState.IsValid)
            {
                return View(blogFormVM);
            }


            mapper.Map(blogFormVM, blog);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var blog = context.Blogs.Find(id);
            if (blog is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Blogs.Remove(blog);
            context.SaveChanges();

            return Ok(new { message = "Delete  Blog Successfully" });
        }

    }
}
