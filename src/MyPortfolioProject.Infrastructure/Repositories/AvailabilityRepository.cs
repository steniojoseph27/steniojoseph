using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;
using MyPortfolioProject.Infrastructure.Data;

namespace MyPortfolioProject.Infrastructure.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly AppDbContext _context;

        public AvailabilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Availability> GetByIdAsync(Guid Id)
        {
            return await _context.Availabilities.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Availability>> ListAllAsync()
        {
            return await _context.Availabilities.ToListAsync();
        }

        public async Task<Availability> AddAsync(Availability entity)
        {
            _context.Availabilities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Availability entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Availability entity)
        {
            _context.Availabilities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilityForUserAsync(Guid userId)
        {
            return await _context.Availabilities.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
