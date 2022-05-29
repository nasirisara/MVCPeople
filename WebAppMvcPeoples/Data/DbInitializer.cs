using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPeople.Models;

namespace MVCPeople.Data
{
    internal class DbInitializer
    {
        internal static async Task InitializeAsync(
            PeopleDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager)
        {
            context.Database.EnsureCreated();
           

            if (context.Roles.Any())
            {
                IdentityRole role = new IdentityRole("SuperAdmin");
                IdentityResult result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    ErrorMessages(result);
                }
                
                AppUser appUser = new AppUser
                {
                    FirstName = "Super",
                    LastName = "SuperAdmin",
                    DateOfBirth = DateTime.Now,
                    UserName = "SuperAdmin",
                    Email = "superadmin@admin.se"
                };
                IdentityResult userResult = await userManager.CreateAsync(appUser, "3MjaU64ByvLu7MU!!");
                if (!userResult.Succeeded)
                {
                    ErrorMessages(userResult);
                }
                userManager.AddToRoleAsync(appUser, role.Name).Wait();
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                IdentityRole roleA = new IdentityRole("Admin");
                IdentityResult resultA = await roleManager.CreateAsync(roleA);

                if (!resultA.Succeeded)
                {
                    ErrorMessages(resultA);
                }
                
                AppUser appUser = new AppUser
                {
                    FirstName = "Admina",
                    LastName = "Admin",
                    DateOfBirth = DateTime.Now,
                    UserName = "Admin",
                    Email = "admina@admin.se"
                };
                IdentityResult identityResult = await userManager.CreateAsync(appUser, "64Byv3MijaULu7MU!!");
                if (!identityResult.Succeeded)
                {
                    ErrorMessages(identityResult);
                }
                userManager.AddToRoleAsync(appUser, roleA.Name).Wait();
            }
        }

        private static void ErrorMessages(IdentityResult identityResult)
        {
            string errors = "";
            foreach (var error in identityResult.Errors)
            {
                errors += error.Code + ", " + error.Description;
            }
            throw new Exception(errors);
        }
    }
}
