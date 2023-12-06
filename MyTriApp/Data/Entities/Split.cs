namespace MyTriApp.Data.Entities
{
    public class Split : Entity
    {
        public float Distance { get; set; }
        public int ElapsedTime { get; set; }
        public float ElevationDifference { get; set; }
        public int MovingTime { get; set; }
        public int SplitNumber { get; set; }
        public float AverageSpeed { get; set; }
        public int PaceZone { get; set; }
        public Activity Activity { get; set; }
    }
}
