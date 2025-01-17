using System.Diagnostics;
using System.Reflection;

namespace Durangling;

public static class Logger
{
    public enum Level
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public static void Write(Level level, string message)
    {
        Console.BackgroundColor = level switch
        {
            Level.Debug => ConsoleColor.DarkYellow,
            Level.Info => ConsoleColor.Blue,
            Level.Warning => ConsoleColor.Yellow,
            Level.Error => ConsoleColor.Red,
            Level.Fatal => ConsoleColor.DarkRed,
            _ => ConsoleColor.Green
        };
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}