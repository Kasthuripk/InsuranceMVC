using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Insurance.Models
{
    public class SignInDetail
    {
        [Required(ErrorMessage = "Enter phone number.")]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Enter valid PhoneNumber")]
        public long phoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = " Enter valid password")]
        public string password { get; set; }

        [Required]
        public string role { get; set; }
    }
}