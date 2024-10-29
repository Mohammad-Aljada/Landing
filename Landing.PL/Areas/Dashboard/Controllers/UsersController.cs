using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin , SuperAdmin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(ApplicationDbContext context, IMapper mapper , UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users
        .Include(u => u.Price) // Ensure you include the Price navigation property
        .ToListAsync();

            // Now process the users after they have been retrieved
            var viewModel = new List<UserVM>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user); // Get roles asynchronously
                viewModel.Add(new UserVM
                {
                    Id = user.Id, // Assuming Id is of type string
                    UserName = user.UserName,
                    Email = user.Email,
                    Price = user.Price?.Name ?? "No Price", // Display price name or a fallback
                    RoleName = roles.FirstOrDefault() ?? "No Role" // Assuming single role
                });
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Details(string id)
        {
            var user = await userManager.Users
        .Include(u => u.Price) 
        .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Get the user's roles
            var userRoles = await userManager.GetRolesAsync(user);

            var viewModel = mapper.Map<UserDetailsVM>(user);

            viewModel.RoleName = userRoles.FirstOrDefault() ?? "No Role";

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new UserFormVM
            {
                Prices = new SelectList(context.Prices, "Id", "Name"),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate dropdowns if model state is invalid
                viewModel.Prices = new SelectList(await context.Prices.ToListAsync(), "Id", "Name");
                return View(viewModel);
            }

            // Create a new ApplicationUser instance
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(), // Generate a new GUID as string
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                Address = viewModel.Address,
                PhoneNumber = viewModel.PhoneNumber,
                ImageName = FileSettings.UploadFile(viewModel.Image, "images") // Handle image upload
            };

            var result = await userManager.CreateAsync(user, viewModel.Password); // Add a Password property in UserFormVM
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User"); // Add default role


                return RedirectToAction(nameof(Index)); // Redirect to the index after successful creation
            }

           

            viewModel.Prices = new SelectList(await context.Prices.ToListAsync(), "Id", "Name");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var role = userRoles.FirstOrDefault();

            var viewModel = new UserFormVM
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                ImageName = user.ImageName,
                PriceId = user.Price?.Id ?? 0,
                RoleId = role // Directly assigning the role name
            };

            // Populate Prices and Roles for dropdowns
            viewModel.Prices = new SelectList(await context.Prices.ToListAsync(), "Id", "Name");
            viewModel.Roles = new SelectList(await context.Roles.ToListAsync(), "Id", "Name");

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserFormVM viewModel)
        {
            var user = context.Users.Include(i => i.Price).FirstOrDefault(i => i.Id == viewModel.Id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            // Handle image upload
            if (viewModel.Image != null)
            {
                FileSettings.DeleteFile(user.ImageName, "images"); // Delete old image
                user.ImageName = FileSettings.UploadFile(viewModel.Image, "images"); // Upload new image
            }
            else
            {
                ModelState.Remove("Image"); // If no new image, remove from model state validation
            }
            if (!ModelState.IsValid)
            {
                // Handle ModelState errors
                return View(viewModel);
            }
            var userRoles = await userManager.GetRolesAsync(user);
            var currentRole = userRoles.FirstOrDefault(); 
            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name == currentRole); // Find the role in the database

            await userManager.RemoveFromRoleAsync(user, role.Name );
            var newRole = await context.Roles.FindAsync(viewModel.RoleId);
            if (newRole != null)
            {
                await userManager.AddToRoleAsync(user, newRole.Name);
            }



            mapper.Map(viewModel, user);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (!string.IsNullOrEmpty(user.ImageName))
            {
                FileSettings.DeleteFile(user.ImageName, "images");
            }

            await userManager.DeleteAsync(user);
          
            return Ok(new { message = "Delete User Successfully" });

        }
        }
}
