using Wordle;

string word = "pitch";
const string tab = "   ";

Console.WriteLine();
Console.WriteLine(tab + "Please enter your first guess (5 characters):");
Console.Write(tab + "→ ");
string? guess = Console.ReadLine();

for (int i = 0; i < 6; i++)
{
#pragma warning disable CS8604 // Possible null reference argument.
    var result = Checker.CharCheck(guess, word);
#pragma warning restore CS8604 // Possible null reference argument.

    var display = Builder.ResultStringBuilder(guess, result);

    Console.SetCursorPosition(0, Console.CursorTop - 1);

    if (Checker.WinCheck(result))
    {
        Console.WriteLine(tab + display + $" │ {i + 1}/6 YOU WIN");
        return;
    } else
    {
        Console.WriteLine(tab + display + $" │ {i + 1}/6");

        if (i == 5) continue;
    }

    Console.Write(tab + "→ ");
    guess = Console.ReadLine();
}

Console.WriteLine(tab + "You lost!");
Console.WriteLine(tab + $"The word was: {word}");