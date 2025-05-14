using CursorPagination.Model;
using System.Text.Json;

namespace CursorPagination.Services;

public class RedditService
{
    private readonly HttpClient _http;

    public RedditService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://www.reddit.com/");
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("CursorDemo/1.0");
    }

    public async Task<(List<RedditPost> Posts, string? NextCursor)> GetTopPostsAsync(
        string subreddit,
        int limit = 10,
        string? after = null)
    {
        var url = $"r/{subreddit}/top.json?limit={limit}"
                  + (string.IsNullOrEmpty(after) ? "" : $"&after={after}");

        using var res = await _http.GetAsync(url);
        res.EnsureSuccessStatusCode();

        var json = await res.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var root = JsonSerializer.Deserialize<RedditResponse>(json, options)
                   ?? throw new ApplicationException("Failed to deserialize Reddit response.");

        var posts = root.Data.Children
                           .Select(c => c.Data)
                           .ToList();

        return (posts, root.Data.After);
    }
}
