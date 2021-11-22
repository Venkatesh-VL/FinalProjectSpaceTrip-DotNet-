using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProjectWEBAPI.Models
{
    public partial class Userinfo
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Asthma { get; set; }
        public string Diabetes { get; set; }
        public string Years { get; set; }
        public string Reason { get; set; }
        public int Id { get; set; }
        public string Waitlistno { get; set; }
    }
}
