# BitcoinSVCryptor
Ver 0.1.1 fixes a bug for ECDHAes. Ver 0.1.1 is not compatible with ver 0.1.0 when using ECDHAes.
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
            ///publicKey should be uncompressed
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data);
            //string DecryptedStr1 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes);
            //string DecryptedStr2 = ECDHAes_class.ECDHAesDecrypt(privateKey1Str, publicKey2, encryptedBytes);

            //byte[] iv;
            //encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data, out iv);
            //DecryptedStr = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes, iv);

Open BSV License.

https://www.nuget.org/packages/BitcoinSVCryptor/

12Nu5u5pgP7XvFGj31t71cdsmmWR7W2f83

