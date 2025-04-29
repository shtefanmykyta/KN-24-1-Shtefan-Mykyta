namespace лб6_2сем__2ч
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MusicalInstrument[] instruments = new MusicalInstrument[]
                {
                new Bandura(1920),
                new Sopilka(1950),
                new StringInstrument("Violin", 1700, 4),
                new StringInstrument("Guitar", 1800, 6),
                new Bandura(1890),
                new Sopilka(2000)
                };

                int stringInstrumentCount = 0;
                StringInstrument oldestStringInstrument = null;

                foreach (var instrument in instruments)
                {
                    Console.WriteLine(instrument.GetDescription());

                    if (instrument is StringInstrument)
                    {
                        stringInstrumentCount++;

                        if (oldestStringInstrument == null || instrument.Year < oldestStringInstrument.Year)
                        {
                            oldestStringInstrument = (StringInstrument)instrument;
                        }
                    }
                }

                Console.WriteLine($"Total number of string instruments: {stringInstrumentCount}");
                if (oldestStringInstrument != null)
                {
                    Console.WriteLine($"The oldest string instrument is: {oldestStringInstrument.GetDescription()}");
                }
                else
                {
                    Console.WriteLine("No string instruments found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}
