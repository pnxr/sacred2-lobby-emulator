using System;
using System.IO;

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.EC;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;

namespace S2Library.Protocol
{
    public class Crypto
    {
        public static byte[] BytesFromHexString(string text)
        {
            return Hex.Decode(text);
        }

        public static byte[] CreateSecretKey()
        {
            byte[] randomBytes = new byte[32];
            new SecureRandom().NextBytes(randomBytes);
            return randomBytes;
        }

        public static byte[] CreateNonce()
        {
            byte[] randomBytes = new byte[128];
            new SecureRandom().NextBytes(randomBytes);
            return randomBytes;
        }

        public static byte[] HashPassword(byte[] password)
        {
            Sha512Digest sha512 = new Sha512Digest();
            byte[] hash = new byte[sha512.GetDigestSize()];
            sha512.BlockUpdate(password, 0, password.Length);
            sha512.DoFinal(hash, 0);
            return hash;
        }

        public static byte[] HandleKey(byte[] key, byte[] secretKey)
        {
            Asn1InputStream inputStream = new Asn1InputStream(key);
            Asn1Object o1 = inputStream.ReadObject();
            DerSequence seq = o1 as DerSequence;

            DerInteger x = seq[2] as DerInteger;
            DerInteger y = seq[3] as DerInteger;

            X9ECParameters p = CustomNamedCurves.GetByName("secp521r1");
            ECDomainParameters domainParameters = new ECDomainParameters(p.Curve, p.G, p.N, p.H);

            ECPoint point = p.Curve.CreatePoint(x.Value, y.Value);
            ECPublicKeyParameters publicKeyParameters = new ECPublicKeyParameters(point, domainParameters);

            ECKeyPairGenerator generator = new ECKeyPairGenerator();
            generator.Init(new ECKeyGenerationParameters(publicKeyParameters.Parameters, new SecureRandom()));
            AsymmetricCipherKeyPair keyPair = generator.GenerateKeyPair();

            ECDHBasicAgreement basicAgreement = new ECDHBasicAgreement();
            basicAgreement.Init(keyPair.Private);
            BigInteger agreement = basicAgreement.CalculateAgreement(publicKeyParameters);

            byte[] agreementBytes = agreement.ToByteArray();
            if (agreementBytes.Length == 65)
            {
                byte[] newAgreement = new byte[66];
                Array.Copy(agreementBytes, 0, newAgreement, 1, 65);
                agreementBytes = newAgreement;
            }

            Sha512Digest sha512 = new Sha512Digest();
            byte[] hash = new byte[sha512.GetDigestSize()];
            sha512.BlockUpdate(agreementBytes, 0, agreementBytes.Length);
            sha512.DoFinal(hash, 0);

            byte[] secret = new byte[secretKey.Length];
            for (int i = 0; i < secret.Length; i++)
            {
                secret[i] = secretKey[i];
                secret[i] ^= hash[i];
            }

            ECPublicKeyParameters publicKey = keyPair.Public as ECPublicKeyParameters;

            MemoryStream keyStream = new MemoryStream();
            DerSequenceGenerator gen2 = new DerSequenceGenerator(keyStream);
            gen2.AddObject(new DerBitString(new byte[] { 0x00 }, 7));
            gen2.AddObject(new DerInteger(new byte[] { 0x41 }));
            gen2.AddObject(new DerInteger(publicKey.Q.XCoord.ToBigInteger()));
            gen2.AddObject(new DerInteger(publicKey.Q.YCoord.ToBigInteger()));
            gen2.Close();

            MemoryStream memoryStream = new MemoryStream();

            DerSequenceGenerator gen1 = new DerSequenceGenerator(memoryStream);
            gen1.AddObject(new DerObjectIdentifier("2.16.840.1.101.3.4.2.3"));
            gen1.AddObject(new DerOctetString(keyStream.ToArray()));
            gen1.AddObject(new DerOctetString(secret));
            gen1.Close();

            byte[] result = memoryStream.ToArray();

            memoryStream.Close();
            keyStream.Close();

            return result;
        }

        public static byte[] HandleCipher(byte[] cipher, byte[] secretKey)
        {

            TwofishEngine engine = new TwofishEngine();
            CtrBlockCipher blockCipher = new CtrBlockCipher(engine);
            KeyParameter secret = new KeyParameter(secretKey);

            ParametersWithIV key = new ParametersWithIV(secret, cipher, 0, 16);

            int cipherLength = cipher.Length;
            int blockSize = engine.GetBlockSize();
            int fraction = cipherLength % blockSize;
            cipherLength += blockSize - fraction;

            byte[] input = new byte[cipherLength];
            Array.Copy(cipher, input, cipher.Length);

            blockCipher.Init(false, key);

            byte[] result = new byte[cipherLength - 16];
            int pos = 0;
            while (pos < cipher.Length - 16)
            {
                int length = blockCipher.ProcessBlock(input, pos + 16, result, pos);
                pos += length;
            }

            return result;
        }

        public static byte[] HandleSessionKey(byte[] sessionKey, byte[] sharedSecret)
        {
            byte[] iv = new byte[16];
            new SecureRandom().NextBytes(iv);

            TwofishEngine engine = new TwofishEngine();
            CtrBlockCipher blockCipher = new CtrBlockCipher(engine);
            KeyParameter secret = new KeyParameter(sharedSecret);

            ParametersWithIV key = new ParametersWithIV(secret, iv);
            blockCipher.Init(true, key);

            byte[] result = new byte[iv.Length + sessionKey.Length];
            Array.Copy(iv, result, iv.Length);

            int pos = 0;
            while (pos < sessionKey.Length)
            {
                int length = blockCipher.ProcessBlock(sessionKey, pos, result, pos + iv.Length);
                pos += length;
            }

            return result;
        }
    }

    public class CtrBlockCipher
        : IBlockCipher
    {
        private readonly IBlockCipher cipher;
        private readonly int blockSize;
        private readonly byte[] counter;
        private readonly byte[] counterOut;
        private byte[] IV;

        public CtrBlockCipher(IBlockCipher cipher)
        {
            this.cipher = cipher;
            this.blockSize = cipher.GetBlockSize();
            this.counter = new byte[blockSize];
            this.counterOut = new byte[blockSize];
            this.IV = new byte[blockSize];
        }

        public virtual IBlockCipher GetUnderlyingCipher()
        {
            return cipher;
        }

        public virtual void Init(
            bool				forEncryption, //ignored by this CTR mode
            ICipherParameters	parameters)
        {
            ParametersWithIV ivParam = parameters as ParametersWithIV;
            if (ivParam == null)
                throw new ArgumentException("CTR/SIC mode requires ParametersWithIV", "parameters");

            this.IV = Arrays.Clone(ivParam.GetIV());

            if (blockSize < IV.Length)
                throw new ArgumentException("CTR/SIC mode requires IV no greater than: " + blockSize + " bytes.");

            int maxCounterSize = System.Math.Min(8, blockSize / 2);
            if (blockSize - IV.Length > maxCounterSize)
                throw new ArgumentException("CTR/SIC mode requires IV of at least: " + (blockSize - maxCounterSize) + " bytes.");

            if (ivParam.Parameters != null)
            {
                cipher.Init(true, ivParam.Parameters);
            }

            Reset();
        }

        public virtual string AlgorithmName
        {
            get { return cipher.AlgorithmName + "/CTR"; }
        }

        public virtual bool IsPartialBlockOkay
        {
            get { return true; }
        }

        public virtual int GetBlockSize()
        {
            return cipher.GetBlockSize();
        }

        public virtual int ProcessBlock(
            byte[]	input,
            int		inOff,
            byte[]	output,
            int		outOff)
        {
            cipher.ProcessBlock(counter, 0, counterOut, 0);

            for (int i = 0; i < counterOut.Length; i++)
            {
                output[outOff + i] = (byte)(counterOut[i] ^ input[inOff + i]);
            }

            int j = 0;
            while (j < counter.Length && ++counter[j++] == 0)
            {
            }

            return counter.Length;
        }

        public virtual void Reset()
        {
            Arrays.Fill(counter, (byte)0);
            Array.Copy(IV, 0, counter, 0, IV.Length);
            cipher.Reset();
        }
    }
}
