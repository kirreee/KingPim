using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(IUserRepository userRepository, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        [HttpGet, Route("isAuthenticated")]
        public bool CheckUserIsLoggedIn()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            return isAuthenticated;
        }

        [HttpPost, Route("Logout")]
        public async Task<string> LogOut()
        {
            await _signInManager.SignOutAsync();

            return "Success";
        }

        [HttpPost, Route("Login")]
        public async Task<string> Login(LoginDto loginDto)
        {
            var response = await _userRepository.Login(loginDto);

            if (response.Contains("Success"))
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