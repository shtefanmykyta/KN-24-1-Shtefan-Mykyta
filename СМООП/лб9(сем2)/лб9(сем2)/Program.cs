namespace лб9_сем2_
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    //Завдання 1
    public class FileStatistics
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the path to the file: ");
            string filePath = Console.ReadLine();

            try
            {
                string fileContent = File.ReadAllText(filePath);
                int sentenceCount = Regex.Matches(fileContent, @"[.!?]").Count;
                int uppercaseCount = fileContent.Count(char.IsUpper);
                int lowercaseCount = fileContent.Count(char.IsLower);
                int digitCount = fileContent.Count(char.IsDigit);

                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
                int vowelCount = fileContent.Count(c => vowels.Contains(c));

                int consonantCount = fileContent.Count(c => char.IsLetter(c) && !vowels.Contains(c));

                Console.WriteLine("\nFile Statistics:");
                Console.WriteLine($"Number of sentences: {sentenceCount}");
                Console.WriteLine($"Number of uppercase letters: {uppercaseCount}");
                Console.WriteLine($"Number of lowercase letters: {lowercaseCount}");
                Console.WriteLine($"Number of vowels: {vowelCount}");
                Console.WriteLine($"Number of consonants: {consonantCount}");
                Console.WriteLine($"Number of digits: {digitCount}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found at path '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    //Завдання 2
    public class CensorApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Censor Application");
            Console.Write("Enter the path to the text file: ");
            string textFilePath = Console.ReadLine();

            Console.Write("Enter the path to the file with words to censor: ");
            string censorWordsFilePath = Console.ReadLine();

            try
            {
                string text = File.ReadAllText(textFilePath);
                string[] censorWords = File.ReadAllLines(censorWordsFilePath);

                string censoredText = text;
                foreach (string word in censorWords)
                {
                    string replacement = new string('*', word.Length);
                    censoredText = System.Text.RegularExpressions.Regex.Replace(censoredText, Regex.Escape(word), replacement, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }

                Console.WriteLine("\nCensored Text:");
                Console.WriteLine(censoredText);

                // Optionally, you can save the censored text to a new file
                // Console.Write("\nEnter the path to save the censored text (or press Enter to skip): ");
                // string outputFilePath = Console.ReadLine();
                // if (!string.IsNullOrEmpty(outputFilePath))
                // {
                //     File.WriteAllText(outputFilePath, censoredText);
                //     Console.WriteLine($"Censored text saved to: {outputFilePath}");
                // }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: One or both of the specified files were not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
