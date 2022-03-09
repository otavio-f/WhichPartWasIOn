namespace WhichPartWasIOn.Model.Readable
{
    public class Book : MediaBase
    {
        public string Publisher { get; init; }
        public ReadTracking Track { get; init; }
    }
}
