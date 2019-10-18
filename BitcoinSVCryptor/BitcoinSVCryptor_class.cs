using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;

namespace BitcoinSVCryptor
{
    public class BitcoinSVCryptor_class
    {
        //basic
        public static byte[] getBCPublicKey(string bitcoinPrivateKeyStr)
        {
            BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr);
            byte[] BCPublicKey = bs.PubKey.Decompress().ToBytes();
            return (BCPublicKey);
        }
        public static string getCompressedBCPublicKey(string bitcoinPrivateKeyStr)
        {
            BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr);
            string pubKeyStr = bs.PubKey.ToString();
            return (pubKeyStr);
        }
        public static byte[] getBCPrivateKey(string bitcoinPrivateKeyStr)
        {
            BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr);
            return (bs.PrivateKey.ToBytes());
        }
        //ECDSA
        public static string sign(string bitcoinPrivateKeyStr, string message)
        {
            BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr);
            string sign = bs.PrivateKey.SignMessage(message);
            return (sign);
        }
        public static bool verifySignature(string bitcoinPubKeyStr, string message, string signature)
        {
            PubKey pubKey = new PubKey(bitcoinPubKeyStr);
            bool success= pubKey.VerifyMessage(message, signature);
            return (success);
        }

        //ECC
        public static string ECCEncrypt(string publicKeyHexStr, string plainText)
        {
            PubKey pubKey = new PubKey(publicKeyHexStr);
            string cipherStr = pubKey.Encrypt(plainText);
            return (cipherStr);
        }
        public static string ECCDecrypt(string BitcoinPrivateKey, string cipherStr)
        {
            BitcoinSecret bs = new BitcoinSecret(BitcoinPrivateKey);
            string plainText = bs.PrivateKey.Decrypt(cipherStr);
            return (plainText);
        }


    }
}
