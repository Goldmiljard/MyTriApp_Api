using MyTriApp.Services.DTOs;

namespace MyTriApp.Strava_API.DTOs
{
    public class SegmentEffortDTO
    {
        public long id { get; set; }
        public int resource_state { get; set; }
        public string? name { get; set; }
        public ActivityDTO? activity { get; set; }
        public AthleteDTO? athlete { get; set; }
        public int elapsed_time { get; set; }
        public int moving_time { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public float distance { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public float average_cadence { get; set; }
        public float average_heartrate { get; set; }
        public float max_heartrate { get; set; }
        public bool device_watts { get; set; }
        public float average_watts { get; set; }
        public SegmentDTO? segment { get; set; }
        public int kom_rank { get; set; }
        public int? pr_rank { get; set; }
        public List<AchievementDTO>? achievements { get; set; }
        public bool hidden { get; set; }
    }
}
