using ContactInfo.DBEntities.CustomEntities;
using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.DataAccess.RepositoryInterfaces
{
    public interface IPatientRepository
    {
        PatientDetail AddPatient(PatientDetail patientDetail);
        List<PatientDetail> GetAllPatientDetails();
        List<PrescriptionDetails> GetMedicineDetails(bool isDelivered);
        List<Prescription> UpdateMedicineStatus(List<Prescription> lstPresription);
    }
}
