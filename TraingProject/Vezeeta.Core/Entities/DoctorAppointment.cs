using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeeta.Core.Entities
{
    [Table("DoctorAppointments")]
    public class DoctorAppointment : Base
    {
        DoctorAppointment() {
            DoctorAppointmentTimes = new List<DoctorAppointmentTimes>();
        } 
        public int DoctorID { get; set; }
        public string Day { get; set; }
        public virtual required ApplicationUser Doctor { get; set; }
        public virtual ICollection<DoctorAppointmentTimes> DoctorAppointmentTimes { get; set; }

    }
}
