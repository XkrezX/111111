using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        // Read the content of the "Kobzar" file
        string filePath = "path_to_file/Kobzar.txt"; // Specify the path to the "Kobzar" file
        string text = File.ReadAllText(filePath);

        // Remove punctuation using regular expressions
        string cleanedText = Regex.Replace(text, @"[\p{P}-[.]]+", "");

        // Split the text into words
        string[] words = cleanedText.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Create a frequency table using Dictionary
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            // Filter words based on length (3 to 20 characters)
            if (word.Length >= 3 && word.Length <= 20)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }
        }

        // Get the top 50 most popular words
        var topWords = wordFrequency.OrderByDescending(pair => pair.Value).Take(50);

        // Display the top 50 words and their frequencies
        Console.WriteLine("Top 50 most popular words in 'Kobzar':");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("{0,-20} {1}", "Word", "Frequency");
        Console.WriteLine("--------------------------------------");

        foreach (var pair in topWords)
        {
            Console.WriteLine("{0,-20} {1}", pair.Key, pair.Value);
        }
    }
}
