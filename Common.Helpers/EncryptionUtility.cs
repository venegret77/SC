using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{
    /// <summary>
    /// Класс дешифровки-шифровки
    /// </summary>
    public static class EncryptionUtility
    {
        private static byte[] key = new byte[8] { 5, 3, 8, 2, 1, 3, 8, 1 };
        private static byte[] iv = new byte[8] { 5, 4, 8, 0, 6, 1, 5, 3 };

        /// <summary>
        /// Метод шифрования
        /// </summary>
        /// <param name="text">Текст для шифрования</param>
        public static string EncryptDESToBase64(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        /// <summary>
        /// Метод дешифрования
        /// </summary>
        /// <param name="text">Текст для дешифровки</param>
        public static string DecryptDESFromBase64(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}
