# BitcoinSVCryptor
Ver 0.1.3 upgraded for compatibility with NBitcoin 10.0.3.
Ver 0.1.2 allows passing a public key directly as a string to the ECDHAes encryption/decryption functions, with support for both compressed and uncompressed formats.
Ver 0.1.1 fixes a bug for ECDHAes. Ver 0.1.1 is not compatible with ver 0.1.0 when using ECDHAes.
BitcoinSVCryptor ver 0.1.0 integrates bitcoin private/public keys with serval encryption methods, including ECDSA, ECC, ECDH and AES. IBE is in the plan for future version. 

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
			//encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data);
			//string DecryptedStr1 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes);
			//encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2Str, data);
			//string DecryptedStr2 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1Str, encryptedBytes);

			//byte[] iv;
			//encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2, data, out iv);
			//DecryptedStr1 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1, encryptedBytes, iv);
			//encryptedBytes = ECDHAes_class.ECDHAesEncrypt(privateKey1Str, publicKey2Str, data, out iv);
			//DecryptedStr2 = ECDHAes_class.ECDHAesDecrypt(privateKey2Str, publicKey1Str, encryptedBytes, iv);

Open BSV License.

https://www.nuget.org/packages/BitcoinSVCryptor/

12Nu5u5pgP7XvFGj31t71cdsmmWR7W2f83

