using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kingpim.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRepository(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var result = await _signInManager
                  .PasswordSignInAsync(loginDto.Email, loginDto.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
