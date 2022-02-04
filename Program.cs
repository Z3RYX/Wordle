using Wordle;

string word = "pitch";

Console.WriteLine();
Console.Write(" → ");
string? guess = Console.ReadLine();
byte[] result;

for (int i = 0; i < 6; i++)
{
#pragma warning disable CS8604 // Possible null reference argument.
    check:
    try
    {
        result = Checker.CharCheck(guess, word);
    }
    catch (ArgumentException)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine("                              ");
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(" → ");
        guess = Console.ReadLine();
        goto check;
    }
#pragma warning restore CS8604 // Possible null reference argument.

    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.WriteLine(Builder.DisplayStringBuilder(guess, result, i, 6));

    if (Checker.WinCheck(result)) return;
    else if (i == 5) continue;

    Console.Write(" → ");
    guess = Console.ReadLine();
}

Console.WriteLine("   You lost!");
Console.WriteLine($"   The word was: {word}");