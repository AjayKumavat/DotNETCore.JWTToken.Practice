using DotNETCore.JWTToken.Models;
using DotNETCore.JWTToken.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNETCore.JWTToken.Controllers
{
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetToken")]
        [Produces(typeof(string))]
        public string CreateToken(UserDTO user)
        {
            return _tokenService.CreateToken(user);
        }
    }
}
