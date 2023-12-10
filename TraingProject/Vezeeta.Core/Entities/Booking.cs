using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enum;

namespace Vezeeta.Core.Entities
{
    [Table("Booking")]
    public class Booking : Base
    {
        
        public int DoctorID { get; set; }
        
        public int PatientID { get; set; }
        public int? DiscountCodeID { get; set; }
        public int DoctorAppointmentTimesID { get; set; }
        public bool ConfirmCheckUp { get; set; } /*= false;*/
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; set; }
       
        public virtual ApplicationUser Doctor { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual DiscountCode? DiscountCode { get; set; }

        public virtual required DoctorAppointmentTimes DoctorAppointmentTimes { get; set; }



    }
}
