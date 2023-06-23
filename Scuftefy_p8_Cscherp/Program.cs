using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static List<Playlist> playlists = new List<Playlist>(); // List of all playlists
    static List<User> users = new List<User>(); // List of all users
    static User currentUser; // The user that is currently logged in

    static void Main(string[] args) // This is the entry point of the program
    {
        Run(); // Start the program
    }

    static void Run()
    {
        Console.WriteLine("Welkom bij Scuftefy!"); 
        Console.WriteLine("Voer je gebruikersnaam in:");
        string username = Console.ReadLine(); // dit zorgt er voor dat je een gebruikersnaam kan invoeren

       
        currentUser = FindUser(username); // dit zorgt er voor dat je een gebruikersnaam kan vinden

        if (currentUser == null) // als de gebruikersnaam niet bestaat dan wordt er een nieuwe gebruiker aangemaakt
        {
            
            currentUser = new User(username); // dit zorgt er voor dat je een nieuwe gebruiker kan aanmaken
            users.Add(currentUser); // dit zorgt er voor dat de nieuwe gebruiker wordt toegevoegd aan de lijst met gebruikers
            Console.WriteLine("Nieuwe gebruiker aangemaakt: " + currentUser.Username); // dit zorgt er voor dat er een bericht wordt weergegeven dat er een nieuwe gebruiker is aangemaakt
        }
        else
        {
            Console.WriteLine("Ingelogd als: " + currentUser.Username); // dit zorgt er voor dat er een bericht wordt weergegeven dat je bent ingelogd
        }

        ShowMenu(); // dit zorgt er voor dat het menu wordt weergegeven
    }

    static void ShowMenu() // dit zorgt er voor dat het menu wordt weergegeven
    {
        Console.WriteLine("Kies een optie:");
        Console.WriteLine("1. Album");
        Console.WriteLine("2. Alle songs bekijken");
        Console.WriteLine("3. Playlist aanmaken");
        Console.WriteLine("4. Afspeellijsten bekijken");
        Console.WriteLine("5. Nummer toevoegen aan afspeellijst");
        Console.WriteLine("6. Nummer verwijderen uit afspeellijst");
        Console.WriteLine("7. Nummer of afspeellijst afspelen");
        Console.WriteLine("8. Vrienden");
        Console.WriteLine("9. Afsluiten");

        string userInput = Console.ReadLine(); // dit zorgt er voor dat je een keuze kan maken uit het menu
        int choice; // dit zorgt er voor dat je een keuze kan maken uit het menu

        if (int.TryParse(userInput, out choice)) // dit zorgt er voor dat je een keuze kan maken uit het menu
        {
            switch (choice) // dit zorgt er voor dat je een keuze kan maken uit het menu
            {
                case 1:
                    ViewAlbum();
                    break;
                case 2:
                    ViewAllSongs();
                    break;
                case 3:
                    CreatePlaylist();
                    break;
                case 4:
                    ViewPlaylists();
                    break;
                case 5:
                    AddSongToPlaylist();
                    break;
                case 6:
                    RemoveSongFromPlaylist();
                    break;
                case 7:
                    PlaySongOrPlaylist();
                    break;
                case 8:
                    ManageFriends();
                    break;
                case 9:
                    Console.WriteLine("Tot ziens!");
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ongeldige invoer. Probeer het opnieuw."); // dit zorgt er voor dat er een bericht wordt weergegeven dat de invoer ongeldig is
        }

        ShowMenu();
    }

    static void ViewAlbum() // dit zorgt er voor dat je een album kan bekijken
    {
        Console.WriteLine("Je hebt gekozen voor 'Album'.");
        Console.WriteLine("Beschikbare albums:");

        Console.WriteLine("1. Album 1 - Artiest 1");
        Console.WriteLine("2. Album 2 - Artiest 2");
       

        Console.WriteLine("Kies een album om acties uit te voeren:");

       
        int choice = int.Parse(Console.ReadLine()); // dit zorgt er voor dat je een album kan kiezen

        switch (choice)
        {
            case 1:
              
                Console.WriteLine("Je hebt Album 1 geselecteerd."); // dit zorgt er voor dat je album 1 kan selecteren

                Console.WriteLine("Kies een optie:");
                Console.WriteLine("1. Voeg het album toe aan je afspeellijst"); 
                Console.WriteLine("2. Speel het album af");

          
                int albumAction = int.Parse(Console.ReadLine());

                if (albumAction == 1) // dit zorgt er voor dat je album 1 kan toevoegen aan je afspeellijst
                {
                   
                    Console.WriteLine("Album 1 is toegevoegd aan je afspeellijst."); // dit zorgt er voor dat er een bericht wordt weergegeven dat album 1 is toegevoegd aan je afspeellijst
                }
                else if (albumAction == 2) // dit zorgt er voor dat je album 1 kan afspelen
                {
                 
                    Console.WriteLine("Album 1 wordt afgespeeld."); // dit zorgt er voor dat er een bericht wordt weergegeven dat album 1 wordt afgespeeld
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                }

                break;

            case 2:
               
                Console.WriteLine("Je hebt Album 2 geselecteerd.");

                Console.WriteLine("Kies een optie:");
                Console.WriteLine("1. Voeg het album toe aan je afspeellijst");
                Console.WriteLine("2. Speel het album af");

                int album2Action = int.Parse(Console.ReadLine()); // dit zorgt er voor dat je album 2 kan kiezen

                if (album2Action == 1) // dit zorgt er voor dat je album 2 kan toevoegen aan je afspeellijst
                {
                    Console.WriteLine("Album 2 is toegevoegd aan je afspeellijst.");
                }
                else if (album2Action == 2) // dit zorgt er voor dat je album 2 kan afspelen
                {
                   
                    Console.WriteLine("Album 2 wordt afgespeeld.");
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                }

                break;

            default:
                Console.WriteLine("Ongeldige keuze. Probeer het opnieuw."); // dit zorgt er voor dat er een bericht wordt weergegeven dat de invoer ongeldig is
                break;
        }

        ShowMenu();
    }

    static void RemoveSongFromPlaylist()
    {
        Console.WriteLine("Voer de naam van de afspeellijst in:"); // dit zorgt er voor dat je de naam van de afspeellijst kan invoeren
        string playlistName = Console.ReadLine();

        Console.WriteLine("Voer de naam van het nummer in dat je wilt verwijderen:");
        string songName = Console.ReadLine();

        Playlist playlist = currentUser.FindPlaylist(playlistName);

        if (playlist == null) // dit zorgt er voor dat je de naam van de afspeellijst kan invoeren
        {
            Console.WriteLine("Afspeellijst niet gevonden."); // dit zorgt er voor dat er een bericht wordt weergegeven dat de afspeellijst niet is gevonden
            ReturnToMenu();
            return;
        }

        Song song = playlist.FindSong(songName); // dit zorgt er voor dat je de naam van het nummer kan invoeren

        if (song == null)
        {
            Console.WriteLine("Nummer niet gevonden in de afspeellijst."); // dit zorgt er voor dat er een bericht wordt weergegeven dat het nummer niet is gevonden in de afspeellijst
            ReturnToMenu();
            return;
        }

        playlist.RemoveSong(song);
        Console.WriteLine("Nummer succesvol verwijderd uit de afspeellijst."); // dit zorgt er voor dat er een bericht wordt weergegeven dat het nummer succesvol is verwijderd uit de afspeellijst

        ReturnToMenu(); // dit zorgt er voor dat je terug kan naar het menu
    }


    static void PlaySongOrPlaylist() // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
    {
        Console.WriteLine("Voer de naam van de playlist in:");
        string playlistName = Console.ReadLine();

        Playlist playlist = currentUser.FindPlaylist(playlistName);

        if (playlist == null) // dit zorgt er voor dat je de naam van de afspeellijst kan invoeren
        {
            Console.WriteLine("Playlist niet gevonden.");
            ReturnToMenu();
            return;
        }

        Console.WriteLine("Je speelt nu af: " + playlist.Name);// dit zorgt er voor dat er een bericht wordt weergegeven dat je nu afspeelt

        Console.WriteLine("Kies een optie:");
        Console.WriteLine("1. Playlist willekeurig afspelen");
        Console.WriteLine("2. Playlist in volgorde afspelen");
        Console.WriteLine("3. Afzonderlijk nummer afspelen");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
        {
            Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
            PlaySongOrPlaylist();
            return;
        }

        switch (choice) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
        {
            case 1:
                PlayPlaylistRandom(playlist);
                break;
            case 2:
                PlayPlaylist(playlist);
                break;
            case 3:
                PlayIndividualSong(playlist);
                break;
        }
    }

    static void PlayPlaylistRandom(Playlist playlist) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
    {
        List<Song> songs = playlist.GetSongs();

        if (songs.Count == 0)
        {
            Console.WriteLine("De playlist bevat geen nummers om af te spelen.");
            ReturnToMenu();
            return;
        }

        Console.WriteLine("De playlist '" + playlist.Name + "' wordt willekeurig afgespeeld...");
        Console.WriteLine("Je kunt pauzeren met p en skippen met s.");

        Random random = new Random(); // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
        int currentSongIndex = random.Next(0, songs.Count); // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen

        while (true)
        {
            Song currentSong = songs[currentSongIndex];
            Console.WriteLine("Nu wordt afgespeeld: " + currentSong.Name);
            PlaySong(currentSong);

            currentSongIndex++;
            if (currentSongIndex >= songs.Count)
            {
                currentSongIndex = 0;
            }

            Console.WriteLine("Wil je doorgaan met het afspelen van de volgende song? (ja/nee)");
            string answer = Console.ReadLine();

            if (answer.ToLower() != "ja")
            {
                break;
            }
        }

        ReturnToMenu();
    }

    static void PlayPlaylist(Playlist playlist) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
    {
        List<Song> songs = playlist.GetSongs();

        if (songs.Count == 0)
        {
            Console.WriteLine("De playlist bevat geen nummers om af te spelen.");
            ReturnToMenu();
            return;
        }

        Console.WriteLine("De playlist '" + playlist.Name + "' wordt afgespeeld...");
        Console.WriteLine("Je kunt pauzeren met p en skippen met s.");

        foreach (Song song in songs) // dit is een foreach loop
        {
            Console.WriteLine("Nu wordt afgespeeld: " + song.Name);
            PlaySong(song);

            Console.WriteLine("Wil je doorgaan met het afspelen van de volgende song? (ja/nee)");
            string answer = Console.ReadLine();

            if (answer.ToLower() != "ja")
            {
                break;
            }
        }

        ReturnToMenu();
    }

    static void PlayIndividualSong(Playlist playlist) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen en dit is een foreach loop
    {
        Console.WriteLine("Kies een nummer om af te spelen:");

        List<Song> songs = playlist.GetSongs();
        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + songs[i].Name);
        }

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > songs.Count)
        {
            Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
            PlayIndividualSong(playlist);
            return;
        }

        Song selectedSong = songs[choice - 1];
        Console.WriteLine("Je hebt het nummer '" + selectedSong.Name + "' geselecteerd om af te spelen.");
        Console.WriteLine("Je kunt pauzeren met p en skippen met s.");

        PlaySong(selectedSong);

        ReturnToMenu();
    }

    static void PlaySong(Song song) // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
    {
        Console.WriteLine(song.Name + " wordt afgespeeld...");

        for (int secondsLeft = song.DurationInSeconds(); secondsLeft >= 0; secondsLeft--)
        {
            Console.Write(song.Name + " is aan het spelen. Tijd over: " + secondsLeft + " seconden.\r");
            Thread.Sleep(1000);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.KeyChar == 'p')
                {
                    Console.WriteLine("\nHet afspelen is gepauzeerd. Druk op 'p' om verder te gaan of 's' om te skippen.");
                    while (true)
                    {
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.KeyChar == 'p') // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
                        {
                            Console.WriteLine("\nHet afspelen wordt hervat...");
                            break;
                        }
                        else if (keyInfo.KeyChar == 's')
                        {
                            Console.WriteLine("\nHet nummer wordt overgeslagen...");
                            return;
                        }
                    }
                }
                else if (keyInfo.KeyChar == 's') // dit zorgt er voor dat je een nummer of afspeellijst kan afspelen
                {
                    Console.WriteLine("\nHet nummer wordt overgeslagen...");
                    return;
                }
            }
        }

        Console.WriteLine(song.Name + " is afgelopen.");
    }



    static void ViewAllSongs() // di
    {
        Console.WriteLine("Je hebt gekozen voor 'Alle songs bekijken'.");
        ReturnToMenu();
    }

    static void CreatePlaylist()
    {
        Console.WriteLine("Voer de naam van de playlist in:");
        string playlistName = Console.ReadLine();

        Playlist playlist = new Playlist(playlistName);
        currentUser.AddPlaylist(playlist);

        Console.WriteLine("Playlist aangemaakt: " + playlist.Name);
    }

    static void ViewPlaylists()
    {
        Console.WriteLine("Je afspeellijsten:");
        List<Playlist> userPlaylists = currentUser.GetPlaylists();

        foreach (Playlist playlist in userPlaylists)
        {
            Console.WriteLine(playlist.Name);
        }
    }

    static void AddSongToPlaylist()
{
    Console.WriteLine("Voer de naam van de afspeellijst in waar je het nummer aan wilt toevoegen:");

    for (int i = 0; i < playlists.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {playlists[i].Name}");
    }

    int playlistIndex;
    if (!int.TryParse(Console.ReadLine(), out playlistIndex) || playlistIndex < 1 || playlistIndex > playlists.Count)
    {
        Console.WriteLine("Ongeldige invoer voor de afspeellijst. Probeer het opnieuw.");
        AddSongToPlaylist();
        return;
    }

    string playlistName = playlists[playlistIndex - 1].Name;

    Console.WriteLine("Voer de naam van het nummer in:");
    string songName = Console.ReadLine();

    Console.WriteLine("Voer de naam van de artiest in:");
    string artistName = Console.ReadLine();

    Console.WriteLine("Voer de duur van het nummer in seconden in:");
    int durationInSeconds;
    if (!int.TryParse(Console.ReadLine(), out durationInSeconds))
    {
        Console.WriteLine("Ongeldige invoer voor de duur. Probeer het opnieuw.");
        AddSongToPlaylist();
        return;
    }

    Console.WriteLine("Voer het genre van het nummer in:");
    string genre = Console.ReadLine();

    Song newSong = new Song(songName, artistName, TimeSpan.FromSeconds(durationInSeconds), genre);

    Playlist playlist = FindPlaylist(playlistName);

    if (playlist != null)
    {
        playlist.AddSong(newSong);
        Console.WriteLine("Nummer succesvol toegevoegd aan de afspeellijst.");
    }
    else
    {
        Console.WriteLine("Afspeellijst niet gevonden.");
    }

    ReturnToMenu();
}

static Playlist FindPlaylist(string playlistName)
{
    return playlists.FirstOrDefault(playlist => playlist.Name == playlistName);
}Playlist FindOrCreatePlaylist(string playlistName)
    {
        List<Playlist> existingPlaylists = GetAllPlaylists();

        // Zoek naar een bestaande afspeellijst met dezelfde naam
        Playlist existingPlaylist = existingPlaylists.FirstOrDefault(playlist => playlist.Name == playlistName);

        if (existingPlaylist != null)
        {
            return existingPlaylist;
        }

        // De afspeellijst bestaat niet, maak een nieuwe
        Playlist newPlaylist = new Playlist(playlistName);
        existingPlaylists.Add(newPlaylist); // Voeg de nieuwe afspeellijst toe aan de lijst van bestaande afspeellijsten

        return newPlaylist;
    }


    static List<Playlist> GetAllPlaylists()
{
    // Implementeer deze methode om alle bestaande afspeellijsten op te halen
    // Dit kan bijvoorbeeld een databasequery zijn of een andere methode om alle afspeellijsten in het geheugen op te halen

    // Voorbeeldimplementatie:
    List<Playlist> playlists = new List<Playlist>();
    // Voeg hier code toe om alle afspeellijsten op te halen

    return playlists;
}




    static void ManageFriends()
    {
        Console.WriteLine("Ingelogde gebruiker: " + (currentUser != null ? currentUser.Username : "Geen gebruiker ingelogd"));

        if (currentUser == null)
        {
            Login();
        }
        else
        {
            Console.WriteLine("Kies een optie:");
            Console.WriteLine("1. Vrienden weergeven");
            Console.WriteLine("2. Vriend toevoegen");
            Console.WriteLine("3. Vriend verwijderen");
            Console.WriteLine("4. Uitloggen");
            Console.WriteLine("5. Bestaande gebruikers");
            Console.WriteLine("6. Nieuwe gebruiker aanmaken");
            Console.WriteLine("7. Playlist inzien van vrienden");

            string userInput = Console.ReadLine(); // Lees de invoer van de gebruiker
            int choice;

            if (int.TryParse(userInput, out choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewFriends();
                        break;
                    case 2:
                        AddFriend();
                        break;
                    case 3:
                        RemoveFriend();
                        break;
                    case 4:
                        Console.WriteLine("Uitloggen...");
                        currentUser = null;
                        ManageFriends();
                        break;
                    case 5:
                        ShowExistingUsers();
                        break;
                    case 6:
                        CreateNewUser();
                        break;
                    case 7:
                        ViewFriendPlaylists();
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                        ManageFriends();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Probeer het opnieuw.");
                ManageFriends();
            }
        }
    }

    static void Login() //soort van Inloggen met alleen een naam invoeren
    {
        Console.Write("Voer je gebruikersnaam in: ");
        string username = Console.ReadLine();

        User user = FindUser(username);

        if (user == null)
        {
            Console.WriteLine("Gebruiker niet gevonden.");
            Login();
            return;
        }

        currentUser = user;
        Console.WriteLine("Inloggen gelukt!");
        ManageFriends();
    }

    static void ViewFriends() // Vrienden weergeven
    {
        List<User> friends = currentUser.GetFriends();

        if (friends.Count > 0)
        {
            Console.WriteLine("Je vrienden:");
            for (int i = 0; i < friends.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {friends[i].Username}");
            }
        }
        else
        {
            Console.WriteLine("Je hebt geen vrienden.");
        }

        ReturnToMenu();
    }

    static void AddFriend() // Vriend toevoegen
    {
        Console.WriteLine("Voer de gebruikersnaam van je vriend in:");
        string friendUsername = Console.ReadLine();

        User friend = FindUser(friendUsername);

        if (friend == null)
        {
            Console.WriteLine("Gebruiker niet gevonden.");
            ManageFriends();
            return;
        }

        currentUser.AddFriend(friend);
        Console.WriteLine("Vriend toegevoegd: " + friend.Username);

        ReturnToMenu();
    }

    static void RemoveFriend() // Vriend verwijderen (werkt niet naar hoe ik het wil :( )
    {
        Console.WriteLine("Voer de gebruikersnaam van de vriend die je wilt verwijderen in:");
        string friendUsername = Console.ReadLine();

        User friend = currentUser.FindFriend(friendUsername);

        if (friend == null)
        {
            Console.WriteLine("Vriend niet gevonden.");
            ManageFriends();
            return;
        }

        currentUser.RemoveFriend(friend);
        Console.WriteLine("Vriend verwijderd: " + friend.Username);

        ReturnToMenu();
    }

    static void ChangeUser() // Gebruiker wijzigen
    {
        Console.WriteLine("Voer de gebruikersnaam van de nieuwe gebruiker in:");
        string newUsername = Console.ReadLine();

        User newUser = FindUser(newUsername);

        if (newUser == null)
        {
            newUser = CreateUser(newUsername);
            Console.WriteLine("Nieuwe gebruiker aangemaakt: " + newUser.Username);
        }

        currentUser = newUser;
        Console.WriteLine("Gebruiker succesvol gewijzigd naar: " + currentUser.Username);

        ReturnToMenu();
    }

    static void ShowExistingUsers() // Bestaande gebruikers weergeven
    {
        Console.WriteLine("Bestaande gebruikers:");

        foreach (User user in users)
        {
            Console.WriteLine(user.Username);
        }

        ReturnToMenu();
    }

    static void CreateNewUser() // Nieuwe gebruiker aanmaken
    {
        Console.WriteLine("Voer de gebruikersnaam van de nieuwe gebruiker in:");
        string newUsername = Console.ReadLine();

        User existingUser = FindUser(newUsername);

        if (existingUser != null)
        {
            Console.WriteLine("Gebruikersnaam is al in gebruik. Kies een andere gebruikersnaam.");
            CreateNewUser();
            return;
        }

        User newUser = CreateUser(newUsername);
        Console.WriteLine("Nieuwe gebruiker aangemaakt: " + newUser.Username);

        ReturnToMenu();
    }

    static void ViewFriendPlaylists() // Playlist inzien van vrienden
    {
        List<User> friends = currentUser.GetFriends();

        if (friends.Count > 0)
        {
            Console.WriteLine("Selecteer een vriend om zijn/haar afspeellijsten te bekijken:");
            for (int i = 0; i < friends.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {friends[i].Username}");
            }

            string userInput = Console.ReadLine();
            int friendIndex;

            if (int.TryParse(userInput, out friendIndex)) // Als de gebruiker een geldig getal heeft ingevoerd
            {
                if (friendIndex >= 1 && friendIndex <= friends.Count) // Als de gebruiker een geldige keuze heeft gemaakt
                {
                    User selectedFriend = friends[friendIndex - 1];
                    List<Playlist> playlists = selectedFriend.GetPlaylists(); // Hier wordt de lijst met afspeellijsten van de geselecteerde vriend opgehaald

                    if (playlists.Count > 0)
                    {
                        Console.WriteLine($"Afspeellijsten van {selectedFriend.Username}:");
                        for (int i = 0; i < playlists.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {playlists[i].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{selectedFriend.Username} heeft geen afspeellijsten."); // Als je vriend geen afspeellijsten heeft
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                }
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Probeer het opnieuw.");
            }
        }
        else
        {
            Console.WriteLine("Je hebt geen vrienden."); // Als je geen vrienden hebt
        }

        ReturnToMenu();
    }

    static User CreateUser(string username) // Methode om een gebruiker aan te maken
    {
        User newUser = new User(username);
        users.Add(newUser);
        return newUser;
    }

    static User FindUser(string username) // Methode om een gebruiker te vinden
    {
        foreach (User user in users)
        {
            if (user.Username == username)
            {
                return user;
            }
        }

        return null;
    }

    static void ReturnToMenu() // Methode om terug te keren naar het hoofdmenu
    {
        Console.WriteLine("Druk op een toets om terug te keren naar het hoofdmenu.");
        Console.ReadKey();
        Console.Clear();
        ShowMenu();
    }


}