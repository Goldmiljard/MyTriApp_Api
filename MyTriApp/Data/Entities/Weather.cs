using MyTriApp.Migrations;
using MyTriApp.Weather_API.DTOs;

namespace MyTriApp.Data.Entities
{
    public class Weather : Entity
    {
        public float WindDirection {get;set; }
        public float Temperature { get; set; }
        public float MaxTemperature { get; set; }
        public float Visibility { get; set; }
        public float WindSpeed { get; set; }
        public float CloudCover { get; set; }
        public float Mint { get; set; }
        public float Precipation { get; set; }
        public string WeatherType { get; set; } = string.Empty;
        public float SnowDepth { get; set; }
        public float SeaLevelPressure { get; set; }
        public float Snow { get; set; }
        public float Dew { get; set; }
        public float Humidity { get; set; }
        public float WindGust { get; set; }
        public string Conditions { get; set; } = string.Empty;
        public float WindChill { get; set; }

        public long StravaId { get; set; }
        public Activity Activity { get; set; }

        public Weather From(WeatherDTO weatherDTO, long stravaId, Activity activity)
        {
            //WIP have to consider whether to handle null handling on received DTO's and/or whether to skip received DTO's entirely and right away store as entities.

            return new Weather
            {
                WindDirection = weatherDTO.wdir == null ? 0 : (float)weatherDTO.wdir,



                StravaId = stravaId,
                Activity = activity
            };
        }
    }
}
