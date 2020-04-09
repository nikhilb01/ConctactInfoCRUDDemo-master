using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class EmailModel
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}