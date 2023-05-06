// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

Console.WriteLine("Yo yo, wellcome to string Encrypting App.");

Console.WriteLine("Type your string data:");

var cryptoData = Encrypting(Console.ReadLine());

Console.WriteLine(cryptoData);

Console.ReadKey();


static string Encrypting(string plainText)
{
    byte[] encryptedLog;

    // Create a new AesManaged.
    using (AesManaged aes = new())
    {
        byte[] IV = new byte[16];
        byte[] Key = {
                    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                };

        var mode = aes.Mode;//aes.Mode = CipherMode.CBC;
        ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);// Create encryptor    
                                                                  // Create MemoryStream    
        using (MemoryStream ms = new MemoryStream())
        {
            // Create crypto stream using the CryptoStream class. This class is the key to encryption    
            // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
            // to encrypt    
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                // Create StreamWriter and write data to a stream    
                using (StreamWriter sw = new StreamWriter(cs))
                    sw.Write(plainText);
                encryptedLog = ms.ToArray();
            }
        }
    }

    string cipherText = Convert.ToBase64String(encryptedLog, 0, encryptedLog.Length);
    return cipherText;
}