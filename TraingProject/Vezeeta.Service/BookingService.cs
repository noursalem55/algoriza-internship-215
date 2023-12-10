using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Repo.GenericRepository;

namespace Vezeeta.Service
{
    public class BookingService
    {
        private readonly IBaseRepository<Booking> _booking;
        public BookingService(IBaseRepository<Booking> booking)
        {
            _booking = booking;
        }


    }
}
