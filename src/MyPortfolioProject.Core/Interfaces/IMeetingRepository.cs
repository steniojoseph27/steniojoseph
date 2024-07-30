using MyPortfolioProject.Core.Entities;

namespace MyPortfolioProject.Core.Interfaces
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        Task<IReadOnlyList<Meeting>> GetMeetingsForUserAsync(Guid userId);
    }
}