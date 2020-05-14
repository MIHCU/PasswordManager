using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Database
{
    class MyRSA
    {
        BigInteger rsa_p;
        BigInteger rsa_q;
        BigInteger rsa_n;
        BigInteger rsa_fn;
        BigInteger rsa_e;
        BigInteger rsa_d;

        public MyRSA()
        {
            rsa_p = BigInteger.Parse("136424570116881403607942492227675061849386644776459116571019516696657391840983312357813629016346413054823315879829075927893963062660246579749695452690507897483900045868409218411612746854023667795459540859505988140993192837940179589018830243246384185460036645181827767765262136012863010308866543154851937402843");
            rsa_q = BigInteger.Parse("136806216843891773999545768616846496764419215075734437696688644155798186202626102563039005293760453720902945997532919882033315648411579911173703081714644188002489431422910271995508825042637724430661016425597571223643410536775013052345284714394108183571192409395373089724978919774830046887985476700412958012209");
            rsa_n = BigInteger.Multiply(rsa_p, rsa_q);
            rsa_fn = BigInteger.Multiply(BigInteger.Subtract(rsa_p, BigInteger.One),
                    BigInteger.Subtract(rsa_q, BigInteger.One));
            rsa_e = BigInteger.Parse("65537");
            rsa_d = CalculateD(rsa_e, rsa_fn);
        }
        private BigInteger CalculateD(BigInteger e, BigInteger fn)
        {
            var x = BigInteger.Zero;
            var previousX = BigInteger.One;
            var y = BigInteger.One;
            var previousY = BigInteger.Zero;
            BigInteger temp;
            var orignalFn = fn;

            while (!fn.Equals(BigInteger.Zero))
            {
                var q = BigInteger.Divide(e, fn);
                var r = e % fn;

                e = fn;
                fn = r;

                temp = x;
                x = BigInteger.Subtract(previousX, BigInteger.Multiply(q, x));
                previousX = temp;

                temp = y;
                y = BigInteger.Subtract(previousY, BigInteger.Multiply(q, y));
                previousY = temp;
            }

            if (previousX.CompareTo(BigInteger.Zero) > 0)
                return previousX;
            return BigInteger.Subtract(orignalFn, BigInteger.Negate(previousX));
        }
        public string Encryption(string stringToEncrypt)
        {
            byte[] stringWithoutEncryption = Encoding.ASCII.GetBytes(stringToEncrypt);
            BigInteger toEncrypt = new BigInteger(stringWithoutEncryption);
            BigInteger encryptedText = BigInteger.ModPow(toEncrypt, rsa_e, rsa_n);
            return Convert.ToBase64String(encryptedText.ToByteArray());
        }

        public string Decryption(string dataToDecrypt)
        {
            byte[] encryptedText = Convert.FromBase64String(dataToDecrypt);
            BigInteger textToDecryption = new BigInteger(encryptedText);
            BigInteger decryptedText = BigInteger.ModPow(textToDecryption, rsa_d, rsa_n);
            return Encoding.ASCII.GetString(decryptedText.ToByteArray());
        }
    }
}
