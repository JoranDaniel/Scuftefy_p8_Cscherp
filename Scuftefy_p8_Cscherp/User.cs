class User
{
    public string Username { get; } // Username of the user
    private List<Playlist> playlists; // List of playlists of the user
    private List<User> friends; // List of friends of the user

    public User(string username) // Constructor
    {
        Username = username; // Set the username of the user
        playlists = new List<Playlist>();   // Initialize the list of playlists
        friends = new List<User>(); // Initialize the list of friends
    }

    public void AddPlaylist(Playlist playlist) // Add a playlist to the user 
    {
        playlists.Add(playlist); // Add the playlist to the list of playlists
    }

    public void RemovePlaylist(Playlist playlist) // Remove a playlist from the user
    {
        playlists.Remove(playlist); // Remove the playlist from the list of playlists
    }

    public Playlist FindPlaylist(string playlistName)  // Find a playlist in the user
    {
        foreach (Playlist playlist in playlists) // Loop through all playlists in the user
        {
            if (playlist.Name == playlistName)  // If the playlist name matches the playlist name we are looking for
            { 
                return playlist; // Return the playlist
            }
        }

        return null; // Return null if no playlist was found
    }

    public List<Playlist> GetPlaylists() // Get all playlists of the user
    {
        return playlists; // Return the list of playlists
    }

    public void AddFriend(User friend) // Add a friend to the user
    {
        friends.Add(friend); // Add the friend to the list of friends
    }

    public void RemoveFriend(User friend) // Remove a friend from the user
    {
        friends.Remove(friend); // Remove the friend from the list of friends
    }

    public User FindFriend(string friendUsername) // Find a friend in the user
    {
        foreach (User friend in friends) // Loop through all friends in the user
        {
            if (friend.Username == friendUsername) // If the friend username matches the friend username we are looking for
            {
                return friend; // Return the friend 
            } 
        }

        return null; // Return null if no friend was found
    }

    public List<User> GetFriends() // Get all friends of the user
    {
        return friends; // Return the list of friends
    }
}