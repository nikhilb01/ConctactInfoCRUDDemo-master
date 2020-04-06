using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class PatientDetailsModel
    {
        public int PatientId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)] 
        public string PatientName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^\d{10}$")]
        public string MobileNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string Email { get; set; }
        public System.DateTime VisitedDate { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ConsultDoctor { get; set; }
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
        public Nullable<bool> IsDelivered { get; set; } = false;
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }

    public class PrescriptionListModel
    {
        public List<PrescriptionModel> PrescriptionData { get; set; }
    }
}