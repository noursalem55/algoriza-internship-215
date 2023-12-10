using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Entities
{
    public class Specialize : Base
    {
        public string speciality { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Doctors { get; set; }
    }
}
