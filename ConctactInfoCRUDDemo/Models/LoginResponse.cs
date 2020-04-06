using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Models
{
    public class LoginResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public UserDetailsModel Data { get; set; }
    }
}