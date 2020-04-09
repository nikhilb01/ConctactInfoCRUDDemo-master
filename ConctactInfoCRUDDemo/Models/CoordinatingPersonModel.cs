using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class CoordinatingPersonModel
    {
        public int CoordinatingPersonId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}