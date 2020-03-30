using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid_19_Tracker.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Covid_19_Tracker.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        public readonly UserManager<IdentityUser> _userManager;

        public AdminController(
            ILogger<AdminController> logger,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var adminViewModel = new AdminViewModel 
            { 
                Admins = await _userManager.GetUsersInRoleAsync("Admin"),
                Managers = await _userManager.GetUsersInRoleAsync("Manager"),
                Users = await _userManager.GetUsersInRoleAsync("User")
            };

            return View(adminViewModel);
        }

        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Admin");
        }


    }
}