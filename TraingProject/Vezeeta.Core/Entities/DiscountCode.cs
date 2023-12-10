using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enum;

namespace Vezeeta.Core.Entities
{
    public class DiscountCode : Base
    {
        public string Code { get; set; }
        //# of requestes(completed)
        public bool RequestCompleted { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }
        public int AdminId { get; set; }
        public string Day { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser Admin { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }


    }
}
