namespace HackerRank.Problems;

public class CaesarCipher
{
    private const int AlphabetSize = 'z' - 'a' + 1;

    public string Encrypt(string s, int k) => new(s.Select(c => EncryptChar(k, c)).ToArray());

    private static char EncryptChar(int k, char c)
    {
        if (!char.IsLetter(c)) return c;

        k = k % AlphabetSize;
        char startLetter = c is >= 'A' and <= 'Z' ? 'A' : 'a';
        char offset = (char)((c - startLetter + k) % AlphabetSize);
        return (char) (startLetter + offset);
    }
}