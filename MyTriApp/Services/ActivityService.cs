using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTriApp.Data;
using MyTriApp.Data.Entities;
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


        public async Task<List<Activity>> GetActivities(Guid userGuid)
        {
            var activities = from a in _context.Activities
                             where a.UserId == userGuid
                             select a;
            return await activities.ToListAsync();
        }

        public async Task<List<Activity>> SaveActivities(List<Activity> activities)
        {
            var entityEntries = new List<Activity>();
            foreach (var activity in activities)
            {
                var entityEntry = await SaveActivity(activity);
                entityEntries.Add(entityEntry);
            }
            await _context.SaveChangesAsync();

            return entityEntries;
        }

        public async Task<Activity> SaveActivity(Activity activity)
        {
            var activitySaved = await _context.AddAsync(activity);
            await _context.SaveChangesAsync();
            return activitySaved.Entity;
        }
    }
}
