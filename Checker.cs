using System.Text.RegularExpressions;

namespace Wordle;

internal static class Checker
{
    internal static byte[] CharCheck(string guess, string word)
    {
        // Check if input words are of equal length and are not null
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (guess == null) throw new ArgumentNullException(nameof(guess));
        if (word.Length != guess.Length) throw new ArgumentException("Guess has to be of same length as the word");

        // Checks if guess is made up of only valid characters (a-z)
        if (!RegexCheck(guess, "^[a-z]+$")) throw new ArgumentException("Guess has invalid characters");

        byte[] result = new byte[word.Length];
        char[] wordArray = word.ToCharArray();
        char[] guessArray = guess.ToCharArray();

        // Checks if the correct characters are in the correct space and puts a 2
        for (int i = 0; i < wordArray.Length; i++)
        {
            if (wordArray[i] == guessArray[i])
            {
                result[i] = 2;
                wordArray[i] = (char)0;
            }
        }

        // Checks if correct characters exist but aren't in their correct position and puts a 1
        for (int i = 0; i < wordArray.Length; i++) if (wordArray.Contains(guessArray[i]) && result[i] != 2) result[i] = 1;

        return result;
    }

    internal static bool WinCheck(byte[] guess)
    {
        for (int i = 0; i < guess.Length; i++) if (guess[i] != 2) return false;
        return true;
    }

    internal static bool RegexCheck(string input, string regex) => new Regex(regex).Match(input).Success;
}
