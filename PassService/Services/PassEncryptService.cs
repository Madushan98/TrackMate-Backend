using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;

namespace PassService.Services;

public class PassEncryptService: IPassEncryptService
{

    public static byte[] keyBytes = {12, 32, 43, 12, 3, 2, 6, 4, 3, 21, 43, 123, 54, 250, 12, 43};

    public static byte[] ivBytes = {23, 43, 43, 56, 3, 67, 6, 4, 67, 21, 43, 56, 54, 34, 23, 12};

    public string EncryptPass(string value)
    {
        var encrypted = EncryptStringToBytes(value);
        return  GetString(encrypted);
    }

    public string DecryptPass(string value)
    {
        var encryptedBytes = GetBytes(value);
        return DecryptStringFromBytes(encryptedBytes);
    }

    static byte[] EncryptStringToBytes(string plainText)
    {
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        byte[] encrypted;
        
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            
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
        
        return encrypted;
    }

    static string DecryptStringFromBytes(byte[] cipherText)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");


        string plaintext = null;
        
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;
            
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            
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