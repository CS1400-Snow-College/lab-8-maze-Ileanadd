// Lab 8: Maze
// Ileana Gonzalez - 07/01

// This program reads a maze from a text file, displays it on the console, and lets the user move through the maze with the use of arrow keys while avoiding walls and trying to get to the exit.

using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        string[] mapRows = File.ReadAllLines("map.txt");
        Console.Clear();

        foreach (string row in mapRows)
        {
            Console.WriteLine(row);
        }

        Console.SetCursorPosition(0, 0);

        Stopwatch timer = new Stopwatch();
        timer.Start();

        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;

            int newTop = Console.CursorTop;
            int newLeft = Console.CursorLeft;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newTop--;
                    break;
                case ConsoleKey.DownArrow:
                    newTop++;
                    break;
                case ConsoleKey.LeftArrow:
                    newLeft--;
                    break;
                case ConsoleKey.RightArrow:
                    newLeft++;
                    break;
            }

            TryMove(newTop, newLeft, mapRows);

            if (mapRows[Console.CursorTop][Console.CursorLeft] == '*')
            {
                timer.Stop();
                break;
            }

        } while (key != ConsoleKey.Escape);

        TimeSpan time = timer.Elapsed;

        Console.Clear();
        Console.WriteLine("You escaped the maze!");
        Console.WriteLine($"Time Elapsed: {time.TotalSeconds:F2} seconds");
    }

    static void TryMove(int newTop, int newLeft, string[] mapRows)
    {
        if (newTop >= 0 && newTop < mapRows.Length && newLeft >= 0 && newLeft < mapRows[newTop].Length && mapRows[newTop][newLeft] != '#')
        {
            Console.SetCursorPosition(newLeft, newTop);
        }
    }
}