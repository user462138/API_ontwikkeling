using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using VerhuurSysteem.Models;
using VerhuurSysteem.Services;

namespace VerhuurSysteem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationHomeController : ControllerBase
    {
        private readonly VacationHomeService _vacationHomeController;

        public VacationHomeController()
        {
            _vacationHomeController = new VacationHomeService();
        }

        [HttpGet] // api/VacationHomes
        public async Task<ActionResult<List<VacationHome>>> GetVacationHome()
        {
            var vacationHomes = await _vacationHomeController.GetAllVacationHomes();
            return Ok(vacationHomes);
        }


        [HttpGet("{id:int}/details")] // api/VacationHome/1
        public async Task<ActionResult<VacationHome>> GetVacationHomes(int id)
        {
            var vacationhome = await _vacationHomeController.GetVacationHome(id);
            if (vacationhome == null)
            {
                return NotFound();
            }
            return Ok(vacationhome);
        }

        // GET /api/vacationhomes/search?location={location}&startDate={startDate}&endDate={endDate}
        [HttpGet("search/location={location:alpha}&startDate={startDate:datetime}&endDate={endDate:datetime}")]
        public async Task<ActionResult<List<VacationHome>>> GetVacationHomesByLocationAndStartDateAndendDate(
            string location, DateTime startDate, DateTime endDate)
        {
            var vacationHomes = await _vacationHomeController.GetAllVacationHomesByLocationAndStartDateAndendDate(location, startDate, endDate);
            if (vacationHomes == null || !vacationHomes.Any())
            {
                return NotFound();
            }
            return Ok(vacationHomes);
        }
    }
}
