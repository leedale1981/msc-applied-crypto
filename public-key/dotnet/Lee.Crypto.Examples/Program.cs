using System.Text;

string plainText = "This is my private message";
string cipherText = PublicKey.RsaEncryptMessage(plainText);
string base64Cipher = Convert.ToBase64String(Encoding.UTF8.GetBytes(cipherText));
Console.WriteLine($"Plain: {plainText}");
Console.WriteLine($"Cipher: {cipherText}");
Console.WriteLine($"Base64 Cipher: {base64Cipher}");

