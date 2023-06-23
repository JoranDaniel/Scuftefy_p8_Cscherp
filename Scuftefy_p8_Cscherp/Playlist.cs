class Playlist
{
    public string Name { get; }
    private List<Song> songs;

    public Playlist(string name)
    {
        Name = name;
        songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        songs.Remove(song);
    }

    public Song FindSong(string songName)
    {
        foreach (Song song in songs)
        {
            if (song.Name == songName)
            {
                return song;
            }
        }

        return null;
    }

    public List<Song> GetSongs()
    {
        return songs;
    }
}
