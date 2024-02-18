public class RaceTrack
{
    public string TrackName { get; set; }
    public double TrackLength { get; set; }
    public string WeatherConditions { get; set; }

    public RaceTrack(string trackName, double trackLength, string weatherConditions)
    {
        TrackName = trackName;
        TrackLength = trackLength;
        WeatherConditions = weatherConditions;
    }
}
