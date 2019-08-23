using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Mobi_App_Project.Helpers
{
    public static class PasswordManagement
    {
        public static bool LoginPasswordVerifier(string password, string hashedPassword,string salt)
        {
            bool isCorrect = false;
            string saltedPass = password + salt;
            byte[] hashedPasswordBytes = getSHA512Hash(saltedPass);
            string hashedPasswordToVerify = BitConverter.ToString(hashedPasswordBytes).Replace("-", "");

            if(hashedPasswordToVerify.Equals(hashedPassword))
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            return isCorrect;
        }

        /// <summary>
        /// returns a string array containing 3 values: index 0 is the password, index 1 is the salt, index 2 is the pin
        /// </summary>
        /// <param name="ptPassword"></param>
        /// <returns> string array wtih hashed pass and salt</returns>
        public static string[] HashedPassAndSalt(string ptPassword,string ptPin)
        {
            string[] PassHashedAndSalt = new string[3];
            string salt = GetUniqueKey(30, 40);
            string saltedPass = ptPassword + salt;
            string saltedPin = salt + ptPin;
            
            byte[] hashedPasswordBytes = getSHA512Hash(saltedPass);
            byte[] hashedPinBytes = getSHA512Hash(saltedPin);

            PassHashedAndSalt[0] = BitConverter.ToString(hashedPasswordBytes).Replace("-", "");
            PassHashedAndSalt[1] = salt;
            PassHashedAndSalt[2] = BitConverter.ToString(hashedPinBytes).Replace("-", "");

            return PassHashedAndSalt;
        }

        private static string GetUniqueKey(int minSize, int maxSize)
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            //Random rand = new Random();

            char[] chars = new char[70];
            // test  
            chars = " $.,!%^*abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            int delta = maxSize - minSize + 1;
            int rSize = minSize;


            byte[] randomizerForLength = new byte[1];
            crypto.GetNonZeroBytes(randomizerForLength);
            rSize += randomizerForLength[0] % delta;

            byte[] data = new byte[rSize];
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(rSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();           
        }

        private static byte[] getSHA512Hash(string input)
        {
            using (HashAlgorithm ha = new SHA512CryptoServiceProvider())
            {
                byte[] data = new byte[input.Length * sizeof(char)];
                // copy into the return byte array  
                System.Buffer.BlockCopy(input.ToCharArray(), 0, data, 0, data.Length);
                data = ha.ComputeHash(data);
                return data;
            }
        }
    }
}
