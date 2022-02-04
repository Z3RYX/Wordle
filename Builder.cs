using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle;

internal static class Builder
{
    internal static string ResultStringBuilder(string guess, byte[] guessResult)
    {
        StringBuilder sb = new();

        for (int i = 0; i < guess.Length; i++)
        {
            sb.Append(guessResult[i] switch
            {
                1 => ANSI_FRONT_COLOR_ORANGE + ANSI_BACK_COLOR_ORANGE + guess[i] + ANSI_RESET,
                2 => ANSI_FRONT_COLOR_GREEN + ANSI_BACK_COLOR_GREEN + guess[i] + ANSI_RESET,
                _ => guess[i]
            });
        }

        return sb.ToString();
    }

    internal static string DisplayStringBuilder(string guess, byte[] result, int round, int total)
    {
        return $"   {ResultStringBuilder(guess, result)} │ {round}/{total}{(Checker.WinCheck(result) ? " " + YOU_WIN : "")}";
    }

    // All the ANSI codes used

    internal const string YOU_WIN = "\u001b[1m" + "\u001b[4m" + "YOU WIN" + ANSI_RESET;

    internal const string ANSI_FRONT_COLOR_ORANGE = "\u001b[38;5;230m";
    internal const string ANSI_BACK_COLOR_ORANGE = "\u001b[48;5;208m";

    internal const string ANSI_FRONT_COLOR_GREEN = "\u001b[38;5;157m";
    internal const string ANSI_BACK_COLOR_GREEN = "\u001b[48;5;28m";

    internal const string ANSI_RESET = "\u001b[0m";
}
