// Lab 8: Maze
// Ileana Gonzalez - 07/01

// This program reads a maze from a text file, displays it on the console, and lets the user move through the maze with the use of arrow keys while avoiding walls and trying to get to the exit.

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
    }
}