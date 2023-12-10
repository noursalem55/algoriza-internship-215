using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.Dtos.DiscountCode;
using Vezeeta.Service;
using Vezeeta.Service.Interfaces;
namespace Vezeeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeController : ControllerBase
    {
        private readonly IDiscountCode _discountCode;

        public DiscountCodeController(IDiscountCode discountCode)
        {
            _discountCode = discountCode;
        }

        [HttpPost("Add")]
        public IActionResult Add(DiscountCodeDTO model)
        {
            try
            {
                var added = _discountCode.Add(model);
                return Ok(added);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateDiscountCodeDTO model)
        {
            try
            {
                var updated = _discountCode.Update(model);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //ERROR :why public is not valid in this method 
        [HttpDelete("Deactivate/{id}")]
        private IActionResult Deactivate(int id)
        {
            try
            {
                var deactivated = _discountCode.Deactivate(id);
                return Ok(deactivated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
