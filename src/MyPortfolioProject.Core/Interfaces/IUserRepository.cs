using MyPortfolioProject.Core.Entities;

namespace MyPortfolioProject.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}