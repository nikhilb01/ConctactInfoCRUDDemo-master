using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.DBEntities.CustomEntities
{
    public class PatientDetailModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }    
        public string Email { get; set; }
        public System.DateTime VisitedDate { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual ICollection<PrescriptionModel> Prescriptions { get; set; }
    }

    public class PrescriptionModel
    {
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public int PatientId { get; set; }
        public Nullable<bool> Morning { get; set; }
        public Nullable<bool> Afternoon { get; set; }
        public Nullable<bool> Night { get; set; }
        public Nullable<bool> BeforeEat { get; set; }
    }
}
