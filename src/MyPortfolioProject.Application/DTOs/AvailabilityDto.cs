
namespace MyPortfolioProject.Application.DTOs
{
    public class AvailabilityDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}