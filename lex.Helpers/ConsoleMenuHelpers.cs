namespace lex.Helpers;

public static class ConsoleMenuHelpers
{

    public const string PRESS_ANY_TO_RETURN = "Press any key to go back to the main menu.";
    /// <summary>
    /// Displays a menu to the console using the Console.Write function
    /// </summary>
    /// <typeparam name="T">Notnull value, will display the key using the ToString extension method</typeparam>
    /// <param name="options">Menu options to display as, [KEY]: [VALUE]</param>
    public static void DisplayMenu<T>(Dictionary<T, string> options) 
        where T : notnull
    {
        string menu = "";

        foreach(var kvp in options)
            menu += $"{kvp.Key}: {kvp.Value}{Environment.NewLine}";

        Console.Write(menu);
    }

}
