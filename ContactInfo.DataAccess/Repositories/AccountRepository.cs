using ContactInfo.DataAccess.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactInfo.DBEntities.Entities;
namespace ContactInfo.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public int SignUp(UserDetail userDetail)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                ctx.UserDetails.Add(new DBEntities.Entities.UserDetail()
                {
                    UserName = userDetail.UserName,
                    Password = userDetail.Password,
                    MobileNumber = userDetail.MobileNumber,
                    Email = userDetail.Email,
                    IsSuperAdmin = userDetail.IsSuperAdmin,
                    CreatedOn = userDetail.CreatedOn
                });

                ctx.SaveChanges();
                int id = ctx.UserDetails.SingleOrDefault(u => u.UserName.ToLower() == userDetail.UserName.ToLower()).Id;
                return id;
            }
        }

        public List<UserDetail> GetAllUserDetails()
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                return ctx.UserDetails.ToList();
            }

        }

        public bool SignIn(UserDetail userDetail)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                return ctx.UserDetails.Any(u => u.UserName.ToLower() == userDetail.UserName.ToLower() && u.Password == userDetail.Password);
            }
        }
    }
}
