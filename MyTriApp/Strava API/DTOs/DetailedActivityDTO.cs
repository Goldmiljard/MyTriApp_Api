using MyTriApp.Data.Entities;
using MyTriApp.Services.DTOs;
using MyTriApp.Validators;
using Newtonsoft.Json;

namespace MyTriApp.Strava_API.DTOs
{
    public class DetailedActivityDTO
    {
        public long id { get; set; }
        public int resource_state { get; set; }
        public string? external_id { get; set; }
        public long upload_id { get; set; }
        public AthleteDTO? athlete { get; set; }
        public string? name { get; set; }
        public float distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public float total_elevation_gain { get; set; }
        public string? type { get; set; }
        public string? sport_type { get; set; }
        public string? workout_type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public string? timezone { get; set; }
        public float utc_offset { get; set; }
        public List<float>? start_latlng { get; set; }
        public List<float>? end_latlng { get; set; }
        public int achievement_count { get; set; }
        public int kudos_count { get; set; }
        public int comment_count { get; set; }
        public int athlete_count { get; set; }
        public int photo_count { get; set; }
        public MapDTO? map { get; set; }
        public bool trainer { get; set; }
        public bool commute { get; set; }
        public bool manual { get; set; }
        public bool @private { get; set; }
        public bool flagged { get; set; }
        public string? gear_id { get; set; }
        public bool from_accepted_tag { get; set; }
        public float average_speed { get; set; }
        public float max_speed { get; set; }
        public float average_cadence { get; set; }
        public int average_temp { get; set; }
        public float average_watts { get; set; }
        public int weighted_average_watts { get; set; }
        public float kilojoules { get; set; }
        public bool device_watts { get; set; }
        public bool has_heartrate { get; set; }
        public int max_watts { get; set; }
        public float elev_high { get; set; }
        public float elev_low { get; set; }
        public int pr_count { get; set; }
        public int total_photo_count { get; set; }
        public bool has_kudoed { get; set; }
        public int suffer_score { get; set; }
        public string? description { get; set; }
        public float calories { get; set; }
        public List<SegmentEffortDTO>? segment_efforts { get; set; }
        public List<SplitsMetricDTO>? splits_metric { get; set; }
        public List<LapDTO>? laps { get; set; }
        public GearDTO? gear { get; set; }
        public string? partner_brand_tag { get; set; }
        public PhotosDTO? photos { get; set; }
        public List<HighlightedKudoserDTO>? highlighted_kudosers { get; set; }
        public bool hide_from_home { get; set; }
        public string? device_name { get; set; }
        public string? embed_token { get; set; }
        public bool segment_leaderboard_opt_out { get; set; }
        public bool leaderboard_opt_out { get; set; }

        public Activity ToActivity(Guid userId)
        {
            float averageHeartrate = laps != null || laps!.Count == 0 ? laps.Average(x => x.average_heartrate) : 0;
            float maxHeartrate = laps != null || laps!.Count == 0 ? laps.Average(x => x.max_heartrate) : 0;
            Guid activityId = Guid.NewGuid();

            return new Activity
            {                
                UserId = userId,
                Name = name,
                Distance = distance,
                MovingTime = moving_time,
                ElapsedTime = elapsed_time,
                TotalElevationGain = total_elevation_gain,
                SportType = sport_type,
                StravaId = id,
                StartDate = start_date,
                StartDateLocal = start_date_local,
                Timezone = timezone,
                UtcOffset = utc_offset,
                StartLat = start_latlng != null ? start_latlng[0] : 0,
                StartLng = start_latlng != null ? start_latlng[1] : 0,
                EndLat = end_latlng != null ? end_latlng[0] : 0,
                EndLng = end_latlng != null ? end_latlng[1] : 0,
                Polyline = map?.polyline,
                SummaryPolyline = map?.summary_polyline,
                AverageSpeed = average_speed,
                MaxSpeed = max_speed,
                AverageCadence = average_cadence,
                AverageTemp = average_temp,
                AverageWatts = average_watts,
                WeightedAverageWatts = weighted_average_watts,
                Kilojoules = kilojoules,
                DeviceWatts = device_watts,
                HasHeartrate = has_heartrate,
                AverageHeartrate = averageHeartrate,
                MaxHeartrate = maxHeartrate,
                MaxWatts = max_watts,
                ElevHigh = elev_high,
                ElevLow = elev_low,
                SufferScore = suffer_score,
                Description = description,
                Calories = calories,
                Splits = splits_metric?.Select(x => x.ToSplit()).ToList(),
                Laps = laps?.Select(x => x.ToLap()).ToList(),
            };
        }
    }
}
