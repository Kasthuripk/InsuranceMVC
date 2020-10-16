using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Online_Insurance.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }

        public string customerName { get; set; }

        public string  gender{get; set;}

        public string age { get; set; }

        public string Address { get; set; }

        public long phoneNumber { get; set; }

        public DateTime dateOfBirth { get; set; }
        [Key]
        public string mailId { get; set; }

        public string password { get; set; }

        public string annualIncome { get; set; }

        public string role { get; set; }

     

  public User()
        {

        }

        public User(string customerName,string gender,string age , string Address, long phoneNumber, DateTime dateOfBirth, string mailId, string password,string annualIncome, string role)
        {
            this.customerName = customerName;
            this.gender = gender;
            this.age = age;
            this.Address = Address;
            this.phoneNumber = phoneNumber;
            this.dateOfBirth = dateOfBirth;
            this.mailId = mailId;
            this.password = password;
            this.annualIncome = annualIncome;
            this.role = role;
           }
        


    }
}

