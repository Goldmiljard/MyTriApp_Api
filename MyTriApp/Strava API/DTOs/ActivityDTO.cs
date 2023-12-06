using MyTriApp.Data.Entities;
using MyTriApp.Strava_API.DTOs;
using MyTriApp.Validators;

namespace MyTriApp.Services.DTOs
{
    public class ActivityDTO
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
        public string? location_city { get; set; }
        public string? location_state { get; set; }
        public string? location_country { get; set; }
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
    }
}
