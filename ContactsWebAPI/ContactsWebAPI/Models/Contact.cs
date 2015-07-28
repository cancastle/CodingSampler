using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebAPI.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}