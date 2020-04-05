using ContactInfo.DBEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.BL.BusinessInterfaces
{
    public interface IPatientBL
    {
        PatientDetail AddPatient(PatientDetail patientDetail);
        List<PatientDetail> GetAllPatientDetails();
    }
}
