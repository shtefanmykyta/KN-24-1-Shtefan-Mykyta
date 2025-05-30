using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace лб10_сем2_
{

    public class FlightRequest
    {
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public DateTime DesiredDepartureDate { get; set; }

        public FlightRequest(string destination, string flightNumber, string passengerName, DateTime desiredDepartureDate)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            PassengerName = passengerName;
            DesiredDepartureDate = desiredDepartureDate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<FlightRequest> requests = new List<FlightRequest>
            {
            new FlightRequest("Paris", "AF123", "Ivan Ivanov", new DateTime(2023, 12, 15)),
            new FlightRequest("London", "BA456", "Petr Petrov", new DateTime(2023, 12, 16)),
            new FlightRequest("New York", "UA789", "Svetlana Sidorova", new DateTime(2023, 12, 17)),
            };

            string serializedData = JsonSerializer.Serialize(requests, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine("Серіалізовані дані:");
            Console.WriteLine(serializedData);

            List<FlightRequest> deserializedRequests = JsonSerializer.Deserialize<List<FlightRequest>>(serializedData);
            Console.Write("Введіть номер рейсу для фільтрації: ");
            string flightNumberToSearch = Console.ReadLine();

            List<FlightRequest> filteredRequests = FilterRequestsByFlightNumber(deserializedRequests, flightNumberToSearch);

            if (filteredRequests.Count > 0)
            {
                Console.WriteLine($"\nЗаявки на рейс {flightNumberToSearch}:");
                foreach (var request in filteredRequests)
                {
                    Console.WriteLine($"Пасажир: {request.PassengerName}, Пункт призначення: {request.Destination}, Дата відльоту: {request.DesiredDepartureDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine($"Заявок на рейс {flightNumberToSearch} не знайдено.");
            }
        }

        static List<FlightRequest> FilterRequestsByFlightNumber(List<FlightRequest> requests, string flightNumber)
        {
            return requests.FindAll(request => request.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase));
        }
    }

}

ФІНАЛЬНЕ ЗАВДАННЯ

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

public class MusicDisk
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string TrackList { get; set; } 

    public MusicDisk() { }

    public MusicDisk(string title, string artist, int releaseYear, string genre, string trackList = "")
    {
        Title = title;
        Artist = artist;
        ReleaseYear = releaseYear;
        Genre = genre;
        TrackList = trackList;
    }

    public void AddTrack(string trackName)
    {
        if (!string.IsNullOrEmpty(TrackList))
        {
            TrackList += ";" + trackName;
        }
        else
        {
            TrackList = trackName;
        }
    }

    public void RemoveTrack(string trackName)
    {
        if (!string.IsNullOrEmpty(TrackList))
        {
            string[] tracks = TrackList.Split(';');
            string newTrackList = "";
            bool isFirst = true;
            foreach (string track in tracks)
            {
                if (track != trackName)
                {
                    if (!isFirst)
                    {
                        newTrackList += ";";
                    }
                    newTrackList += track;
                    isFirst = false;
                }
            }
            TrackList = newTrackList;
        }
    }

    public override string ToString()
    {
        return $"Title: {Title}\n" +
               $"Artist: {Artist}\n" +
               $"Release Year: {ReleaseYear}\n" +
               $"Genre: {Genre}\n" +
               $"Track List: {TrackList}";
    }

    public static MusicDisk LoadFromFile(string filePath)
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<MusicDisk>(jsonString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return null;
        }
        catch (JsonException)
        {
            Console.WriteLine($"Error: Failed to parse JSON from file '{filePath}'.");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading from file '{filePath}': {ex.Message}");
            return null;
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Music disk data successfully saved to file '{filePath}'.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error writing to file '{filePath}': {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving to file '{filePath}': {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:\\Users\\7401\\Desktop\\my_disk.json";
        MusicDisk myDisk = new MusicDisk(
            "Fav Hits",
            "Billie Eilish",
            2023,
            "Chill-out"
        );

        myDisk.AddTrack(" Birds of a feather");
        myDisk.AddTrack(" The Greatest");
        myDisk.AddTrack(" BLUE");

        Console.WriteLine("Disk Information:");
        Console.WriteLine(myDisk);

        string filePathSave = "my_disk.json";
        myDisk.SaveToFile(filePathSave);

        MusicDisk loadedDisk = MusicDisk.LoadFromFile(filePathSave);
        Console.ReadKey();
        if (loadedDisk != null)
        {
            Console.WriteLine("\nLoaded Disk Information:");
            Console.WriteLine(loadedDisk);

            
            if (loadedDisk is MusicDisk)
            {
                Console.WriteLine("\nLoaded object is an instance of the MusicDisk class.");
            }
            else
            {
                Console.WriteLine("\nLoaded object is not an instance of the MusicDisk class.");
            }
        }

        MusicDisk nonExistentDisk = MusicDisk.LoadFromFile("nonexistent.json");
        File.WriteAllText("faulty.json", "{'Title': 'Test', 'Artist': ' Performer'}");
        MusicDisk faultyDisk = MusicDisk.LoadFromFile("faulty.json");
    }
}
