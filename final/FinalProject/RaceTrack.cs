public class RaceTrack
{
    public string TrackName { get; private set; }
    public double TrackLength { get; private set; }
    public string WeatherConditions { get; private set; }
    public string TrackType { get; private set; }

    public RaceTrack(string trackName, double trackLength, string weatherConditions, string trackType)
    {
        TrackName = trackName;
        TrackLength = trackLength;
        WeatherConditions = weatherConditions;
        TrackType = trackType;
    }
}
