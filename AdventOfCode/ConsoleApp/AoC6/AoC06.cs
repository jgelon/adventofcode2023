using System.Text.RegularExpressions;

namespace ConsoleApp.AoC6;

public class AoC06
{

    public static void Part1()
    {
        string filePath = "AoC6/input.txt";

        var lines = File.ReadAllLines(filePath);

        var times = new List<int>();
        var distances = new List<int>();

        times = GetNumbers(lines[0]);
        distances = GetNumbers(lines[1]);

        var wins = new List<int>();
        for(int i = 0; i < times.Count; i++) {
            var w = TryOptions(times[i], distances[i]);
            Console.WriteLine($"Game {i} has {w} wins");
            wins.Add(w);
        }


        Console.WriteLine(wins.Aggregate((a, x) => a * x));
    }

    public static void Part2()
    {
        string filePath = "AoC6/input.txt";

        var lines = File.ReadAllLines(filePath);

        var times = new List<int>();
        var distances = new List<int>();

        times = GetNumbers(lines[0]);
        distances = GetNumbers(lines[1]);

        var time = int.Parse(string.Join("", times));
        var distance = Int128.Parse(string.Join("", distances));

        var fw = FirstWin(time, distance);
        Console.WriteLine($"First win: {fw}");
        var lw = LastWin(time, distance);
        Console.WriteLine($"Last win: {fw}");

        Console.WriteLine(lw-fw+1);
    }


    private static int TryOptions(int time, Int128 distance)
    {
        int wins = 0;
        for (int i = 0; i < time; i++)
        {
            if (CheckForWin(time, i, distance)) { wins++; }
        }
        return wins;
    }

    private static int FirstWin(int time, Int128 distance)
    {
        for (int i = 0; i < time; i++)
        {
            if (CheckForWin(time, i, distance)) { return i; }
        }
        return time;
    }

    private static int LastWin(int time, Int128 distance)
    {
        for (int i = time; i > 0; i--)
        {
            if (CheckForWin(time, i, distance)) { return i; }
        }
        return 0;
    }

    private static bool CheckForWin(int time, int holdTime, Int128 distance)
    {
        int speed = 0;
        for (int i = 0; i < holdTime; i++)
        {
            speed += 1;
        }
        int distanceTravelled = 0;
        for (int j = 0; j < (time - holdTime); j++)
        {
            distanceTravelled += speed;
        }

        var win = distanceTravelled > distance;
        //Console.WriteLine($"Hold {holdTime} of {time}, travelled {distanceTravelled} = {(win ? "WIN" : "LOSS")}");
        return win;
    }

    private static List<int> GetNumbers(string line)
    {
        var list = new List<int>();
        var regex = new Regex("(\\d+)");
        var matches = regex.Matches(line);
        foreach (Match match in matches)
        {
            list.Add(int.Parse(match.Groups[1].Value));
        }
        return list;
    }
}