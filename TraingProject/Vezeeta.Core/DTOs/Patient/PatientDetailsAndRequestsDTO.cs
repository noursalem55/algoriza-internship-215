using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Dtos.Patient
{
    public class PatientDetailsAndRequestsDTO
    {
        public PatientDetailsAndRequestsDTO()
        {
            Requests = new List<BookingRequestDTO>();
        }

        public PatientDetailsDTO Details { get; set; }
        public List<BookingRequestDTO> Requests { get; set; }
    }
}

