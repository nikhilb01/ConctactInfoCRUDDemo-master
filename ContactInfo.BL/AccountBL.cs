using ContactInfo.BL.BusinessInterfaces;
using ContactInfo.DataAccess.RepositoryInterfaces;
using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.BL
{
    public class AccountBL : IAccountBL
    {
        private readonly IAccountRepository _accountRepository;
        public AccountBL(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public int SignUp(UserDetail userDetail)
        {
           return  _accountRepository.SignUp(userDetail);
        }
        public List<UserDetail> GetAllUserDetails()
        {
            return _accountRepository.GetAllUserDetails();
        }
        public bool SignIn(UserDetail userDetail)
        {
            return _accountRepository.SignIn(userDetail);
        }
    }
}
