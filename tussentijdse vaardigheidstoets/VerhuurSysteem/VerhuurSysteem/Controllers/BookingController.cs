using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(ILogger<BookingController> logger) : ControllerBase
    {
        [HttpGet]
        [Route("/api/bookings/book")]
        public ActionResult BoekingLog()
        {
            var random = new Random();
            var boekingsAanvraagId = random.Next(1, 101);

            logger.LogInformation("New booking boekingsaanvraag number :{boekingsaanvraagid} Today is {Week}. It is {Time}.", boekingsAanvraagId, DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
            return Ok("This is to test the /api/bookings/book.");
        }

        [HttpGet]
        [Route("/api/bookings/cancel")]
        public ActionResult AnnuleringLog()
        {
            var random = new Random();
            var boekingsAanvraagId = random.Next(1, 101);

            logger.LogInformation("Booking boekingsaanvraag number :{boekingsaanvraagid} got canceld at Today {Time}.", boekingsAanvraagId, DateTime.Now.ToLongTimeString());
            return Ok("This is to test the /api/bookings/cancel.");
        }

        [HttpGet]
        [Route("/api/bookings/modify")]
        public ActionResult WijzigingenLog()
        {
            var random = new Random();
            var boekingsAanvraagId = random.Next(1, 101);

            logger.LogInformation("Booking boekingsaanvraag number :{boekingsaanvraagid} got changed Today at {Time}.", boekingsAanvraagId, DateTime.Now.ToLongTimeString());
            return Ok("This is to test the /api/bookings/modif.");
        }
    }
}
