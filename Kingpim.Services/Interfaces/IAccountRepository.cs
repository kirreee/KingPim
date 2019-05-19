using Kingpim.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kingpim.Services.Interfaces
{
    public interface IAccountRepository
    {
        Task<string> Login(LoginDto loginDto);
    }
}
