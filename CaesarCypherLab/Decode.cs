using System;
using System.Collections.Generic;
using System.Linq;

public class CaesarCypherDecoder
{
    public static char GetMostFrequentLetter(Dictionary<char, int> letterFrequency)
    {
        return letterFrequency.OrderByDescending(x => x.Value).First().Key;
    }

    public static string Decode(string scrambledText, int shift)
    {
        string decodedText = "";
        foreach (char c in scrambledText)
        {
            if (char.IsLetter(c))
            {
                int asciiOffset = char.IsUpper(c) ? (int)'A' : (int)'a';
                int decodedChar = (c - asciiOffset - shift + 26) % 26 + asciiOffset;
                decodedText += (char)decodedChar;
            }
            else
            {
                decodedText += c;
            }
        }
        return decodedText;
    }
}