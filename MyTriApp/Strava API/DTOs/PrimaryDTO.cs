using static MyTriApp.Strava_API.DTOs.DetailedActivityDTO;

namespace MyTriApp.Strava_API.DTOs
{
    public class PrimaryDTO
    {
        public long id { get; set; }
        public string unique_id { get; set; }
        public UrlsDTO urls { get; set; }
        public int source { get; set; }
    }
}
