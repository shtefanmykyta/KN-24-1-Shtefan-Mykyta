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