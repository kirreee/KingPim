using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        
        public UsersController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost, Route("account/login")]
        public async Task<string> UserLogin(LoginDto loginDto)
        {
            var responseMessage = await _accountRepository.Login(loginDto);

            if(responseMessage == "Success")
            {
                return "Success";
            }
            else
            {
                return "Error";
            }
        }
    }
}