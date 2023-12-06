using Microsoft.EntityFrameworkCore;
using MyTriApp.Data;
using MyTriApp.Data.Entities;
using MyTriApp.DTO;
using MyTriApp.Services.Interfaces;

namespace MyTriApp.Services
{
    public class ActivityService : IActivityService
    {
        private readonly MyTriAppDbContext _context;

        public ActivityService(MyTriAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateActivities(List<Activity> activities)
        {
            foreach (var activity in activities)
            {
                await CreateActivity(activity);
            }
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateActivity(Activity activity)
        {
            if (!_context.Activities.Where(x => x.StravaId == activity.StravaId).Any())
            {
                var entityEntry = await _context.AddAsync(activity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Activity>> GetActivities(Guid userGuid)
        {
            var activities = await _context.Activities.Include(a => a.Laps).ToListAsync();
            return activities;
        }

        public async Task<Activity?> GetActivityById(long id, Guid userId)
        {
            return await _context.Activities.FirstOrDefaultAsync(x => x.StravaId == id && x.UserId == userId);
        }

        public async Task<bool> UpdateActivity(long activityId, Updates updates)
        {
            var activity = await _context.Activities.FirstAsync(x => x.StravaId == activityId);
            if (updates.title != null)
            {
                activity.Name = updates.title;
            }
            if (updates.type != null)
            {
                activity.SportType = updates.type;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActivity(long activityId)
        {
            var activity = await _context.Activities.FirstAsync(x => x.StravaId == activityId);
            if (activity == null)
            {
                return false;
            }
            _context.Remove(activity);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
