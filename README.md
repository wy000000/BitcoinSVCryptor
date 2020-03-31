# BitcoinSVCryptor
BitcoinSVCryptor ver 0.1.0 integrates bitcoin private/public keys with serval encryption methods, including ECDSA, ECC, ECDH and AES. IBE is in the plan for future version. 

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
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data);
            //DecryptedStr = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes);

            //byte[] iv;
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data, out iv);
            //DecryptedStr = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes, iv);

Open BSV License.

https://www.nuget.org/packages/BitcoinSVCryptor/

18WrLbAU54S8N16jMHomkhqpMtkPHLh3Dv

