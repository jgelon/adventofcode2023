// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Text.RegularExpressions;


public class AoC01
{

    public static void Part1()
    {
        var lines = File.ReadAllLines("AoC1/input.txt");
        var numbers = new List<int>();

        foreach (var line in lines)
        {
            Regex regex = new Regex("(\\d)\\w*(\\d)");
            var matches = regex.Match(line);

            if (matches.Groups.Count > 2)
            {
                numbers.Add(int.Parse($"{matches.Groups[1]}{matches.Groups[2]}"));
            }
            else
            {
                Regex regex2 = new Regex("(\\d)");
                var matches2 = regex2.Match(line);

                numbers.Add(int.Parse($"{matches2.Groups[1]}{matches2.Groups[1]}"));
            }
        }

        numbers.ForEach(i => Console.WriteLine(i.ToString()));

        Console.WriteLine($"Sum of all number: {numbers.Sum(i => i)}");
    }

    public static void Part2()
    {
        var lines = File.ReadAllLines("AoC1/input.txt");
        var numbers = new List<int>();

        foreach (var line in lines)
        {
            Regex regex = new Regex("(one|two|three|four|five|six|seven|eight|nine|\\d).*(one|two|three|four|five|six|seven|eight|nine|\\d)");
            var matches = regex.Match(line);

            var digit1 = NumberParser(matches.Groups[1].ToString());
            var digit2 = 0;
            if (matches.Groups.Count >= 3)
            {
                digit2 = NumberParser(matches.Groups[matches.Groups.Count - 1].ToString());
            }
            else if (matches.Groups.Count == 2)
            {
                digit2 = digit1;
            }
            else {

                Regex regex2 = new Regex("(\\d)");
                var matches2 = regex2.Match(line);

                digit1 = int.Parse(matches2.Groups[1].ToString());
                digit2 = digit1;
            }

            var number = int.Parse($"{digit1}{digit2}");
            if(number == 0)
            {
                Console.WriteLine("HUH");
            }
            numbers.Add(number);
        }

        numbers.ForEach(i => Console.WriteLine(i.ToString()));

        Console.WriteLine($"Sum of all number: {numbers.Sum(i => i)}");
    }

    private static int NumberParser(string s)
    {
        if (s.Length == 1) { return int.Parse(s); }

        return s switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => 0
        };
    }
}