using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class ContactInfoViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}