using ContactInfo.DataAccess.RepositoryInterfaces;
//using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.DataAccess.Repositories
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        //public List<DBEntities.Entities.ContactInfo> GetAllContactInfo()
        //{
        //    using (ContactInfoDBEntities ctx = new ContactInfoDBEntities())
        //    {
        //        return ctx.ContactInfoes.Where(x => x.IsActive).ToList();
        //    }
        //}

        //public bool SaveContactInfo(DBEntities.Entities.ContactInfo contactInfo)
        //{
        //    using (var ctx = new ContactInfoDBEntities())
        //    {
        //        ctx.ContactInfoes.Add(new DBEntities.Entities.ContactInfo()
        //        {
        //            FirstName = contactInfo.FirstName,
        //            LastName = contactInfo.LastName,
        //            PhoneNumber = contactInfo.PhoneNumber,
        //            Email = contactInfo.Email,
        //            IsActive = contactInfo.IsActive
        //        });

        //        ctx.SaveChanges();
        //        return true;
        //    }
        //}

        //public bool EditContactInfo(DBEntities.Entities.ContactInfo contactInfo)
        //{
        //    using (var ctx = new ContactInfoDBEntities())
        //    {
        //        var existingContactInfo = ctx.ContactInfoes.Where(c => c.Id == contactInfo.Id)
        //                                            .FirstOrDefault();

        //        if (existingContactInfo != null)
        //        {
        //            existingContactInfo.FirstName = contactInfo.FirstName;
        //            existingContactInfo.LastName = contactInfo.LastName;
        //            existingContactInfo.PhoneNumber = contactInfo.PhoneNumber;
        //            existingContactInfo.Email = contactInfo.Email;
        //            existingContactInfo.IsActive = contactInfo.IsActive;
        //            ctx.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //public bool DeleteContactInfo(int id)
        //{
        //    if (id <= 0)
        //        return false;

        //    using (var ctx = new ContactInfoDBEntities())
        //    {
        //        var contactinfo = ctx.ContactInfoes
        //       .Where(s => s.Id == id)
        //       .FirstOrDefault();

        //        if (contactinfo != null)
        //        {
        //            contactinfo.IsActive = false;
        //            ctx.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
