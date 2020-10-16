using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Insurance.Entity
{
    public class Admin
    {
        [Key]
        public int insuranceId { get; set; }

        public string insuranceNumber { get; set; }

        public string insuranceType { get; set; }

        public string GST { get; set; }

        public Admin()
        {

        }
        public Admin(int insuranceId, string insuranceNumber, string insuranceType, string GST)
        {
            this.insuranceId = insuranceId;
            this.insuranceNumber = insuranceNumber;
            this.insuranceType = insuranceType;
            this.GST = GST;
        }
    }
}
