using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp.AoC4;

public class AoC04
{
    public static void Part1()
    {
        string filePath = "AoC4/input.txt";

        var lines = File.ReadAllLines(filePath);
        var sum = 0;
        foreach (var line in lines)
        {
            var points = GetMatches(line);
            Console.WriteLine(points);
            sum += points;
        }
        Console.WriteLine(sum);
    }


    private static int GetMatches(string line)
    {
        var split = line.Split
            (':')[1].Split('|');


        var winningNumbers = GetNumbers(split[0]);
        var mynumber = GetNumbers(split[1]);

        var remainingNumbers = winningNumbers.Except(mynumber).Count();
        var matches = winningNumbers.Count - remainingNumbers;

        return (int)Math.Pow(2, (matches - 1));
    }

    private static List<int> GetNumbers(string line)
    {
        var list = new List<int>();
        var regex = new Regex("(\\d+)");
        var matches = regex.Matches(line);
        foreach( Match match in matches)
        {
            list.Add(int.Parse(match.Groups[1].Value));
        }
        return list;
    }
}