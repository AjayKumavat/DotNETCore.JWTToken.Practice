using DotNETCore.JWTToken.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNETCore.JWTToken.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> Login(UserDTO user);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(UserDTO user)
        {
            var userCreds = await _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefaultAsync();
            if(userCreds != null)
            {
                return true;
            }
            return false;
        }
    }
}
