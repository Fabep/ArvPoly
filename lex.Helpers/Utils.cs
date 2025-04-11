namespace lex.Helpers;

public static class Utils
{
    /// <summary>
    /// Prompts the user for a string with the Console.ReadLine function
    /// </summary>
    /// <param name="prompt">Prompt to write out to the console</param>
    /// <param name="optionalValidation"> Custom validation (optional)</param>
    /// <param name="errorMessage">Error message to display if custom validation fails (optional)</param>
    /// <returns>User input as a string</returns>
    public static string PromptForString(string prompt, Func<string, bool>? optionalValidation = null, string errorMessage = "") 
    {
        do
        {
            Console.Write($"{prompt}: ");
            string? input = Console.ReadLine();
            if (input is null)
                Console.WriteLine($"Invalid input. {prompt} is null.");
            else if (optionalValidation is not null && !optionalValidation(input))
                Console.WriteLine($"Invalid input. {errorMessage}.");
            else
                return input;
        }
        while (true);
    }

    /// <summary>
    /// Prompts the user for an integer with the Console.ReadLine function
    /// </summary>
    /// <param name="prompt">Prompt to write out to the console</param>
    /// <param name="optionalValidation">Custom validation (optional)</param>
    /// <param name="errorMessage">Error message to display if custom validation fails (optional)</param>
    /// <returns>User input as an integer</returns>
    public static int PromptForInt(string prompt, Func<int, bool>? optionalValidation = null, string errorMessage = "")
    {
        do
        {
            string input = PromptForString(prompt);

            if (int.TryParse(input, out int value))
            {
                if (optionalValidation is not null && optionalValidation(value))
                    return value;

                Console.WriteLine($"Invalid input. {errorMessage}");
            }
            else
                Console.WriteLine($"Invalid input. Input was not an integer.");
        }
        while (true);
    }
    public static double PromptForDouble(string prompt, Func<double, bool>? optionalValidation = null, string errorMessage = "")
    {
        do
        {
            string input = PromptForString(prompt);

            if (double.TryParse(input, out double value))
            {
                if (optionalValidation is not null && optionalValidation(value))
                    return value;

                Console.WriteLine($"Invalid input. {errorMessage}");
            }
            else
                Console.WriteLine($"Invalid input. Input was not a double.");
        }
        while (true);
    }
}
