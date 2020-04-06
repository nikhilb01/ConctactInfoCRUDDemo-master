using ContactInfo.BL.BusinessInterfaces;
using ContactInfo.DataAccess.RepositoryInterfaces;
using ContactInfo.DBEntities.CustomEntities;
using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.BL
{
    public class PatientBL : IPatientBL
    {
        private readonly IPatientRepository _patientRepository;
        public PatientBL(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public PatientDetail AddPatient(PatientDetail patientDetail)
        {
            return _patientRepository.AddPatient(patientDetail);
        }
        public List<PatientDetail> GetAllPatientDetails()
        {
            return _patientRepository.GetAllPatientDetails();
        }
        public List<PrescriptionDetails> GetMedicineDetails(bool isDelivered)
        {
            return _patientRepository.GetMedicineDetails(isDelivered);
        }

        public List<Prescription> UpdateMedicineStatus(List<Prescription> lstPresription)
        {
            return _patientRepository.UpdateMedicineStatus(lstPresription);
        }
    }
}
