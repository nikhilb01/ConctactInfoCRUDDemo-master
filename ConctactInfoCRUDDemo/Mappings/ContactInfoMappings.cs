using AutoMapper;
using ConctactInfoCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Mappings
{
    public class ContactInfoMappings : Profile
    {
        public ContactInfoMappings()
        {
            //CreateMap<ContactInfoViewModel, ContactInfo.DBEntities.Entities.ContactInfo>().ReverseMap();

            CreateMap<UserDetailsModel, ContactInfo.DBEntities.Entities.UserDetail>().ReverseMap();
            CreateMap<PatientDetailsModel, ContactInfo.DBEntities.Entities.PatientDetail>().ReverseMap();
            CreateMap<ContactInfo.DBEntities.Entities.PatientDetail, PatientDetailsModel>();
            CreateMap<PrescriptionModel, ContactInfo.DBEntities.Entities.Prescription>().ReverseMap();
     

        }
    }
}