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
                1 => ASCI_FRONT_COLOR_ORANGE + ASCI_BACK_COLOR_ORANGE + guess[i] + ASCI_RESET,
                2 => ASCI_FRONT_COLOR_GREEN + ASCI_BACK_COLOR_GREEN + guess[i] + ASCI_RESET,
                _ => guess[i]
            });
        }

        return sb.ToString();
    }

    // All the ANSI color codes used

    internal const string ASCI_FRONT_COLOR_ORANGE = "\u001b[38;5;230m";
    internal const string ASCI_BACK_COLOR_ORANGE = "\u001b[48;5;208m";

    internal const string ASCI_FRONT_COLOR_GREEN = "\u001b[38;5;157m";
    internal const string ASCI_BACK_COLOR_GREEN = "\u001b[48;5;28m";

    internal const string ASCI_RESET = "\u001b[0m";
}
