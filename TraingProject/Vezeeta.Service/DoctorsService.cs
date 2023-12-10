using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.DTOs.DoctorAppointment;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Enum;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vezeeta.Service
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IBaseRepository<ApplicationUser> _doctor;
        private readonly IBaseRepository<DoctorAppointment> _DoctorAppointment;
        private readonly IBaseRepository<DoctorAppointmentTimes> _DoctorAppointmentTimes;
        public DoctorsService(IBaseRepository<ApplicationUser> doctor, IBaseRepository<DoctorAppointment> DoctorAppointment, IBaseRepository<DoctorAppointmentTimes> DoctorAppointmentTimes)
        {
            _doctor = doctor;
            _DoctorAppointment = DoctorAppointment;
            _DoctorAppointmentTimes = DoctorAppointmentTimes;
        }
        public bool Add(GetByIdDoctorDTO model)
        {
            var doctor = new ApplicationUser();
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Email = model.Email;
            doctor.DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd/MM/yyyy", null);
            doctor.Gender = model.Gender;
            doctor.SpecializeID = model.SpecializeID;
            doctor.Image = model.Image;
            doctor.Phone = model.Phone;
            doctor.AccountType = AccountType.Doctor.ToString();
            _doctor.Insert(doctor);
            _doctor.SaveChanges();
            return true;
        }
        //public GetByIdDoctorDTO MapDoctor()
        //{

        //}
        public bool Edit(GetByIdDoctorDTO model)
        {
            var doctor = _doctor.Get(model.ID);
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Email = model.Email;
            doctor.DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd/MM/yyyy", null);
            doctor.Gender = model.Gender;
            doctor.SpecializeID = model.SpecializeID;
            doctor.Image = model.Image;
            doctor.Phone = model.Phone;
            doctor.AccountType = AccountType.Doctor.ToString();
            _doctor.Update(doctor);
            _doctor.SaveChanges();
            return true;
        }
        public bool Delete(int Id)
        {
            _doctor.Delete(Id);
            return true;
        }

       

        public List<GetAllDoctorDTO> GetAll(int page, int pageSize, string Search)
        {
            var query = _doctor.GetQueryAll().Where(e=>e.AccountType == AccountType.Doctor.ToString());
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(e => e.FirstName.Contains(Search) || e.LastName.Contains(Search));
            }
            if (page>0 && pageSize>0)
            {
                query = query.Skip(pageSize * (page-1)).Take(pageSize);
            }
            var List = query.ToList();  
            List<GetAllDoctorDTO> doctors = new List<GetAllDoctorDTO>();
            foreach (var model in List)
            {
                GetAllDoctorDTO doctor = new GetAllDoctorDTO();
                doctor.FirstName = model.FirstName;
                doctor.LastName = model.LastName;
                doctor.Email = model.Email;
                doctor.Gender = model.Gender;
                doctor.SpecializeID = model.SpecializeID;
                doctor.Image = model.Image;
                doctor.Phone = model.Phone;
                doctors.Add(doctor);
            }
            return doctors;
        }

        public GetByIdDoctorDTO GetById(int id)
        {
            var doctor = new GetByIdDoctorDTO();
            var model = _doctor.Get(id);
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Email = model.Email;
            doctor.DateOfBirth = model.DateOfBirth.ToString("dd/MM/yyyy");
            doctor.Gender = model.Gender;
            doctor.SpecializeID = model.SpecializeID;
            doctor.Image = model.Image;
            doctor.Phone = model.Phone;
            return doctor;
        }

        //public bool AddApppointment(DoctorAppointmentDTO model)
        //{
        //    DoctorAppointment Appointment = new DoctorAppointment();
        //    Appointment.Day = model.Day;
        //    Appointment.DoctorID = model.DoctorID;
        //    _DoctorAppointment.Insert(Appointment);
        //    _DoctorAppointment.SaveChanges();
        //    model.ID = Appointment.ID;
        //    foreach (var item in model.AppointmentTimes)
        //    {
        //        var AppointmentTime = new DoctorAppointmentTimes();
        //        AppointmentTime.DoctorAppointmentID = model.ID;
        //        AppointmentTime.TimeFrom = DateTime.ParseExact(item.TimeFrom, "dd/MM/yyyy", null);
        //        AppointmentTime.TimeTo = DateTime.ParseExact(item.TimeTo, "dd/MM/yyyy", null);
        //        _DoctorAppointmentTimes.Insert(AppointmentTime);
        //    }
        //    _DoctorAppointmentTimes.SaveChanges();


        //    return true;
        //}

        bool IDoctorsService.EditApppointment(DoctorAppointmentDTO model)
        {
            throw new NotImplementedException();
        }

        bool IDoctorsService.DeleteApppointment(int Id)
        {
            throw new NotImplementedException();
        }


        bool IDoctorsService.DeleteApppointmentTimes(int Id)
        {
            throw new NotImplementedException();
        }
      
    }
}
