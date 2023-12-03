using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.AoC2;

public class AoC02
{
    public static void Part1()
    {
        var lines = File.ReadAllLines("AoC2/input.txt");
        var numbers = new List<int>();

        foreach (var line in lines)
        {
            Regex regex = new Regex("Game (\\d+):");
            var matches = regex.Match(line);

            var gameId = int.Parse(matches.Groups[1].Value);

            Regex regex1 = new Regex("((\\d+) [b|r|g])");
            var matches1 = regex1.Matches(line);

            var validGame = true;
            foreach (Match match in matches1)
            {
                var color = match.Groups[1].Value;
                var number = int.Parse(match.Groups[2].Value);

                if (
                    (color.Contains("r") && number > 12) ||
                    (color.Contains("g") && number > 13) ||
                    (color.Contains("b") && number > 14)
                )
                {
                    validGame = false;
                    continue;
                }
            }
            if (validGame)
            {
                numbers.Add(gameId);
            }
        }

        numbers.ForEach(i => Console.WriteLine(i.ToString()));

        Console.WriteLine($"Sum of all number: {numbers.Sum(i => i)}");
    }

    public static void Part2()
    {
        var lines = File.ReadAllLines("AoC2/input.txt");
        var numbers = new List<int>();

        foreach (var line in lines)
        {
            Regex regex1 = new Regex("((\\d+) [b|r|g])");
            var matches1 = regex1.Matches(line);

            var red = 0;
            var green = 0;
            var blue = 0;

            foreach (Match match in matches1)
            {
                var color = match.Groups[1].Value;
                var number = int.Parse(match.Groups[2].Value);

                if (color.Contains("r"))
                {
                    if(number > red) { red = number; }
                }
                if (color.Contains("g"))
                {
                    if (number > green) { green = number; }
                }
                if (color.Contains("b"))
                {
                    if (number > blue) { blue = number; }
                }
            }
            
            numbers.Add(red*green*blue);
        }

        numbers.ForEach(i => Console.WriteLine(i.ToString()));

        Console.WriteLine($"Sum of all number: {numbers.Sum(i => i)}");
    }
}
