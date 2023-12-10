using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeeta.Core.Entities
{
    [Table("DoctorAppointmentTimes")]
    public class DoctorAppointmentTimes : Base
    {
        public int DoctorAppointmentID { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public virtual required DoctorAppointment DoctorAppointment { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }


    }
}
