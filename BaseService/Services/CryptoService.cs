using System.Security.Cryptography;

namespace BaseService.Services;

public class CryptoService : ICryptoService
{
    public Tuple<string, string, string> Encrypt(string value)
    {
        using var aesInstance = Aes.Create();
        var encrypted = EncryptStringToBytes(value, aesInstance.Key, aesInstance.IV);
        return new Tuple<string, string, string>(GetString(encrypted), GetString(aesInstance.Key),
            GetString(aesInstance.IV));
    }
    
    public string EncryptLogData(string value,string key , string iv)
    {
        byte[] Key = GetBytes(key);
        byte[] Iv = GetBytes(iv);
        using var aesInstance = Aes.Create();
        var encrypted = EncryptStringToBytes(value, Key, Iv);
        return GetString(encrypted);
    }

    public string Decrypt(string value, string key, string iv)
    {
        var encryptedBytes = GetBytes(value);
        var keyBytes = GetBytes(key);
        var ivBytes = GetBytes(iv);
        return DecryptStringFromBytes(encryptedBytes, keyBytes, ivBytes);
    }

    static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        // Checking Validity
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] encrypted;

        // Create an Aes object with the specified key and IV.
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");


        string plaintext = null;

        // Create an Aes object with the specified key and IV.
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }

    private string GetString(byte[] byteArray)
    {
        return Convert.ToBase64String(byteArray, 0, byteArray.Length);
    }

    private byte[] GetBytes(string stringValue)
    {
        return Convert.FromBase64String(stringValue);
    }
}