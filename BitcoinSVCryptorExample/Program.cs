﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinSVCryptor;
using NBitcoin;
using System.Security.Cryptography;

namespace BitcoinSVCryptorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string privateKey1Str = "";
            byte[] publicKey1 = BitcoinSVCryptor_class.getBCPublicKey(privateKey1Str);
            string publicKey1Str = BitcoinSVCryptor_class.getCompressedBCPublicKey(privateKey1Str);
            //2
            string privateKey2Str = "";
            byte[] publicKey2 = BitcoinSVCryptor_class.getBCPublicKey(privateKey2Str);
            string publicKey2Str = BitcoinSVCryptor_class.getCompressedBCPublicKey(privateKey2Str);

            string data = "bsv test 1234";
            Console.WriteLine(data);
            byte[] encryptedBytes;
            string DecryptedStr = null;
            string s = null;

            ////ECDSA
            //s = BitcoinSVCryptor_class.sign(privateKey1Str, data);
            //bool success = BitcoinSVCryptor_class.verifySignature(publicKey1Str, data, s);
            //Console.WriteLine(success);

            ////ECC
            //s = BitcoinSVCryptor_class.ECCEncrypt(publicKey1Str, data);
            //DecryptedStr = BitcoinSVCryptor_class.ECCDecrypt(privateKey1Str, s);

            ////AES
            //encryptedBytes = AES_class.AesEncrypt(data, privateKey1Str);
            //DecryptedStr = AES_class.AesDecrypt(encryptedBytes, privateKey1Str);

            ////ECDHAes
            ///publicKey should be uncompressed
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data);
            //string DecryptedStr1 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes);
            //string DecryptedStr2 = ECDHAes_class.ECDHAesDecrypt(privateKey1Str, publicKey2, encryptedBytes);

            //byte[] iv;
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data, out iv);
            //DecryptedStr = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes, iv);

            Console.WriteLine(DecryptedStr);
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }        
    }


}
