using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment8.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMgr)

        {
            roleManager = roleMgr;
            userManager = userMgr;

        }

        public async Task<IActionResult> AddRole()
        {
            bool x;
            x = await roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "adminpassword123!";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");
                }
            }



            x = await roleManager.RoleExistsAsync("Manager");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                await roleManager.CreateAsync(role);

                var user = new Models.ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager@manager.com";

                string userPWD = "managerpassword123!"; 

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Manager");
                }
            }

    
            return View();

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}