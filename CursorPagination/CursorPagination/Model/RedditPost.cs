using System.Text.Json.Serialization;

namespace CursorPagination.Model
{
    public class RedditResponse
    {
        [JsonPropertyName("data")]
        public RedditListingData Data { get; set; } = new();
    }

    public class RedditListingData
    {
        [JsonPropertyName("after")]
        public string? After { get; set; }

        [JsonPropertyName("children")]
        public List<RedditChild> Children { get; set; } = new();
    }

    public class RedditChild
    {
        [JsonPropertyName("data")]
        public RedditPost Data { get; set; } = new();
    }

    public class RedditPost
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("author")]
        public string Author { get; set; } = "";

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("created_utc")]
        public double CreatedUtcSeconds { get; set; }

        [JsonIgnore]
        public DateTime CreatedUtc
             => DateTimeOffset.FromUnixTimeSeconds((long)Math.Floor(CreatedUtcSeconds)).UtcDateTime;
    }

}
