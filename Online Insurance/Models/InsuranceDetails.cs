using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Insurance.Models
{
    public class InsuranceDetails
    {
        [Key]
        [Required]
        public int insuranceId { get; set; }

        [Required(ErrorMessage = "Enter valid number.")]
    
        public string insuranceNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter insurance Type")]
        public string insuranceType { get; set; }

        [Required(ErrorMessage = "Enter GST")]
        public string GST { get; set; }
    }
}