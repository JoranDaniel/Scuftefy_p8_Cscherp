class Playlist
{
    public string Name { get; } // Name of the playlist
    private List<Song> songs; // List of songs in the playlist

    public Playlist(string name) // Constructor
    {
        Name = name; // Set the name of the playlist
        songs = new List<Song>(); // Initialize the list of songs
    }

    public void AddSong(Song song) // Add a song to the playlist
    {
        songs.Add(song);// Add the song to the list of songs
    }

    public void RemoveSong(Song song) // Remove a song from the playlist
    {
        songs.Remove(song);// Remove the song from the list of songs
    }

    public Song FindSong(string songName) // Find a song in the playlist
    {
        foreach (Song song in songs) // Loop through all songs in the playlist
        {
            if (song.Name == songName) // If the song name matches the song name we are looking for
            {
                return song; // Return the song
            }
        }

        return null; // Return null if no song was found
    }

    public List<Song> GetSongs() // Get all songs in the playlist
    {
        return songs; // Return the list of songs
    }
}
