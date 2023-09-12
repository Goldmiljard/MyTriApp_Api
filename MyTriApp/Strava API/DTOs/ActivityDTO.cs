using MyTriApp.Data.Entities;
using MyTriApp.Strava_API.DTOs;
using MyTriApp.Validators;

namespace MyTriApp.Services.DTOs
{
    public class ActivityDTO
    {
        public int resource_state { get; set; }
        public AthleteDTO athlete { get; set; }
        public string name { get; set; }
        public float distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public float total_elevation_gain { get; set; }
        public string type { get; set; }
        public string sport_type { get; set; }
        public string workout_type { get; set; }
        public long id { get; set; }
        public string external_id { get; set; }
        public long upload_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public string timezone { get; set; }
        public float utc_offset { get; set; }
        public List<float> start_latlng { get; set; }
        public List<float> end_latlng { get; set; }
        public string location_city { get; set; }
        public string location_state { get; set; }
        public string location_country { get; set; }
        public int achievement_count { get; set; }
        public int kudos_count { get; set; }
        public int comment_count { get; set; }
        public int athlete_count { get; set; }
        public int photo_count { get; set; }
        public MapDTO map { get; set; }
        public bool trainer { get; set; }
        public bool commute { get; set; }
        public bool manual { get; set; }
        public bool @private { get; set; }
        public bool flagged { get; set; }
        public string gear_id { get; set; }
        public bool from_accepted_tag { get; set; }
        public float average_speed { get; set; }
        public float max_speed { get; set; }
        public float average_cadence { get; set; }
        public float average_watts { get; set; }
        public int weighted_average_watts { get; set; }
        public float kilojoules { get; set; }
        public bool device_watts { get; set; }
        public bool has_heartrate { get; set; }
        public float average_heartrate { get; set; }
        public float max_heartrate { get; set; }
        public float max_watts { get; set; }
        public int pr_count { get; set; }
        public int total_photo_count { get; set; }
        public bool has_kudoed { get; set; }
        public int suffer_score { get; set; }


        public Activity ToActivity(ActivityDTO dto, Guid userId)
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
