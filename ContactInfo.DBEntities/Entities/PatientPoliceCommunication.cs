//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactInfo.DBEntities.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientPoliceCommunication
    {
        public int PatientPoliceCommunicationId { get; set; }
        public int PatientId { get; set; }
        public string PoliceRemark { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual PatientDetail PatientDetail { get; set; }
    }
}
