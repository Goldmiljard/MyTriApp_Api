namespace MyTriApp.Weather_API.DTOs
{
    public class WeatherDTO
    {
        public float? wdir { get; set; }
        public float? temp { get; set; }
        public float? maxt { get; set; }
        public float? visibility { get; set; }
        public float? wspd { get; set; }
        public float? cloudcover { get; set; }
        public float? mint { get; set; }
        public float? precip { get; set; }
        public string? weathertype { get; set; }
        public float? snowdepth { get; set; }
        public float? sealevelpressure { get; set; }
        public float? snow { get; set; }
        public float? dew { get; set; }
        public float? humidity { get; set; }
        public float? wgust { get; set; }
        public string? conditions { get; set; }
        public float? windchill { get; set; }

        public WeatherDTO(dynamic values)
        {
            wdir = values.wdir;
            temp = values.temp;
            maxt = values.maxt;
            visibility = values.visibility;
            wspd = values.wspd;
            cloudcover = values.cloudcover;
            mint = values.mint;
            precip = values.precip;
            weathertype = values.weathertype;
            snowdepth = values.snowdepth;
            sealevelpressure = values.sealevelpressure;
            snow = values.snow;
            dew = values.dew;
            humidity = values.humidity;
            wgust = values.wgust;
            conditions = values.conditions;
            windchill = values.windchill;     
        }
    }
}
