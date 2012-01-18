﻿using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ECustoms.Utilities
{
    public class Common
    {
        #region Enum
        /// <summary>
        /// Indicate that the declerationExport or DeclerationImport
        /// </summary>
        public enum DeclerationType
        {
            Export = 0,
            Import = 1
        }

        /// <summary>
        /// Management of temporary import for reexport
        /// </summary>
        public enum GateTranfer
        {
            Export = 0,
            Import = 1,
            Reexport =2
        }
       
        #endregion

        #region methods

        public static string Encode(string originalPassword)
        {
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] originalBytes = Encoding.Default.GetBytes(originalPassword);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            var settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            var key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            var settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = Encoding.UTF8.GetBytes(key);
            }

            var tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// add hour and miniuts to datetime
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="hourMiniutes">Format: hh:mm</param>
        /// <returns></returns>
        public static DateTime AddHourMinutes(DateTime datetime, string hourMiniutes) {
            var exporttHour = Convert.ToInt32(hourMiniutes.Split(':')[0]);
            var exporMinitues = Convert.ToInt32(hourMiniutes.Split(':')[1]);
            // Add export minitues
            datetime = datetime.AddMinutes(exporMinitues - datetime.Minute);
            // Add export hour
            datetime = datetime.AddHours(exporttHour - datetime.Hour);
            return datetime;
        }
        #endregion
    }
}
