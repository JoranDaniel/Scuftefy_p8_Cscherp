class User
{
    public string Username { get; }
    private List<Playlist> playlists;
    private List<User> friends;

    public User(string username)
    {
        Username = username;
        playlists = new List<Playlist>();
        friends = new List<User>();
    }

    public void AddPlaylist(Playlist playlist)
    {
        playlists.Add(playlist);
    }

    public void RemovePlaylist(Playlist playlist)
    {
        playlists.Remove(playlist);
    }

    public Playlist FindPlaylist(string playlistName)
    {
        foreach (Playlist playlist in playlists)
        {
            if (playlist.Name == playlistName)
            {
                return playlist;
            }
        }

        return null;
    }

    public List<Playlist> GetPlaylists()
    {
        return playlists;
    }

    public void AddFriend(User friend)
    {
        friends.Add(friend);
    }

    public void RemoveFriend(User friend)
    {
        friends.Remove(friend);
    }

    public User FindFriend(string friendUsername)
    {
        foreach (User friend in friends)
        {
            if (friend.Username == friendUsername)
            {
                return friend;
            }
        }

        return null;
    }

    public List<User> GetFriends()
    {
        return friends;
    }
}