using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO;

namespace WindowsFormsApplication2
{
    class ZIPHandling
    {
        public static byte[] GetFileFromZip(string zipPath, string fileName)
        {
            byte[] ret = null;
            ZipFile zf = new ZipFile(zipPath);
            ZipEntry ze = zf.GetEntry(fileName);

            if (ze != null)
            {
                Stream s = zf.GetInputStream(ze);
                ret = new byte[ze.Size];
                s.Read(ret, 0, ret.Length);
            }

            return ret;
        }
    }
}
