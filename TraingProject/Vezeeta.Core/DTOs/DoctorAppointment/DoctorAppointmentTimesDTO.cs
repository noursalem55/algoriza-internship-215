using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs.DoctorAppointment
{
    public class DoctorAppointmentTimesDTO: BaseDTO
    {
        public int DoctorAppointmentID { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
    }
}
