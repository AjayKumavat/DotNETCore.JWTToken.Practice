using DotNETCore.JWTToken.Models;
using DotNETCore.JWTToken.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNETCore.JWTToken.Services
{
    public interface IAccountService
    {
        Task<bool> Login(UserDTO user);
    }
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> Login(UserDTO user)
        {
            return await _accountRepository.Login(user);
        }
    }
}
