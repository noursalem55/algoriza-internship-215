using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos.DiscountCode;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Enum;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.Service
{
    public class DiscountCodeService :IDiscountCode
    {
        private readonly IBaseRepository<DiscountCode> _discountCode;
        public DiscountCodeService(IBaseRepository<DiscountCode> discountCode)
        {
            _discountCode = discountCode;
        }

        public bool Add(DiscountCodeDTO model)
        {
            var discountCode = new DiscountCode
            {
                Code = model.Code,
                RequestCompleted = model.RequestCompleted,
                //DiscountType = model.DiscountType,
                Value = model.Value
            };
            _discountCode.Insert(discountCode);
            _discountCode.SaveChanges();
            return true;
        }

        public bool Update(UpdateDiscountCodeDTO model)
        {
            var discountCode = _discountCode.Get(model.Id);
            if (discountCode.RequestCompleted)
            {
                return false; // Return false if the discount code has been applied to a request
               
            }

            //if (discountCode == null)
            //{
            //    return false; // Return false if the discount code was not found
            //}

            discountCode.RequestCompleted = model.RequestCompleted;
            //discountCode.DiscountType = model.DiscountType;
            discountCode.DiscountType = Enum.Parse<DiscountType>(model.DiscountType, true);
            discountCode.Value = model.Value;
            _discountCode.Update(discountCode);
            _discountCode.SaveChanges();

            return true;

        }
       
        public bool Delete(int Id)
        {
            _discountCode.Delete(Id);
            return true;
        }

        public bool Deactivate(int id)
        {

            var discountCode = _discountCode.Get(id);
            if (discountCode == null)
            {
                return false; 
            }

            _discountCode.Remove(discountCode);
            _discountCode.SaveChanges();

            return true;
        }
    }
}
