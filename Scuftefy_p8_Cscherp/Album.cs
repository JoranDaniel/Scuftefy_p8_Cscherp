class Album
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }
    public List<Song> Songs { get; set; }

    public Album(string title, string artist, int year)
    {
        Title = title;
        Artist = artist;
        Year = year;
        Songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        Songs.Remove(song);
    }

    

    
    
}
