using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Entities
{
    [Table("Users")]

    public class ApplicationUser :Base
    {
        //[Key]
        //public int ID { get; set; }
        public string AccountType { get; set; } // admin , doctor , patients
        #region Admin
        public bool IsAdmin { get; set; } // if True must be Admin
        #endregion
        #region Doctor / Patients
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? speciality { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; } // 1  for male 2 for female
        public int? SpecializeID { get; set; }
        #endregion

        public virtual Specialize? Specialize { get; set; }

        public virtual ICollection<Booking> DoctorBookings { get; set; } /*= new HashSet<Booking>();*/
        public virtual ICollection<Booking> PatientBookings { get; set; }


    }
}
