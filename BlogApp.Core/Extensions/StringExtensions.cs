using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlogApp.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GenerateRandomPassword()
        {
            const string upperAlphaBet = "ABCDEFGHKLMNPRSTYVWXZ";
            const string lowerAlphaBet = "abcdefghkmnprstyvwxz";
            const string numeric = "123456789";

            const int length = 8;
            const int multiper = 8;
            var bytes = new byte[length * multiper];
            new RNGCryptoServiceProvider().GetBytes(bytes);

            var stringChars = new char[8];
            var indexSet = BitConverter.ToUInt64(bytes, 0);
            stringChars[0] = upperAlphaBet[(int)(indexSet % (uint)upperAlphaBet.Length)];

            for (var i = 1; i < stringChars.Length - 1; i++)
            {
                indexSet = BitConverter.ToUInt64(bytes, i * multiper);
                stringChars[i] = numeric[(int)(indexSet % (uint)numeric.Length)];
            }
            indexSet = BitConverter.ToUInt64(bytes, 7 * multiper);
            stringChars[stringChars.Length - 1] = lowerAlphaBet[(int)(indexSet % (uint)lowerAlphaBet.Length)];
            return new String(stringChars);
        }

        public static bool IsNotNull(this string value)
        {
            return !string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);
        }
    }
}
