namespace MyTriApp.Strava_API.DTOs
{
    public class SegmentDTO
    {
        public int id { get; set; }
        public int resource_state { get; set; }
        public string name { get; set; }
        public string activity_type { get; set; }
        public float distance { get; set; }
        public float average_grade { get; set; }
        public float maximum_grade { get; set; }
        public float elevation_high { get; set; }
        public float elevation_low { get; set; }
        public List<float> start_latlng { get; set; }
        public List<float> end_latlng { get; set; }
        public int climb_category { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public bool @private { get; set; }
        public bool hazardous { get; set; }
        public bool starred { get; set; }
    }
}
