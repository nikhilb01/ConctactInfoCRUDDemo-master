using AutoMapper;
using ConctactInfoCRUDDemo.Models;
using ContactInfo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConctactInfoCRUDDemo.Controllers
{
    public class ContactInfoController : ApiController
    {
        private readonly ContactInfoBL _contactInfoBL;

        public ContactInfoController(ContactInfoBL contactInfoBL)
        {
            _contactInfoBL = contactInfoBL;
        }

        //[HttpGet]
        //public IHttpActionResult GetAllContactInfo()
        //{
        //    try
        //    {
        //        var ContactInfoList = Mapper.Map<List<ContactInfo.DBEntities.Entities.ContactInfo>, List<ContactInfoViewModel>>(_contactInfoBL.GetAllContactInfo());

        //        if (ContactInfoList.Count == 0)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(ContactInfoList);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public IHttpActionResult SaveContactInfo([FromBody]ContactInfoViewModel contactInfoViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data.");

        //    var contactInfoModel = Mapper.Map<ContactInfoViewModel, ContactInfo.DBEntities.Entities.ContactInfo>(contactInfoViewModel);

        //    var status = _contactInfoBL.SaveContactInfo(contactInfoModel);

        //    if (status)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPost]
        //public IHttpActionResult EditContactInfo([FromBody]ContactInfoViewModel contactInfoViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data.");

        //    var contactInfoModel = Mapper.Map<ContactInfoViewModel, ContactInfo.DBEntities.Entities.ContactInfo>(contactInfoViewModel);

        //    var status = _contactInfoBL.EditContactInfo(contactInfoModel);

        //    if (status)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet]
        //public IHttpActionResult DeleteContactInfo([FromUri]int id)
        //{
        //    var status = _contactInfoBL.DeleteContactInfo(id);

        //    if (status)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("Not a valid contact id");
        //    }
        //}

    }
}
