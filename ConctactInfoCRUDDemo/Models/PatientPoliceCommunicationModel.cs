using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class PatientPoliceCommunicationModel
    {
        public int PatientPoliceCommunicationId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int PatientId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PoliceRemark { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}