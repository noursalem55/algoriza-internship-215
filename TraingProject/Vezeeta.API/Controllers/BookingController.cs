using Microsoft.AspNetCore.Mvc;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _booking;

        public BookingController(IBookingService booking)
        {
            _booking = booking;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
