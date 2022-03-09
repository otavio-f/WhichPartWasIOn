namespace WhichPartWasIOn.Model.Watchable
{
    public class Anime : MediaBase
    {
        public string Studio { get; init; }
        public WatchTracking track { get; init; }
    }
}
