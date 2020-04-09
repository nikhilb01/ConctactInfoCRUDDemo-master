using ContactInfo.DataAccess.RepositoryInterfaces;
using ContactInfo.DBEntities.CustomEntities;
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
                    CreatedBy = patientDetail.CreatedBy,
                    ConsultDoctor = patientDetail.ConsultDoctor,
                    Category = patientDetail.Category,
                    IsPoliceVerificationRequired = patientDetail.IsPoliceVerificationRequired,
                    CoordinatingPersonId = patientDetail.CoordinatingPersonId
                };
                ctx.PatientDetails.Add(patient);
                ctx.SaveChanges();


                foreach (var prescription in patientDetail.Prescriptions)
                {
                    prescription.PatientId = patient.PatientId;
                    ctx.Prescriptions.Add(prescription);

                }
                ctx.SaveChanges();

                //ctx.CoordinatingPersons.Add(new CoordinatingPerson
                //{
                //    Name = patientDetail.co
                //})

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

        public List<PrescriptionDetails> GetMedicineDetails(bool isDelivered)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {

                var medicineList = (from p in ctx.PatientDetails
                                    join pre in ctx.Prescriptions.Where(pre => pre.IsDelivered == isDelivered)
                                    on p.PatientId equals pre.PatientId
                                    select new PrescriptionDetails()
                                    {
                                        PatientId = pre.PatientId,
                                        PatientName = p.PatientName,
                                        PrescriptionId = pre.PrescriptionId,
                                        MedicineName = pre.MedicineName,
                                        OrderRequestedTime = pre.CreatedOn,
                                        IsDelivered = pre.IsDelivered
                                    }).ToList();

                return medicineList;
            }

        }

        public List<Prescription> UpdateMedicineStatus(List<Prescription> lstPresription)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                foreach (var prescription in lstPresription)
                {
                    var prescriptionDetails = ctx.Prescriptions.Where(pre => pre.PrescriptionId == prescription.PrescriptionId).SingleOrDefault();
                    if (prescriptionDetails != null)
                        prescriptionDetails.IsDelivered = true;
                    ctx.SaveChanges();

                }
                lstPresription.ForEach(pre => pre.IsDelivered = true);
                return lstPresription;
            }
        }

        public int AddCoordinatingPerson(CoordinatingPerson coordinatingPerson)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                ctx.CoordinatingPersons.Add(coordinatingPerson);
                ctx.SaveChanges();

                return coordinatingPerson.CoordinatingPersonId;
            }
        }

        public PatientPoliceCommunication AddPatientPoliceCommunicationDetails(PatientPoliceCommunication patientPoliceCommunication)
        {
            using (var ctx = new MedicalStoreDBEntities())
            {
                ctx.PatientPoliceCommunications.Add(patientPoliceCommunication);
                ctx.SaveChanges();

                return patientPoliceCommunication;
            }
        }
    }
}
