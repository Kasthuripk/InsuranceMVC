using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Insurance.Models
{
    public class CustomerDetail
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter customer name.")]
        public string customerName { get; set; }

        [Required]
         public string gender { get; set; }
       
        [Required]
        public string age { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter phone number.")]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Enter valid PhoneNumber")]
        public long phoneNumber { get; set; }

        [Required(ErrorMessage = "Enter dateofbirth")]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }

        [Key]
        [Required(ErrorMessage = "Enter MailId")]
        [DataType(DataType.EmailAddress)]
        public string mailId { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = " Enter valid password")]
        public string password { get; set; }

        [Required]
        [Compare("password",ErrorMessage ="Password and Confirmation Password must match")]
         public string conformPassword { get; set; }

        [Required]
        public string annualIncome { get; set; }

        public string role { get; set; }

        
    }
 }
