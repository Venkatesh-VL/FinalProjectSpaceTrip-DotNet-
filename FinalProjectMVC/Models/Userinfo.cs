using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinalProjectWEBAPI.Models
{
    public partial class Userinfo
    {
        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress]


        public string Email { get; set; }




        [Required(ErrorMessage = "Please enter your FirstName.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Age.")]

        [Range(18, 50, ErrorMessage = "Please enter a between 18 and 50")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please enter your Gender.")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }


       

        [Required(ErrorMessage = "Please enter your Nationality.")]
        [DataType(DataType.Text)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter your Address.")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Phoneno.")]
        [DataType(DataType.PhoneNumber)]
        public long? PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter your response.")]
        public string Asthma { get; set; }

        [Required(ErrorMessage = "Please enter your response.")]
        public string Diabetes { get; set; }

        [Required(ErrorMessage = "Please enter the year to travel.")]
        public int? Years { get; set; }

        [Required(ErrorMessage = "Please enter the reason to travel!.")]
        public string Reason { get; set; }

        public int Id { get; set; }
        public string Waitlistno { get; set; }
    }
}
