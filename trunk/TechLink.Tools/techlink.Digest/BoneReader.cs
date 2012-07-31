using System;
using System.Collections.Generic;
using System.IO;

namespace techlink.Digest
{
    public class BoneReader
    {
        public static byte[] GetBoneInfo(string road)
        {
            if (System.IO.File.Exists(road))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(road);
                System.IO.BinaryReader br = new System.IO.BinaryReader(new System.IO.StreamReader(road).BaseStream);
                byte[] cubOfBone = new byte[fi.Length];

                try
                {
                    br.Read(cubOfBone, 0, cubOfBone.Length);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    br.Close();
                }
                return cubOfBone;
            }
            else
            {
                return new byte[0];
            }
        }

        public static bool CreateHuman(string road, byte[] boneData)
        {
            if (System.IO.File.Exists(road))
            {
                System.IO.File.Delete(road);
            }

            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(road, System.IO.FileMode.Create);
                fs.Write(boneData, 0, boneData.Length);
                fs.Flush();
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }
    }
}
