using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;
using MyPortfolioProject.Infrastructure.Data;

namespace MyPortfolioProject.Infrastructure.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly AppDbContext _context;

        public MeetingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Meeting> GetByIdAsync(Guid id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task<IReadOnlyList<Meeting>> ListAllAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<Meeting> AddAsync(Meeting entity)
        {
            _context.Meetings.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Meeting entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Meeting entity)
        {
            _context.Meetings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Meeting>> GetMeetingsForUserAsync(Guid userId)
        {
            return await _context.Meetings.Where(m => m.UserId == userId).ToListAsync();
        }
    }
}
