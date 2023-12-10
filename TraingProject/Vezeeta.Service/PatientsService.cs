using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Dtos.Patient;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Enum;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.Service
{
    public class PatientsService : IPatientsService
    {
        private readonly IBaseRepository<ApplicationUser> _patient;
        public PatientsService(IBaseRepository<ApplicationUser> patient
            )
        {
            _patient = patient;
        }
        public bool Add(GetByIdDoctorDTO model)
        {
            var patient = new ApplicationUser();
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Email = model.Email;
            patient.DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd/MM/yyyy", null);
            patient.Gender = model.Gender;
            patient.Image = model.Image;
            patient.Phone = model.Phone;
            patient.AccountType = AccountType.Patients.ToString();
            _patient.Insert(patient);
            _patient.SaveChanges();
            return true;
        }
        public List<PatientDetailsDTO> GetAll(int page, int pageSize, string? Search)
        {
            var query = _patient.GetQueryAll().Where(e => e.AccountType == AccountType.Patients.ToString());
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(e => e.FirstName.Contains(Search) || e.LastName.Contains(Search));
            }
            if (page > 0 && pageSize > 0)
            {
                query = query.Skip(pageSize * (page - 1)).Take(pageSize);
            }
            var List = query.ToList();
            List<PatientDetailsDTO> patients = new List<PatientDetailsDTO>();
            foreach (var model in List)
            {
                PatientDetailsDTO patient = new PatientDetailsDTO();
                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.Email = model.Email;
                patient.Gender = model.Gender;
                patient.Image = model.Image;
                patient.Phone = model.Phone;
                patients.Add(patient);
            }
            return patients;
        }

        public PatientDetailsAndRequestsDTO GetById(int id)
        {
            var model = _patient.Get(id);
     
        var patientDetails = new PatientDetailsAndRequestsDTO
        {
            Details = new PatientDetailsDTO
            {
                Image = model.Image,
                FirstName = $"{model.FirstName}",
                LastName = $"{model.LastName}",
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth.ToString("dd//MM/yyyy")
            }
        };

        foreach (var booking in model.DoctorBookings)
        {
            var bookingRequest = new BookingRequestDTO
            {
                Image = booking.Patient.Image,
                DoctorName = $"{booking.Doctor.FirstName} {booking.Doctor.LastName}",
                Specialize = booking.Doctor.Specialize?.Name,
                Price = booking.Price,
                DiscountCode = booking.DiscountCode?.Code,
                FinalPrice = booking.FinalPrice,
                Status = booking.ConfirmCheckUp ? "Confirmed" : "Pending"
            };

                patientDetails.Requests.Add(bookingRequest);
        }

            return patientDetails;
        }
        }
    }

 

    

