using System;
using System.Collections.Generic;

namespace ConsoleApp.AoC3;

public class AoC03
{
    public static void Part1()
    {
        // Specify the path to the text file containing the engine schematic
        string filePath = "AoC3/input.txt";

        // Read the engine schematic from the text file
        char[,] engineSchematic = ReadEngineSchematicFromFile(filePath);

        // Display the engine schematic
        //DisplayEngineSchematic(engineSchematic);

        // Calculate the sum of all unique part numbers
        int sum = CalculatePartNumberSum(engineSchematic);

        // Display the result
        Console.WriteLine("The sum of all unique part numbers is: " + sum);
    }

    static char[,] ReadEngineSchematicFromFile(string filePath)
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Determine the dimensions of the engine schematic
            int rows = lines.Length;
            int cols = lines[0].Length;

            // Initialize the engine schematic array
            char[,] engineSchematic = new char[rows, cols];

            // Fill the array with characters from the file
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    engineSchematic[i, j] = lines[i][j];
                }
            }

            return engineSchematic;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
            return null;
        }
    }

    static void DisplayEngineSchematic(char[,] engineSchematic)
    {
        // Display the engine schematic
        for (int i = 0; i < engineSchematic.GetLength(0); i++)
        {
            for (int j = 0; j < engineSchematic.GetLength(1); j++)
            {
                Console.Write(engineSchematic[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int CalculatePartNumberSum(char[,] engineSchematic)
    {
        // Initialize a set to store unique part numbers
        HashSet<string> uniquePartNumbers = new HashSet<string>();

        // Iterate through each cell in the engine schematic
        for (int row = 0; row < engineSchematic.GetLength(0); row++)
        {
            var numberString = "";
            var adjecent = false;
            for (int col = 0; col < engineSchematic.GetLength(1); col++)
            {
                if (char.IsDigit(engineSchematic[row, col]))
                {
                    numberString += engineSchematic[row, col];
                    if (!adjecent)
                    {
                        adjecent = HasAdjacentSymbol(engineSchematic, row, col);
                    }
                }
                else
                {
                    //Calculate number
                    if(adjecent && !string.IsNullOrEmpty(numberString))
                    {
                        uniquePartNumbers.Add(numberString);
                    }
                    numberString = "";
                    adjecent = false;
                }
            }
        }

        // Calculate the sum of unique part numbers
        int sum = 0;
        foreach (string number in uniquePartNumbers)
        {
            sum += int.Parse(number);
        }

        return sum;
    }

    static bool HasAdjacentSymbol(char[,] engineSchematic, int row, int col)
    {
        var adjecentSymbol = false;

        int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

        // Iterate through adjacent cells
        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dr[i];
            int newCol = col + dc[i];

            // Check if the adjacent cell is within the bounds of the array
            if (newRow >= 0 && newRow < engineSchematic.GetLength(0) && newCol >= 0 && newCol < engineSchematic.GetLength(1))
            {
                var newChar = engineSchematic[newRow, newCol];
                // Check if the adjacent cell contains a number
                if (!char.IsDigit(newChar) && newChar != '.')
                {
                    return true;
                }
            }
        }
        return adjecentSymbol;
    }
}