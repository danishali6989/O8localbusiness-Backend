using UserManagement.DataLayer;
using UserManagement.Entities;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Managers
{
    public class SeedManager : ISeedManager
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
      
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedManager(ILogger<SeedManager> logger,
            IUnitOfWork unitOfWork,
          
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            
            _roleManager = roleManager;
            _userManager = userManager;
            
        }

        public async Task InitializeAsync()
        {
            await SeedRolesAsync();
            await SeedAdminAsync();
           
        }

        private async Task SeedRolesAsync()
        {
            try
            {
                IdentityResult identityResult;

                if (!await _roleManager.Roles.AnyAsync(x => x.Name.Equals(Constants.UserType.Admin)))
                {
                    identityResult = await _roleManager.CreateAsync(new IdentityRole(Constants.UserType.Admin));
                    _logger.LogInformation($"Role ({Constants.UserType.Admin}) seed result: {identityResult}");
                }

                if (!await _roleManager.Roles.AnyAsync(x => x.Name.Equals(Constants.UserType.Employee)))
                {
                    identityResult = await _roleManager.CreateAsync(new IdentityRole(Constants.UserType.Employee));
                    _logger.LogInformation($"Role ({Constants.UserType.Employee}) seed result: {identityResult}");
                }

                _logger.LogInformation("Role seeding done.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Role seeding {ex}");
            }
        }

        private async Task SeedAdminAsync()
        {
            try
            {
                if (!await _roleManager.Roles.AnyAsync())
                {
                    _logger.LogError("Administrator seed failed, no role found");
                }

                var user = await _userManager.FindByNameAsync("admin");

                if (user != null)
                {
                    return;
                }

                user = new AppUser
                {
                    FirstName = "Administrator",
                    UserName = "admin",
                    Email = "admin@maplenet.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, "Password@123");

                if (!result.Succeeded)
                {
                    _logger.LogError("Administrator seed failed");
                    _logger.LogError(string.Join(",", result.Errors.Select(x => x.Description)));
                    return;
                }

                result = await _userManager.AddToRoleAsync(user, Constants.UserType.Admin);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Administrator seed completed");
                    return;
                }

                _logger.LogError("Administrator seed failed");
                _logger.LogError(string.Join(",", result.Errors.Select(x => x.Description)));

                await _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in administrator seeding {ex}");
            }
        }

    
    }
}
