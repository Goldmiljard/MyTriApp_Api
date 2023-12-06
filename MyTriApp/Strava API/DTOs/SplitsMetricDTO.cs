using MyTriApp.Data.Entities;

namespace MyTriApp.Strava_API.DTOs
{
    public class SplitsMetricDTO
    {
        public float distance { get; set; }
        public int elapsed_time { get; set; }
        public float elevation_difference { get; set; }
        public int moving_time { get; set; }
        public int split { get; set; }
        public float average_speed { get; set; }
        public int pace_zone { get; set; }

        public Split ToSplit()
        {
            return new Split
            {
                Distance = distance,
                ElapsedTime = elapsed_time,
                ElevationDifference = elevation_difference,
                MovingTime = moving_time,
                SplitNumber = split,
                AverageSpeed = average_speed,
                PaceZone = pace_zone
            };        
        }
    }
}
