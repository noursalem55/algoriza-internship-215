using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs.Booking
{
    public class BookingFilterDTO
    {
        public int? DoctorID { get; set; }
        public string Date { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
