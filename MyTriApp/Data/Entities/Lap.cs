namespace MyTriApp.Data.Entities
{
    public class Lap : Entity
    {
        public long StravaId { get; set; }
        public string? Name { get; set; }
        public int ElapsedTime { get; set; }
        public int MovingTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public float Distance { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public float TotalElevationGain { get; set; }
        public float AverageHeartrate { get; set; }
        public float MaxHeartrate { get; set; }
        public float AverageSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public float AverageCadence { get; set; }
        public bool DeviceWatts { get; set; }
        public float AverageWatts { get; set; }
        public int LapIndex { get; set; }
        public int SplitNumber { get; set; }
        public Activity Activity { get; set; }
    }
}
