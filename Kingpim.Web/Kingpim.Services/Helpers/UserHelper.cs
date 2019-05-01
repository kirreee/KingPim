using Kingpim.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kingpim.Services.Helpers
{
    public enum UserRole
    {
        Administrator, Publisher, Editor
    }

    public class UserHelper
    {
        IServiceProvider _serviceProvider;

        public UserHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task CreateRoles()
        {
            
            var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator ", "Publisher", "Editor"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
               
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async Task CreateSuperAdmin(string userEmail, string password)
        {
            await CreateUser(userEmail, password, UserRole.Administrator);
        }

        public async Task CreateUser(string userEmail, string password, UserRole permission)
        {
            string role = permission.ToString();
            var UserManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var newUser = new ApplicationUser
            {
                UserName = userEmail,
                Email = userEmail,
            };

            string UserPassword = password;
            var _user = await UserManager.FindByEmailAsync(userEmail);

            if (_user == null)
            {
                var createNewUser = await UserManager.CreateAsync(newUser, UserPassword);
                if (createNewUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(newUser, role);
                }
            }
        }
    }
}
