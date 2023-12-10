using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;

namespace Vezeeta.Core.Dtos
{
    public class GetAllDoctorDTO: BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get 
            {
                return FirstName + LastName;
            } 
        }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; } // 1  for male 2 for female
        public int? SpecializeID { get; set; }
        public string? SpecialityName { get; set; }

    }
}
