using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Xml.Linq;
using VerhuurSysteem.Models;

namespace VerhuurSysteem.Services
{
    public class VacationHomeService
    {
        private static readonly List<VacationHome> AllVacationHome = new()
        {
            new() {Id=1,Name="AAA",Location="Antwerpen",PricePerNight=99.99M,MaxGuests=2,IsAvailable=true },
            new() {Id=2,Name="BBB",Location="Antwerpen",PricePerNight=159.99M,MaxGuests=3,IsAvailable=true },
            new() {Id=3,Name="CCC",Location="Antwerpen",PricePerNight=200.99M,MaxGuests=4,IsAvailable=false },
            new() {Id=4,Name="EEE",Location="Antwerpen",PricePerNight=299.99M,MaxGuests=5,IsAvailable=true },
        };

        private readonly ConcurrentDictionary<Booking, VacationHome> _vacationHome_Booking = new();


        public Task<List<VacationHome>> GetAllVacationHomes()
        {
            return Task.FromResult(AllVacationHome);
        }
        public Task<VacationHome?> GetVacationHome(int id)
        {
            return Task.FromResult(AllVacationHome.FirstOrDefault(x => x.Id == id));
        }
        public Task<List<VacationHome>> GetAllVacationHomesByLocationAndStartDateAndendDate(string location, DateTime startDate, DateTime endDate)
        {
            var vacationHomeByLocation = _vacationHome_Booking.Values.Where(
                x => x.Location?.Equals(location, StringComparison.OrdinalIgnoreCase) == true).ToList();
            var vacationHomeByDate = _vacationHome_Booking.Keys.Where(
                x => x.StartDate != startDate && x.EndDate != endDate).ToList();
            var vacationHomeByLocationAndByDate = vacationHomeByDate;
            return Task.FromResult(vacationHomeByLocation);
        }
    }
}
