using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfo.DBEntities.CustomEntities
{
    public class PrescriptionDetails
    {
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public int PatientId { get; set; }

        //public Nullable<bool> Morning { get; set; }
        //public Nullable<bool> Afternoon { get; set; }
        //public Nullable<bool> Night { get; set; }
        //public Nullable<bool> BeforeEat { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<System.DateTime> OrderRequestedTime { get; set; }
        //public Nullable<int> CreatedBy { get; set; }
        //public Nullable<System.DateTime> ModifiedOn { get; set; }
        //public Nullable<int> ModifiedBy { get; set; }
        public string PatientName { get; set; }
    }
}
