using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs.DoctorAppointment
{
    public class DoctorAppointmentDTO:BaseDTO
    {
        public int DoctorID { get; set; }
        public string Day { get; set; }

        public  List<DoctorAppointmentTimesDTO> AppointmentTimes { get; set; }
    }
}
