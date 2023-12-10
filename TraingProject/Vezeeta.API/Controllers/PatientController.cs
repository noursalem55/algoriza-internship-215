using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Dtos.Patient;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientsService _patient;

        public PatientController(IPatientsService patient)
        {
            _patient = patient;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Add(GetByIdDoctorDTO model)
        {
            try
            {
                var list = _patient.Add(model);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page, int pageSize, string? Search)
        {
            try
            {
                var list = _patient.GetAll(page, pageSize, Search);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        { 
     
            try
            {
                var list = _patient.GetById(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); // Internal Server Error with exception details
            }
        }
    }
}
