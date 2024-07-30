namespace MyPortfolioProject.Core.ValueObjects
{
    public class TimeRange
    {
        public TimeSpan Start { get; }
        public TimeSpan End { get; }

        public TimeRange(TimeSpan start, TimeSpan end)
        {
            if (start >= end)
            {
                throw new ArgumentException("Start time must be earlier than end time.");
            }

            Start = start;
            End = end;
        }

        public bool Overlaps(TimeRange other)
        {
            return Start < other.End && End > other.Start;
        }
    }
}
