using System.Text;
using System.Globalization;
using System.Numerics;

public static class PublicKey
{
    public static string RsaEncryptMessage(string message)
    {
        int prime1 = 1487;
        int prime2 = 1087;

        int modulus = prime1 * prime2;
        int phi = (prime1-1) * (prime2-1);
        int e = 65537;
        int d = GetInverseMod(modulus, phi);

        return GetCipher(message, e, d, modulus);
    }

    public static string RsaDecryptMessage(string base64Cipher)
    {
        byte[] bytes = Convert.FromBase64String(base64Cipher);
        string cipher = Encoding.UTF8.GetString(bytes);

        return "";
    }

    private static string GetCipher(string message, int e, int d, int modulus)
    {
        char[] plainChars = message.ToCharArray();
        StringBuilder encryptedChars = new();

        foreach(char character in plainChars)
        {
            int value = Convert.ToInt32(character);
            int encryptedValue = (value^e) % modulus;
            string encryptedChar = encryptedValue.ToString(); 
            encryptedChars.Append(encryptedChar);
        }

        return encryptedChars.ToString();
    }

    private static int GetInverseMod(int modulus, int phi)
    {      
        for (int index = 1; index < int.MaxValue; index++)
        {
            int numberToTry = index * modulus;
            
            if (numberToTry % phi == 1)
            {
                return index;
            }
        }
        
        return 0;
    }
}