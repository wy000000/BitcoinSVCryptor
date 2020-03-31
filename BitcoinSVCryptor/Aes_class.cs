using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBitcoin.DataEncoders;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BitcoinSVCryptor
{
    public class AES_class
    {
        public static byte[] AesEncrypt(Aes aes, string secretMessage)
        {
            using (aes)
            {                
                // Encrypt the message
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] messageBytes = Encoding.UTF8.GetBytes(secretMessage);
                        cs.Write(messageBytes, 0, messageBytes.Length);
                        cs.Close();
                        byte[] encryptedMessage = ms.ToArray();
                        return (encryptedMessage);
                    }
                }
            }
        }
        public static string AesDecrypt(Aes aes, byte[] encryptedMessage)
        {
            using (aes)
            {
                // Decrypt the message
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                        cs.Close();
                        string message = Encoding.UTF8.GetString(ms.ToArray());
                        return (message);
                    }
                }
            }
        }
        public static byte[] AesEncrypt(byte[] aesKey, string secretMessage, out byte[] iv)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = aesKey;
                iv = aes.IV;
                // Encrypt the message
                byte[] cipher = AesEncrypt(aes, secretMessage);
                return (cipher);
            }
        }
        public static string AesDecrypt(byte[] aesKey, byte[] encryptedMessage, byte[] iv)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = aesKey;
                aes.IV = iv;
                // Decrypt the message
                string plainText = AesDecrypt(aes, encryptedMessage);
                return (plainText);
            }
        }
        public static byte[] AesEncrypt(string plainText, string privateKeyStr)
        {
            using (Aes aes = GetAes(privateKeyStr))// Aes.Create())
            {
                byte[] cipher = AesEncrypt(aes, plainText);
                return (cipher);
            }
        }
        public static string AesDecrypt(byte[] cipherText, string privateKeyStr)
        {
            using (Aes aes = GetAes(privateKeyStr))
            {
                string plainText = AesDecrypt(aes, cipherText);
                return (plainText);
            }
        }
        static Aes GetAes(string privateKeyStr)
        {
            ASCIIEncoder asciiEncoder = new ASCIIEncoder();
            byte[] privateKey = asciiEncoder.DecodeData(privateKeyStr);
            // Create a new instance of the Aes class.
            Aes myAes = Aes.Create();
            try
            {
                //This generates a new key and initialization vector (IV).                
                SHA256 sha256 = SHA256.Create();
                byte[] aesKey = sha256.ComputeHash(privateKey, 0, 16);
                myAes.Key = aesKey;
                byte[] aesIV = new byte[16];
                Array.Copy(sha256.ComputeHash(privateKey, 16, 16), aesIV, 16);
                myAes.IV = aesIV;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return (myAes);
        }
    }
}
