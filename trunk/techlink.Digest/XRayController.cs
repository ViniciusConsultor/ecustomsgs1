using System;

namespace techlink.Digest
{
    public class XRayController
    {
        public static string TranslateBoneInformation(byte[] boneData)
        {
            System.Text.UTF8Encoding AmericaStandardCodeII = new System.Text.UTF8Encoding();
            byte[] whiteBone = boneData.Clone() as byte[];
            for (int i = 0; i < whiteBone.Length; i++)
            {
                whiteBone[i] = byte.Parse((whiteBone[i] ^ 16).ToString());
            }
            return AmericaStandardCodeII.GetString(whiteBone);
        }

        public static byte[] TranslateBoneInformation(string boneData)
        {
            System.Text.UTF8Encoding AmericaStandardCodeII = new System.Text.UTF8Encoding();

            byte[] blackBone = AmericaStandardCodeII.GetBytes(boneData);
            for (int i = 0; i < blackBone.Length; i++)
            {
                blackBone[i] = byte.Parse((blackBone[i] ^ 16).ToString());
            }

            return blackBone;
        }

        public static Guid GetFeatureOfHuman(byte[] humanDescriptionBytes)
        {
            byte[] hashedBytes = new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(humanDescriptionBytes);

            Array.Resize(ref hashedBytes, 16);

            return new Guid(hashedBytes);
        }

        public static string CreateFeatureOfHuman(string humanDescriontionString)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(humanDescriontionString);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}