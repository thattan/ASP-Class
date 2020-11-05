using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FordVSChevy.Models;

namespace FordVSChevy.Controllers
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
            // Admin role and Admin user
            x = await roleManager.RoleExistsAsync("Admin");     
            if (!x)
            {
                // create the admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);

                // create a admin user
                var user = new Models.ApplicationUser();
                user.UserName = "default";
                user.Email = "default@default.com";

                // assign password;
                string userPWD = "Some@Passwrd1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if(chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // Create Manager role and user
            x = await roleManager.RoleExistsAsync("Manager");
            if (!x)
            {
                // create the manager role
                var role = new IdentityRole();
                role.Name = "Manager";
                await roleManager.CreateAsync(role);

                // create a manager user
                var user = new Models.ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager@default.com";

                //needs to be a strong password
                string userPWD = "Some@Passwrd1234";  //for testing purposes same password for all roles

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Manager");
                }
            }

            // Create Employee role and user
            x = await roleManager.RoleExistsAsync("Employee");
            if (!x)
            {
                // create the admin role
                var role = new IdentityRole();
                role.Name = "Employee";
                await roleManager.CreateAsync(role);

                // create a admin user
                var user = new Models.ApplicationUser();
                user.UserName = "Employee";
                user.Email = "Employee@default.com";

                //needs to be a strong password
                string userPWD = "Some@Passwrd1234";

                IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Employee");
                }
            }
            return View(); // need to dress up the view

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}