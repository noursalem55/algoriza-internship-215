using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs.Booking
{
    public class BookingDTO: BaseDTO
    {
        public string PationName { get; set; }
        public int Age { get; set; }
        public int PatientID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
