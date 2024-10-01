using CaesarCypherLab;
using System.Collections.Generic;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Error: Incorrect number of parameters. Please provide three parameters: training file location and name, scrambled file location and name, and output file location and name.");
            return;
        }

        string trainingFile = args[0];
        string scrambledFile = args[1];
        string outputFile = args[2];

        Console.WriteLine($"Reading input file \"{trainingFile}\".");
        string trainingText = FileReader.ReadFile(trainingFile);
        int trainingLines = trainingText.Split('\n').Length;
        int trainingChars = trainingText.Length;
        Console.WriteLine($"Length of input file is {trainingLines} lines, and {trainingChars} characters.");

        Dictionary<char, int> trainingLetterFrequency = FileReader.GetLetterFrequency(trainingFile);
        var mostFrequentTrainingLetter = trainingLetterFrequency.OrderByDescending(x => x.Value).First();
        var secondMostFrequentTrainingLetter = trainingLetterFrequency.OrderByDescending(x => x.Value).Skip(1).First();
        Console.WriteLine($"The two most occurring characters are {mostFrequentTrainingLetter.Key} and {secondMostFrequentTrainingLetter.Key}, occurring {mostFrequentTrainingLetter.Value} times and {secondMostFrequentTrainingLetter.Value} times.");

        Console.WriteLine($"Reading the encrypted file \"{scrambledFile}\".");
        Dictionary<char, int> scrambledLetterFrequency = FileReader.GetLetterFrequency(scrambledFile);
        var mostFrequentScrambledLetter = scrambledLetterFrequency.OrderByDescending(x => x.Value).First();
        Console.WriteLine($"The most occurring character is {mostFrequentScrambledLetter.Key}, occurring {mostFrequentScrambledLetter.Value} times.");

        int shift = (int)mostFrequentScrambledLetter.Key - (int)mostFrequentTrainingLetter.Key;
        if (shift < 0) shift += 26;
        Console.WriteLine($"A shift factor of {shift} has been determined.");

        string scrambledText = FileReader.ReadFile(scrambledFile);
        string decodedText = CaesarCypherDecoder.Decode(scrambledText, shift);
        FileReader.WriteFile(outputFile, decodedText);

        Console.WriteLine($"Writing output file now to \"{outputFile}\".");
        Console.Write("Display the file? (y/n): ");
        string response = Console.ReadLine();
        if (response.ToLower() == "y")
        {
            Console.WriteLine(decodedText);
        }

        else
        {
            Environment.Exit(-1);
        }
    }
}