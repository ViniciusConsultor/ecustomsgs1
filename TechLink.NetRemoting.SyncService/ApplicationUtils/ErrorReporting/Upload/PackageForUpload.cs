using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApplicationUtils.ErrorReporting.Upload
{
    [Serializable]
    public class PackageForUpload
    {
        private readonly string packageName;
        private readonly byte[] packageContent;
        private readonly byte[] shortVersion;


        public PackageForUpload(string packageName, byte[] packageContent, byte[] shortVersion)
        {
            this.packageName = packageName;
            this.packageContent = packageContent;
            this.shortVersion = shortVersion;
        }

        public string PackageName
        {
            get
            {
                return packageName;
            }
        }

        public string ShortVersionPackageName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(packageName) + "-short.zip";
            }
        }

        public byte[] ShortVersion
        {
            get
            {
                return shortVersion;
            }
        }

        public byte[] PackageContent
        {
            get
            {
                return packageContent;
            }
        }
    }
}
