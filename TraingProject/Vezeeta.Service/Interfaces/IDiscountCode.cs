using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Dtos.DiscountCode;
namespace Vezeeta.Service.Interfaces
{
    public interface IDiscountCode
    {

        public bool Add(DiscountCodeDTO model);
        public bool Update(UpdateDiscountCodeDTO model);
        public bool Delete(int Id);
        public bool Deactivate(int id);
    }
}
