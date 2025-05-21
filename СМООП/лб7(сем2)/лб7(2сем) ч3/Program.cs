using System;

namespace лб7_2сем__ч3
{
    class Program
    {
        static void Main(string[] args)
        {
            ICipher aCipher = new ACipher();
            ICipher bCipher = new BCipher();

            string textToEncode = "Hello World!";
            string aEncoded = aCipher.Encode(textToEncode);
            string aDecoded = aCipher.Decode(aEncoded);

            Console.WriteLine($"A Cipher:");
            Console.WriteLine($"Original: {textToEncode}");
            Console.WriteLine($"Encoded: {aEncoded}");
            Console.WriteLine($"Decoded: {aDecoded}");

            string bEncoded = bCipher.Encode(textToEncode);
            string bDecoded = bCipher.Decode(bEncoded);
            Console.WriteLine($"\nB Cipher:");
            Console.WriteLine($"Original: {textToEncode}");
            Console.WriteLine($"Encoded: {bEncoded}");
            Console.WriteLine($"Decoded: {bDecoded}");
        }
    }

}