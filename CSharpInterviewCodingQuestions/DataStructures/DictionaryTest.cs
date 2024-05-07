using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed
namespace DataStructures;

public static class DictionaryTest
{
    private static readonly Random Random = new();

    public static void Start() // Time/Memory Complexity ?  
    {
        const int n = 100;
        var dictionary = new Dictionary<string, int>();
        for (var i = 0; i < n; i++) // Time complexity ?
        {
            var randomKey = GenerateRandomStringWithStringBuilder();
            dictionary.Add(randomKey, i); // Time complexity ?
            dictionary.ContainsKey(randomKey); // Time Complexity ?
            dictionary.Remove(randomKey); // Time Complexity ?
        }
            
    }

    private static string GenerateRandomStringWithStringBuilder(int stringSize = 10) // Time/Memory complexity ? 
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < stringSize; i++)
        {
            stringBuilder.Append(GetRandomChar());
        }

        return stringBuilder.ToString();
    }

    private static string GenerateRandomString(int stringSize = 10) // Time/Memory complexity ? 
    {
        var result = string.Empty;
        for (var i = 0; i < stringSize; i++) // Time Complexity
        {
            result += GetRandomChar();
        }

        return result;
    }

    private static char GetRandomChar() => (char) Random.Next(char.MinValue, char.MaxValue);
}