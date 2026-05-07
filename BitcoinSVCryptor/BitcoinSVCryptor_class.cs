using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinSVCryptor
{
	public class BitcoinSVCryptor_class
	{

		//basic
		public static byte[] getBCPublicKey(string bitcoinPrivateKeyStr)
		{
			Network nbNetworkFlag = getNbNetworkFlagFromWifkey(bitcoinPrivateKeyStr);
			BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr, nbNetworkFlag);
			byte[] BCPublicKey = bs.PubKey.Decompress().ToBytes();
			return (BCPublicKey);
		}
		public static string getCompressedBCPublicKey(string bitcoinPrivateKeyStr)
		{
			Network nbNetworkFlag = getNbNetworkFlagFromWifkey(bitcoinPrivateKeyStr);
			BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr, nbNetworkFlag);
			string pubKeyStr = bs.PubKey.ToString();
			return (pubKeyStr);
		}
		public static byte[] getBCPrivateKey(string bitcoinPrivateKeyStr)
		{
			Network nbNetworkFlag = getNbNetworkFlagFromWifkey(bitcoinPrivateKeyStr);
			BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr, nbNetworkFlag);
			return (bs.PrivateKey.ToBytes());
		}
		//ECDSA
		public static string sign(string bitcoinPrivateKeyStr, string message)
		{
			Network nbNetworkFlag = getNbNetworkFlagFromWifkey(bitcoinPrivateKeyStr);
			BitcoinSecret bs = new BitcoinSecret(bitcoinPrivateKeyStr, nbNetworkFlag);
			byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
			byte[] hash = Hashes.SHA256(data);
			uint256 u256 = new uint256(hash);
			ECDSASignature sig = bs.PrivateKey.Sign(u256);
			string sign = Convert.ToBase64String(sig.ToDER());
			//string sign = bs.PrivateKey.SignMessage(message);
			return (sign);
		}
		public static bool verifySignature(string bitcoinPubKeyStr, string message, string signature)
		{
			PubKey pubKey = new PubKey(bitcoinPubKeyStr);
			// 将消息转为哈希（这里用 SHA256，确保是 32 字节）
			byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
			byte[] hash = Hashes.SHA256(data);
			uint256 u256 = new uint256(hash);
			// 签名解码（Base64 → DER）
			byte[] sigBytes = Encoders.Base64.DecodeData(signature);
			var sig = new ECDSASignature(sigBytes);

			bool success= pubKey.Verify(u256, sig);
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
			Network nbNetworkFlag = getNbNetworkFlagFromWifkey(BitcoinPrivateKey);
			BitcoinSecret bs = new BitcoinSecret(BitcoinPrivateKey, nbNetworkFlag);
			string plainText = bs.PrivateKey.Decrypt(cipherStr);
			return (plainText);
		}



		public static Network getNbNetworkFlagFromWifkey(string wifKey)
		{
			// Base58Check 解码
			byte[] data = Encoders.Base58Check.DecodeData(wifKey);

			// 第一个字节就是网络前缀
			byte prefix = data[0];

			if (prefix == 0x80)
				return Network.Main;
			if (prefix == 0xEF)
				return Network.TestNet;
			throw new FormatException($"unknow network: {prefix:X2}");
		}
		



}
}
