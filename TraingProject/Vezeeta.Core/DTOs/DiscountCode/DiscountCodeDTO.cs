using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enum;

namespace Vezeeta.Core.Dtos.DiscountCode
{
    public class DiscountCodeDTO
    {
        public string Code { get; set; }
        //# of requestes(completed)
        public bool RequestCompleted { get; set; }
        public string DiscountType { get; set; }
        //public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }

    }
}
