using System;
using System.Text;
using LayersCMS.Util.Security.Interfaces;

namespace LayersCMS.Util.Security.Implementations
{
    public class HashHelper : IHashHelper
    {
        #region Implementation of IHashHelper

        public string HashString(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException();

            var md5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            bytes = md5CryptoServiceProvider.ComputeHash(bytes);
            var s = new StringBuilder();
            foreach (byte b in bytes)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public bool VerifyHash(string plainText, string hashedText)
        {
            if (String.IsNullOrWhiteSpace(plainText))
                throw new ArgumentNullException();

            string hashedPlainText = HashString(plainText);
            return String.Compare(hashedPlainText, hashedText, StringComparison.OrdinalIgnoreCase) == 0;
        }

        #endregion
    }
}
