using MyTriApp.Data.Entities;
using MyTriApp.Services.DTOs;

namespace MyTriApp.Strava_API.DTOs
{
    public class LapDTO
    {
        public long id { get; set; }
        public int resource_state { get; set; }
        public string name { get; set; }
        public ActivityDTO activity { get; set; }
        public AthleteDTO athlete { get; set; }
        public int elapsed_time { get; set; }
        public int moving_time { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public float distance { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public float total_elevation_gain { get; set; }
        public float max_heartrate { get; set; }
        public float average_heartrate { get; set; }
        public float average_speed { get; set; }
        public float max_speed { get; set; }
        public float average_cadence { get; set; }
        public bool device_watts { get; set; }
        public float average_watts { get; set; }
        public int lap_index { get; set; }
        public int split { get; set; }

        public Lap ToLap()
        {
            return new Lap
            {
                StravaId = id,
                Name = name,
                ElapsedTime = elapsed_time,
                MovingTime = moving_time,
                StartDate = start_date,
                StartDateLocal = start_date_local,
                Distance = distance,
                StartIndex = start_index,
                EndIndex = end_index,
                TotalElevationGain = total_elevation_gain,
                MaxHeartrate = max_heartrate,
                AverageHeartrate = average_heartrate,
                AverageSpeed = average_speed,
                MaxSpeed = max_speed,
                AverageCadence = average_cadence,
                DeviceWatts = device_watts,
                AverageWatts = average_watts,
                LapIndex = lap_index,
                SplitNumber = split
            };
        }
    }
}
