using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kingpim.Services.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        AccountRepository(SignInManager<ApplicationUser> signInMan)
        {
            _signInManager = signInMan;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var result = await _signInManager
                .PasswordSignInAsync(loginDto.Email, loginDto.Password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return "Sucess";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
