using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Dtos
{
    public class BookingRequestDTO : PatientDetailsDTO
    {

        public string Image { get; set; }
        public string DoctorName { get; set; }
        public string Specialize { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public string DiscountCode { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }

    }
}