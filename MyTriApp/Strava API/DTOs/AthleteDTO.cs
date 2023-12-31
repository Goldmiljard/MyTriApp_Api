﻿namespace MyTriApp.Services.DTOs
{
    public class AthleteDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public int resource_state { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string bio { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string sex { get; set; }
        public bool premium { get; set; }
        public bool summit { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int badge_type_id { get; set; }
        public float weight { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public string friend { get; set; }
        public string follower { get; set; }
    }
}
