﻿using System.Text.Json.Serialization;

namespace Xiaoheihe_Core.Data
{
    public sealed class SendCommentsResponse : BasicResponse<SendCommentsResultData>
    {
    }

    public sealed class SendCommentsResultData : BasicResultData
    {
        [JsonPropertyName("comment")]
        public CommentDataData Comment { get; set; } = new();

        [JsonPropertyName("reply_push_state")]
        public ReplyPushStateData ReplyPushState { get; set; } = new();
    }

    public class CommentDataData
    {
        [JsonPropertyName("comment")]
        public HashSet<CommentData> Comment { get; set; } = new();
    }

    public sealed class CommentData
    {
        [JsonPropertyName("is_support")]
        public byte IsSupport { get; set; }

        [JsonPropertyName("replyuser")]
        public HeyboxUserData? ReplyUser { get; set; }

        [JsonPropertyName("has_more")]
        public byte HasMore { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; } = "";

        [JsonPropertyName("floor_num")]
        public uint Floor { get; set; }

        [JsonPropertyName("up")]
        public uint Up { get; set; }

        [JsonPropertyName("create_at")]
        public DateTime CreateAt { get; set; } = default;

        [JsonPropertyName("is_link_owner")]
        public byte IsLinkOwner { get; set; }

        [JsonPropertyName("user")]
        public HeyboxUserData User { get; set; } = new();

        [JsonPropertyName("commentid")]
        public ulong CommentID { get; set; }

        [JsonPropertyName("child_num")]
        public uint ChildCount { get; set; }

        [JsonPropertyName("is_cy")]
        public byte IsCy { get; set; }

        public override string? ToString()
        {
            return $"[{User}] {Text}";
        }
    }
}
