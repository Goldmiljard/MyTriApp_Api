using MyTriApp.Services.DTOs;
using MyTriApp.Validators;

namespace MyTriApp.Data.Entities
{
    public class Activity : Entity
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public double Distance { get; set; }
        public int MovingTime { get; set; }
        public int ElapsedTime { get; set; }
        public float TotalElevationGain { get; set; }
        public string? Type { get; set; }
        public string? SportType { get; set; }
        public string? WorkoutType { get; set; }
        public long StravaId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public string? Timezone { get; set; }
        public float UTCOffset { get; set; }
        public float StartLat { get; set; }
        public float StartLng { get; set; }
        public float EndLat { get; set; }
        public float EndLng { get; set; }
        public string? LocationCity { get; set; }
        public string? LocationState { get; set; }
        public string? LocationCountry { get; set; }
        public double AverageSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public double AverageCadence { get; set; }
        public double AverageWatts { get; set; }
        public int WeightedAverageWatts { get; set; }
        public double Kilojoules { get; set; }
        public bool DeviceWatts { get; set; }
        public bool HasHeartRate { get; set; }
        public double AverageHeartRate { get; set; }
        public float MaxHeartRate { get; set; }
        public float MaxWatts { get; set; }
        public int PRCount { get; set; }
        public int SufferScore { get; set; }

        public static Activity From(ActivityDTO dto, Guid userId)
        {
            dto.NotNull(nameof(dto));

            return new Activity
            {
                ExternalId = Guid.NewGuid(),
                UserId = userId,
                Name = dto.name,
                Distance = dto.distance,
                MovingTime = dto.moving_time,
                ElapsedTime = dto.elapsed_time,
                TotalElevationGain = dto.total_elevation_gain,
                Type = dto.type,
                SportType = dto.sport_type,
                WorkoutType = dto.workout_type,
                StravaId = dto.id,
                StartDate = dto.start_date,
                StartDateLocal = dto.start_date_local,
                Timezone = dto.timezone,
                UTCOffset = dto.utc_offset,
                StartLat = dto.start_latlng[0],
                StartLng = dto.start_latlng[1],
                EndLat = dto.end_latlng[0],
                EndLng = dto.end_latlng[1],
                LocationCity = dto.location_city,
                LocationState = dto.location_state,
                LocationCountry = dto.location_country,
                AverageSpeed = dto.average_speed,
                MaxSpeed = dto.max_speed,
                AverageCadence = dto.average_cadence,
                AverageWatts = dto.average_watts,
                WeightedAverageWatts = dto.weighted_average_watts,
                Kilojoules = dto.kilojoules,
                DeviceWatts = dto.device_watts,
                HasHeartRate = dto.has_heartrate,
                AverageHeartRate = dto.average_heartrate,
                MaxHeartRate = dto.max_heartrate,
                MaxWatts = dto.max_watts,
                PRCount = dto.pr_count,
                SufferScore = dto.suffer_score
            };
        }
    }
}
