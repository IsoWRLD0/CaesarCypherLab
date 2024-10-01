using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CaesarCypherLab
{
    public class FileReader
    {
        public static Dictionary<char, int> GetLetterFrequency(string filePath)
        {
            Dictionary<char, int> letterFrequency = new Dictionary<char, int>();
            string fileContent = File.ReadAllText(filePath);
            foreach (char c in fileContent.ToLower())
            {
                if (char.IsLetter(c))
                {
                    if (letterFrequency.ContainsKey(c))
                    {
                        letterFrequency[c]++;
                    }
                    else
                    {
                        letterFrequency[c] = 1;
                    }
                }
            }
            return letterFrequency;
        }

        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static void WriteFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
