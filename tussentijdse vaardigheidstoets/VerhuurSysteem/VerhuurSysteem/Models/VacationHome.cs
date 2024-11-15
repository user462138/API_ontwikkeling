namespace VerhuurSysteem.Models
{
    public class VacationHome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxGuests { get; set; }
        public bool IsAvailable { get; set; }

    }
}
