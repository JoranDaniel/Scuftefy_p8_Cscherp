class Song
{
    public string Name { get; }
    public string Artist { get; }
    public TimeSpan Duration { get; }
    public string Genre { get; }

    public Song(string name, string artist, TimeSpan duration, string genre)
    {
        Name = name;
        Artist = artist;
        Duration = duration;
        Genre = genre;
    }

    public int DurationInSeconds()
    {
        return (int)Duration.TotalSeconds;
    }
}
