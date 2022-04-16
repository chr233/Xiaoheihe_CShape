﻿using System.Text.Json.Serialization;

namespace Xiaoheihe_Core.Data
{
    public sealed class TaskSignResponse : BasicResponse<TaskSignResultData>
    {
    }

    public sealed class TaskSignResultData : BasicResultData
    {
        [JsonPropertyName("sign_in_exp")]
        public int SignInExp { get; set; }

        [JsonPropertyName("sign_in_coin")]
        public int SignInCoin { get; set; }

        [JsonPropertyName("sign_in_streak")]
        public int SignInStreak { get; set; }

        [JsonPropertyName("level_info")]
        public LevelInfoData LevelInfo { get; set; } = new();

        [JsonPropertyName("state")]
        public string State { get; set; } = "";

        public override string? ToString()
        {
            return LevelInfo.ToString();
        }
    }
}
