public sealed class TopRequestedApiReport
{
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public int HitCount { get; set; }
}