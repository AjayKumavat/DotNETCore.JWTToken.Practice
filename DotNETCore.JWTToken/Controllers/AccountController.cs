using DotNETCore.JWTToken.Models;
using DotNETCore.JWTToken.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNETCore.JWTToken.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        [Produces(typeof(bool))]
        public async Task<string> Login(UserDTO user)
        {
            var creds = await _accountService.Login(user);
            if(creds == true)
            {
                return _tokenService.CreateToken(user);
            }
            return "Invalid Credentials!";
        }
    }
}
