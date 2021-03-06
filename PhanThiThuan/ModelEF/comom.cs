using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
    public class comom
    {
        /// <summary>
        /// Mã hóa chuỗi thành chuỗi MD5
        /// Input: sToEncrypt (Chuỗi cần mã hóa)
        /// Output: Chuỗi sau khi mã hóa
        /// </summary>
        public static string EncryptMD5(string sToEncrypt)
        {
            //System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            //byte[] bytes = ue.GetBytes(sToEncrypt);

            //// encrypt bytes
            //System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //byte[] hashBytes = md5.ComputeHash(bytes);

            //// Convert the encrypted bytes back to a string (base 16)
            //string hashString = "";

            //for (int i = 0; i < hashBytes.Length; i++)
            //{
            //    hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            //}

            //return hashString.PadLeft(32, '0');
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sToEncrypt));

            // get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}

