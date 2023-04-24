using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using NBitcoin;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math.EC;
using NBitcoin.DataEncoders;

namespace BitcoinSVCryptor
{
    public class ECDHAes_class
    {
        public static byte[] ECDHAesEncrypt(string myBitcoinPrivateKeyStr, byte[] otherPartyPublicKey, string plainText)
        {
            byte[] ECDHAesKey = GetECDHAesKey(myBitcoinPrivateKeyStr, otherPartyPublicKey);
            Aes aes = getAes(BitcoinSVCryptor_class.getBCPublicKey(myBitcoinPrivateKeyStr), otherPartyPublicKey, ECDHAesKey);
            byte[] cipher = AES_class.AesEncrypt(aes, plainText);
            return (cipher);
        }
        public static string ECDHAesDecrypt(string myBitcoinPrivateKeyStr, byte[] otherPartyPublicKey, byte[] cipher)
        {
            byte[] ECDHAesKey = GetECDHAesKey(myBitcoinPrivateKeyStr, otherPartyPublicKey);
            Aes aes = getAes(otherPartyPublicKey, BitcoinSVCryptor_class.getBCPublicKey(myBitcoinPrivateKeyStr), ECDHAesKey);
            string plainText = AES_class.AesDecrypt(aes, cipher);
            return (plainText);
        }
        static Aes getAes(byte[] senderPublicKey, byte[] receiverPublicKey, byte[] aesKey)
        {
            byte[] bytes = new byte[senderPublicKey.Length];

			for (int i=0;i<senderPublicKey.Length;i++)
            {
                bytes[i] = (byte)(senderPublicKey[i] ^ receiverPublicKey[i]);
            }
            //byte[] bytes = senderPublicKey.Concat(receiverPublicKey).ToArray();
            SHA256 sha256 = SHA256.Create();
            byte[] iv = new byte[16];
            Array.Copy(sha256.ComputeHash(bytes), 0, iv, 0, 15);
            Aes aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = iv;
            return (aes);
        }
        public static byte[] ECDHAesEncrypt(string myBitcoinPrivateKeyStr, byte[] otherPartyPublicKey, string plainText, out byte[] iv)
        {
            byte[] aesKey = GetECDHAesKey(myBitcoinPrivateKeyStr, otherPartyPublicKey);
            byte[] encryptedByte = AES_class.AesEncrypt(aesKey, plainText, out iv);
            return (encryptedByte);
        }
        public static string ECDHAesDecrypt(string myBitcoinPrivateKeyStr, byte[] otherPartyPublicKey, byte[] encryptedBytes, byte[] iv)
        {
            byte[] aesKey = GetECDHAesKey(myBitcoinPrivateKeyStr, otherPartyPublicKey);
            string plainText = AES_class.AesDecrypt(aesKey, encryptedBytes, iv);
            return (plainText);
        }
        static byte[] GetECDHAesKey(string myBitcoinPrivateKeyStr, byte[] otherPartyPublicKey)
        {
            AsymmetricCipherKeyPair myKeyPair = GetKeyPair(myBitcoinPrivateKeyStr);// new AsymmetricCipherKeyPair(myECPublicKey, myECPrivateKey);            
            //create ecdh aes key
            ECDHBasicAgreement agreement = new ECDHBasicAgreement();
            agreement.Init(myKeyPair.Private);
            BigInteger aesKeyBI = agreement.CalculateAgreement(getECPublicKey(otherPartyPublicKey));
            byte[] aesKey = aesKeyBI.ToByteArrayUnsigned();
            return (aesKey);
        }
        static ECPublicKeyParameters getECPublicKey(byte[] BCPublicKey)
        {
            // Import public key
            X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);
            ECDomainParameters ecdp = TlsEccUtilities.GetParametersForNamedCurve(NamedCurve.secp256k1);
            ECPublicKeyParameters ECPubKeyPt = TlsEccUtilities.DeserializeECPublicKey(null, ecdp, BCPublicKey);
            ECPublicKeyParameters basePoint = TlsEccUtilities.ValidateECPublicKey(ECPubKeyPt);
            SubjectPublicKeyInfo subinfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(basePoint);
            ECPublicKeyParameters ECPublicKey = (ECPublicKeyParameters)PublicKeyFactory.CreateKey(subinfo);
            return (ECPublicKey);
        }
        static AsymmetricCipherKeyPair GetKeyPair(string bitcoinPrivateKeyStr)
        {
            //import private key and generate public key
            byte[] bitcoinPrivateKeyBytes = BitcoinSVCryptor_class.getBCPrivateKey(bitcoinPrivateKeyStr);
            X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);
            BigInteger BCPrivateKey_D = new BigInteger(1, bitcoinPrivateKeyBytes);
            Org.BouncyCastle.Math.EC.ECPoint q = domain.G.Multiply(BCPrivateKey_D);
            ECPrivateKeyParameters ECPrivateKey = new ECPrivateKeyParameters(BCPrivateKey_D, domain);
            ECPublicKeyParameters ECPublicKey = new ECPublicKeyParameters(q, domain);
            AsymmetricCipherKeyPair KeyPair = new AsymmetricCipherKeyPair(ECPublicKey, ECPrivateKey);
            return (KeyPair);
        }

        




    }

}
