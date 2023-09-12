using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTriApp.Data.Entities;

namespace MyTriApp.Services.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetActivities(Guid userGuid);
        Task<List<Activity>> SaveActivities(List<Activity> activities);
        Task<Activity> SaveActivity(Activity activity);
    }
}
