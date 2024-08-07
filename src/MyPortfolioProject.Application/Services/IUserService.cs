
using MyPortfolioProject.Application.DTOs;

namespace MyPortfolioProject.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}