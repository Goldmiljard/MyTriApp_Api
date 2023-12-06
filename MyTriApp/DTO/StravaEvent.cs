namespace MyTriApp.DTO
{
    public class StravaEvent
    {
        public string? aspect_type { get; set; }
        public long event_time { get; set; }
        public long object_id { get; set; }
        public string? object_type { get; set; }
        public long owner_id { get; set; }
        public int subscription_id { get; set; }
        public Updates? updates { get; set; }
    }

    public class Updates
    {
        public string? title { get; set; }

        public string? type { get; set; }
    }


}
