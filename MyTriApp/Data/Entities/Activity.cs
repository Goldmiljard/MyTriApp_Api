namespace MyTriApp.Data.Entities
{
    public class Activity : Entity
    {
        public Guid UserId { get; set; } //required foreign key property
        public User? User { get; set; } // required reference navigation to principal
        public string? Name { get; set; }
        public float Distance { get; set; }
        public int MovingTime { get; set; }
        public int ElapsedTime { get; set; }
        public float TotalElevationGain { get; set; }
        public string? SportType { get; set; }
        public long StravaId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public string? Timezone { get; set; }
        public float UtcOffset { get; set; }
        public float StartLat { get; set; }
        public float StartLng { get; set; }
        public float EndLat { get; set; }
        public float EndLng { get; set; }
        public string? Polyline { get; set; }
        public string? SummaryPolyline { get; set; }
        public float AverageSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public float AverageCadence { get; set; }
        public int AverageTemp { get; set; }
        public float AverageWatts { get; set; }
        public int WeightedAverageWatts { get; set; }
        public float Kilojoules { get; set; }
        public bool DeviceWatts { get; set; }
        public bool HasHeartrate { get; set; }
        public float AverageHeartrate { get; set; }
        public float MaxHeartrate { get; set; }
        public int MaxWatts { get; set; }
        public float ElevHigh { get; set; }
        public float ElevLow { get; set; }
        public int SufferScore { get; set; }
        public string? Description { get; set; }
        public float Calories { get; set; }
        public ICollection<Split>? Splits { get; set; }
        public ICollection<Lap>? Laps { get; set; }
        public string? Gear { get; set; }
        public int GearDistance { get; set; }
        public string? DeviceName { get; set; }
    }
}
