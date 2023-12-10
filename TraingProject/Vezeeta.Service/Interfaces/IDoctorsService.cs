using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.DTOs.DoctorAppointment;

namespace Vezeeta.Service.Interfaces
{
    public interface IDoctorsService
    {
        public List<GetAllDoctorDTO> GetAll(int page , int pageSize , string Search);
        public GetByIdDoctorDTO GetById(int id);
        public bool Add(GetByIdDoctorDTO model);
        public bool Edit(GetByIdDoctorDTO model);
        public bool Delete(int Id);

        //public bool AddApppointment(DoctorAppointmentDTO model);
        public bool EditApppointment(DoctorAppointmentDTO model);
        public bool DeleteApppointment(int Id);
        public bool DeleteApppointmentTimes(int Id);


    }
}
