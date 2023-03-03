using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.EncryptDecrypt;

public class BlockCipherEncryptor
{
    public static void EncryptUsingAes(string plainText, string passPhrase)
    {
        using Aes aes = Aes.Create();
        byte[] key = KDF(Encoding.UTF8.GetBytes(passPhrase));
        byte[] iv = aes.IV;

        Console.WriteLine($"IV is {Encoding.UTF8.GetString(iv)}");
        aes.BlockSize = 256;
        ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

        MemoryStream inputStream = new();
        StreamWriter writer = new(inputStream);
        writer.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText)));
        writer.Flush();
        inputStream.Position = 0;

        using CryptoStream outputStream = new(inputStream, encryptor, CryptoStreamMode.Read);
        StreamReader outputReader = new(outputStream);
        Console.WriteLine($"Cipher text : {outputReader.ReadToEnd()}");
    }

    private static byte[] Pad(byte[] bytes, int size = 128)
    {
        int byteSize = size / 8;
        int missingBytes = byteSize - bytes.Length;
        Stack<byte> newBytes = new(bytes);

        for (int index = 0; index < missingBytes; index++)
        {
            newBytes.Push(BitConverter.GetBytes(missingBytes)[0]);
        }

        return newBytes.ToArray();
    }

    private static byte[] KDF(byte[] bytes, int size = 128)
    {
        int byteSize = size / 8;
        int missingBytes = byteSize - bytes.Length;
        Stack<byte> newBytes = new(bytes);

        for (int index = 0; index < missingBytes; index++)
        {
            newBytes.Push(BitConverter.GetBytes(missingBytes)[0]);
        }

        return newBytes.ToArray();
    }
}