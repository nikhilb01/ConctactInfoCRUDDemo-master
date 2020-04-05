using ContactInfo.DataAccess.RepositoryInterfaces;
using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.DataAccess.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public PatientDetail AddPatient(PatientDetail patientDetail)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                var patient = new DBEntities.Entities.PatientDetail()
                {
                    PatientName = patientDetail.PatientName,
                    Gender = patientDetail.Gender,
                    Age = patientDetail.Age,
                    MobileNumber = patientDetail.MobileNumber,
                    Email = patientDetail.Email,
                    VisitedDate = patientDetail.VisitedDate,
                    Remark = patientDetail.Remark,
                    IsActive = true,
                    CreatedOn = patientDetail.CreatedOn,
                    CreatedBy= patientDetail.CreatedBy,
                    ConsultDoctor = patientDetail.ConsultDoctor                 
                };
                ctx.PatientDetails.Add(patient);
                ctx.SaveChanges();


                foreach (var prescription in patientDetail.Prescriptions)
                {
                    prescription.PatientId = patient.PatientId;
                    ctx.Prescriptions.Add(prescription);
                  
                }
                ctx.SaveChanges();

                patientDetail.PatientId = patient.PatientId;

                return patientDetail;
            }
        }

        public List<PatientDetail> GetAllPatientDetails()
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                return ctx.PatientDetails.Include("Prescriptions").ToList();
            }

        }
    }
}
