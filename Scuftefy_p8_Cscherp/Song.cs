class Song // Song class
{
    public string Name { get; } // Name of the song
    public string Artist { get; } // Artist of the song
    public TimeSpan Duration { get; }   // Duration of the song
    public string Genre { get; } // Genre of the song

    public Song(string name, string artist, TimeSpan duration, string genre) // Constructor
    {
        Name = name; // Set the name of the song
        Artist = artist; // Set the artist of the song
        Duration = duration; // Set the duration of the song
        Genre = genre; // Set the genre of the song
    }

    public int DurationInSeconds() // Get the duration of the song in seconds
    {
        return (int)Duration.TotalSeconds; // Return the duration of the song in seconds
    }
}
