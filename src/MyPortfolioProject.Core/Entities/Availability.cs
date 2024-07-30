namespace MyPortfolioProject.Core.Entities
{
    public class Availability
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}