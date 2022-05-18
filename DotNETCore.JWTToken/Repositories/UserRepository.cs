using DotNETCore.JWTToken.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNETCore.JWTToken.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserDetails();
        Task<User> GetById(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUserDetails()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
