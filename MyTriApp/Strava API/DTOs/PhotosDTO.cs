using static MyTriApp.Strava_API.DTOs.DetailedActivityDTO;

namespace MyTriApp.Strava_API.DTOs
{
    public class PhotosDTO
    {
        public PrimaryDTO primary { get; set; }
        public bool use_primary_photo { get; set; }
        public int count { get; set; }
    }
}
