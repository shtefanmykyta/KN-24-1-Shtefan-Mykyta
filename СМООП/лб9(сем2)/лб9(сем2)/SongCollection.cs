using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб9_сем2_
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    public class SongCollection
    {
        private List<Song> songs;

        public SongCollection()
        {
            songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
            Console.WriteLine($"Song '{song.Title}' added.");
        }

        public void DeleteSong(string title)
        {
            int initialCount = songs.Count;
            songs.RemoveAll(song => song.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (songs.Count < initialCount)
            {
                Console.WriteLine($"Song '{title}' deleted.");
            }
            else
            {
                Console.WriteLine($"Song with title '{title}' not found.");
            }
        }

        public void ModifySong(string titleToModify, Song updatedSong)
        {
            Song song = songs.FirstOrDefault(s => s.Title.Equals(titleToModify, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                song.Title = updatedSong.Title;
                song.Author = updatedSong.Author;
                song.Composer = updatedSong.Composer;
                song.Year = updatedSong.Year;
                song.Lyrics = updatedSong.Lyrics;
                song.Performers = updatedSong.Performers;
                Console.WriteLine($"Information for song '{titleToModify}' updated.");
            }
            else
            {
                Console.WriteLine($"Song with title '{titleToModify}' not found.");
            }
        }

        public List<Song> SearchSongs(Func<Song, bool> predicate)
        {
            return songs.Where(predicate).ToList();
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(songs, options);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Song collection saved to '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    var loadedSongs = JsonSerializer.Deserialize<List<Song>>(jsonString);
                    if (loadedSongs != null)
                    {
                        songs = loadedSongs;
                        Console.WriteLine($"Song collection loaded from '{filePath}'.");
                    }
                    else
                    {
                        Console.WriteLine($"File '{filePath}' is empty or contains invalid data.");
                    }
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }

        public List<Song> GetSongsByPerformer(string performerName)
        {
            return songs.Where(song => song.Performers.Any(p => p.Equals(performerName, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public void DisplayAllSongs()
        {
            if (songs.Count == 0)
            {
                Console.WriteLine("The song collection is empty.");
                return;
            }
            Console.WriteLine("\n--- All Songs ---");
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
            Console.WriteLine("------------------");
        }
    }

    public class SongApp
    {
        public static void Main(string[] args)
        {
            SongCollection collection = new SongCollection();

            while (true)
            {
                Console.WriteLine("\n--- Song Collection Application ---");
                Console.WriteLine("1. Add Song");
                Console.WriteLine("2. Delete Song");
                Console.WriteLine("3. Modify Song");
                Console.WriteLine("4. Search Songs");
                Console.WriteLine("5. Save Collection to File");
                Console.WriteLine("6. Load Collection from File");
                Console.WriteLine("7. Display Songs by Performer");
                Console.WriteLine("8. Display All Songs");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Add New Song ---");
                        Song newSong = GetSongDetailsFromUser();
                        collection.AddSong(newSong);
                        break;
                    case "2":
                        Console.Write("Enter the title of the song to delete: ");
                        string titleToDelete = Console.ReadLine();
                        collection.DeleteSong(titleToDelete);
                        break;
                    case "3":
                        Console.Write("Enter the title of the song to modify: ");
                        string titleToModify = Console.ReadLine();
                        Console.WriteLine("\n--- Enter Updated Song Details ---");
                        Song updatedSong = GetSongDetailsFromUser();
                        collection.ModifySong(titleToModify, updatedSong);
                        break;
                    case "4":
                        Console.WriteLine("\n--- Search Songs ---");
                        Console.WriteLine("a. By Title");
                        Console.WriteLine("b. By Author");
                        Console.WriteLine("c. By Composer");
                        Console.WriteLine("d. By Year");
                        Console.Write("Enter search criteria: ");
                        string searchChoice = Console.ReadLine().ToLower();
                        switch (searchChoice)
                        {
                            case "a":
                                Console.Write("Enter title to search: ");
                                string searchTitle = Console.ReadLine();
                                var byTitle = collection.SearchSongs(s => s.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase));
                                DisplaySearchResults(byTitle);
                                break;
                            case "b":
                                Console.Write("Enter author to search: ");
                                string searchAuthor = Console.ReadLine();
                                var byAuthor = collection.SearchSongs(s => s.Author.Contains(searchAuthor, StringComparison.OrdinalIgnoreCase));
                                DisplaySearchResults(byAuthor);
                                break;
                            case "c":
                                Console.Write("Enter composer to search: ");
                                string searchComposer = Console.ReadLine();
                                var byComposer = collection.SearchSongs(s => s.Composer.Contains(searchComposer, StringComparison.OrdinalIgnoreCase));
                                DisplaySearchResults(byComposer);
                                break;
                            case "d":
                                Console.Write("Enter year to search: ");
                                if (int.TryParse(Console.ReadLine(), out int searchYear))
                                {
                                    var byYear = collection.SearchSongs(s => s.Year == searchYear);
                                    DisplaySearchResults(byYear);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid year format.");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid search option.");
                                break;
                        }
                        break;
                    case "5":
                        Console.Write("Enter the file path to save the collection: ");
                        string savePath = Console.ReadLine();
                        collection.SaveToFile(savePath);
                        break;
                    case "6":
                        Console.Write("Enter the file path to load the collection from: ");
                        string loadPath = Console.ReadLine();
                        collection.LoadFromFile(loadPath);
                        break;
                    case "7":
                        Console.Write("Enter the name of the performer: ");
                        string performerName = Console.ReadLine();
                        var byPerformer = collection.GetSongsByPerformer(performerName);
                        DisplaySearchResults(byPerformer);
                        break;
                    case "8":
                        collection.DisplayAllSongs();
                        break;
                    case "9":
                        Console.WriteLine("Exiting application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static Song GetSongDetailsFromUser()
        {
            Song song = new Song();
            Console.Write("Enter song title: ");
            song.Title = Console.ReadLine();
            Console.Write("Enter author's full name: ");
            song.Author = Console.ReadLine();
            Console.Write("Enter composer: ");
            song.Composer = Console.ReadLine();
            Console.Write("Enter year of writing: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                song.Year = year;
            }
            else
            {
                Console.WriteLine("Invalid year format. Setting year to 0.");
                song.Year = 0;
            }
            Console.WriteLine("Enter lyrics (type 'END' on a new line to finish):");
            string line;
            string lyrics = "";
            while ((line = Console.ReadLine()) != "END")
            {
                lyrics += line + Environment.NewLine;
            }
            song.Lyrics = lyrics.TrimEnd(Environment.NewLine.ToCharArray());

            Console.WriteLine("Enter performers (comma-separated):");
            string performersInput = Console.ReadLine();
            song.Performers = performersInput.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).ToList();

            return song;
        }

        static void DisplaySearchResults(List<Song> results)
        {
            if (results.Count > 0)
            {
                Console.WriteLine("\n--- Search Results ---");
                foreach (var song in results)
                {
                    Console.WriteLine(song);
                }
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("No songs found matching your criteria.");
            }
        }
    }
}
