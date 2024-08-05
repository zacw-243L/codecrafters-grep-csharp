using System;
using System.IO;
using System.Text.RegularExpressions;

static bool MatchPattern(string inputLine, string pattern)
{
    if (@"\d\w".Contains(pattern))
    {
        return Regex.IsMatch(inputLine, pattern);
    }
    else if (pattern[0] == '[' && pattern[^1] == ']')
    {
        for (int i = 1; i < pattern.Length - 1; i++)
            if (inputLine.Contains(pattern[i]))
                return true;
        return false;
    }
    else if (pattern.Length == 1)
    {
        return inputLine.Contains(pattern);
    }
    else
    {
        throw new ArgumentException($"Unhandled pattern: {pattern}");
    }
}

if (args.Length < 2 || args[0] != "-E")
{
    Console.WriteLine("Expected first argument to be '-E'");
    Environment.Exit(2);
}

string pattern = args[1];
string inputLine = Console.In.ReadToEnd();

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

if (MatchPattern(inputLine, pattern))
{
    Environment.Exit(0);
}
else
{
    Environment.Exit(1);
}
