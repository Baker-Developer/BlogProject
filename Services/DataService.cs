using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;
        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            // Task: Create The DataBase From The Migrations
            await _dbContext.Database.MigrateAsync(); 

            // Task 1: Seeding A Few ROLES Into The System
            await SeedRolesAsync();

            // Task 2: Seed A Few USERS Into The System
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            // If There Are Already Roles In The System, Do Nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            // Otherwise we want to create a few roles;
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                // Use The Role Manager To Create Roles
                await _roleManager.CreateAsync(new IdentityRole(role));

            }


        }

        private async Task SeedUsersAsync()
        {
            // If There Are Already USERS In The System, Do Nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }

            // Task 1: Create A New Instance Of Blog User
            var adminUser = new BlogUser()
            {
                Email = "benjamin@bakermedical.net",
                UserName = "benjamin@bakermedical.net",
                FirstName = "Benjamin",
                LastName = "Baker",
                DisplayName = "Administrator User",
                PhoneNumber = "5013393105",
                EmailConfirmed = true
            };

            // Step 2: Use The UserManager To Create A New User That Is Defined By adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            // Step 3: Add This User To The Administrator Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            // Task 1 Repeat: Create A New Instance Of Moderator User
            var moderatorUser = new BlogUser()
            {
                Email = "benjaminbaker1122@gmail.com",
                UserName = "benjaminbaker1122@gmail.com",
                FirstName = "Benjamin",
                LastName = "Baker",
                DisplayName = "Moderator User",
                PhoneNumber = "5013393105",
                EmailConfirmed = true
            };

            // Step 2: Use The UserManager To Create A New User That Is Defined By adminUser
            await _userManager.CreateAsync(moderatorUser, "Abc&123!");

            // Step 3: Add This User To The Administrator Role
            await _userManager.AddToRoleAsync(moderatorUser, BlogRole.Administrator.ToString());
        }

    }
}

