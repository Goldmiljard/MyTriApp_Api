using Newtonsoft.Json;

namespace MyTriApp.Strava_API.DTOs
{
    public class UrlsDTO
    {
        [JsonProperty("100")]
        public string _100 { get; set; }

        [JsonProperty("600")]
        public string _600 { get; set; }
    }
}
