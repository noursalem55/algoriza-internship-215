using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Dtos.Patient;

namespace Vezeeta.Service.Interfaces
{
    public interface IPatientsService
    {
        public bool Add(GetByIdDoctorDTO model);
        public List<PatientDetailsDTO> GetAll(int page, int pageSize, string Search);
     //   public List<PatientDetailsDTO> GetAllDocors(int page, int pageSize, string Search);
        public PatientDetailsAndRequestsDTO GetById(int id);
    }
}
