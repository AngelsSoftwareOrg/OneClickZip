using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Classes
{
    public class SystemFilesDirInfo : SystemShellDeclaration
    {
        public static string GetFileTypeDescription(string fileNameOrExtension)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            if (IntPtr.Zero != SHGetFileInfo(
                                fileNameOrExtension,
                                FILE_ATTRIBUTE_NORMAL,
                                ref shinfo,
                                (uint)Marshal.SizeOf(typeof(SHFILEINFO)),
                                SHGFI_USEFILEATTRIBUTES | SHGFI_TYPENAME))
            { 
                return shinfo.szTypeName;
            }
            return FOLDER_TYPE_DESCRIPTION;
        }
    }
}
