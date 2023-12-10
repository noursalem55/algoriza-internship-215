using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;

namespace Vezeeta.Service.Interfaces
{
    public interface IBookingService
    {
        public List<GetAllDoctorDTO> GetAll(int page, int pageSize, string Search);

    }
}
