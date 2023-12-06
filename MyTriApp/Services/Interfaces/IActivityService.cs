using MyTriApp.Data.Entities;
using MyTriApp.DTO;

namespace MyTriApp.Services.Interfaces
{
    public interface IActivityService
    {
        Task<bool> CreateActivities(List<Activity> activities);
        Task<bool> CreateActivity(Activity activity);
        Task<List<Activity>> GetActivities(Guid userId);
        Task<Activity?> GetActivityById(long activityId, Guid userId);
        Task<bool> UpdateActivity(long activityId, Updates updates);
        Task<bool> DeleteActivity(long activityId);
    }
}
