﻿using System.Text.Json.Serialization;

namespace Xiaoheihe_Core.Data
{
    public sealed class UserEventsResponse : BasicResponse<UserEventsResult>
    {
    }

    public sealed class UserEventsResult : BasicResultData
    {
        [JsonPropertyName("moments")]
        public HashSet<MonentData> Moments { get; set; } = new();

        [JsonPropertyName("push_mode")]
        public int PushMode { get; set; }

        [JsonPropertyName("user")]
        public HeyboxUserDetailData User { get; set; } = new();
    }

    public sealed class MonentData
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; } = default;

        [JsonPropertyName("link")]
        public NewsLinkData Link { get; set; } = new();

        [JsonPropertyName("user")]
        public HeyboxUserData User { get; set; } = new();

        [JsonPropertyName("level_info")]
        public LevelInfoData LevelInfo { get; set; } = new();

        [JsonPropertyName("content_type")]
        public string ContentType { get; set; } = "";

        [JsonPropertyName("group_id")]
        public ulong GroupId { get; set; }

        [JsonPropertyName("group_type")]
        public string GroupType { get; set; } = "";

        public override string? ToString()
        {
            return $"[{ContentType}] {Link} {Timestamp}";
        }
    }
}
