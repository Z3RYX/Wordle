using Wordle;

string word = "pitch";
const string tab = "   ";

Console.WriteLine();
Console.Write(tab + "→ ");
string? guess = Console.ReadLine();

for (int i = 0; i < 6; i++)
{
#pragma warning disable CS8604 // Possible null reference argument.
    var result = Checker.CharCheck(guess, word);
#pragma warning restore CS8604 // Possible null reference argument.

    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.WriteLine(Builder.DisplayStringBuilder(guess, result, i, 6));

    if (Checker.WinCheck(result)) return;
    else if (i == 5) continue;

    Console.Write(tab + "→ ");
    guess = Console.ReadLine();
}

Console.WriteLine(tab + "You lost!");
Console.WriteLine(tab + $"The word was: {word}");