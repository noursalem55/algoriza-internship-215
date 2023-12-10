using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Entities;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController :Controller 
    {
        private readonly IDoctorsService _doctor;
        
        public DoctorController(IDoctorsService doctor) { 
            _doctor = doctor;
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page, int pageSize, string? Search)
        {
            try
            {
                var list = _doctor.GetAll(page, pageSize, Search);
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
                var list = _doctor.GetById(id);
                return Ok(list);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddDoctors (GetByIdDoctorDTO model)
        {
            try
            {
                var list = _doctor.Add(model);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditDoctors(GetByIdDoctorDTO model)
        {
            try
            {
                var list = _doctor.Edit(model);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var list = _doctor.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



    }
}
