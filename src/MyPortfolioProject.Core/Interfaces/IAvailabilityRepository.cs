using MyPortfolioProject.Core.Entities;

namespace MyPortfolioProject.Core.Interfaces
{
    public interface IAvailabilityRepository : IRepository<Availability>
    {
        Task<IReadOnlyList<Availability>> GetAvailabilityForUserAsync(Guid userId);
    }
}