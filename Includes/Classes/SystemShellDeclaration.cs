using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Classes
{
    public partial class SystemShellDeclaration
    {

		public static String FOLDER_TYPE_DESCRIPTION = "File Folder";

		#region Win32 declarations
		protected const uint SHGFI_ICON = 0x000000100;     // get icon
		protected const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
		protected const uint SHGFI_TYPENAME = 0x000000400;     // get type name
		protected const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
		protected const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
		protected const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
		protected const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
		protected const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
		protected const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
		protected const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
		protected const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
		protected const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
		protected const uint SHGFI_OPENICON = 0x000000002;     // get open icon
		protected const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
		protected const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
		protected const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute

		protected const uint SHSIID_FOLDER = 0x3;
		protected const uint SHGSI_ICON = 0x100;
		protected const uint SHGSI_LARGEICON = 0x0;
		protected const uint SHGSI_SMALLICON = 0x1;

		protected const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
		protected const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
		protected const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
		protected const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
		protected const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
		protected const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
		protected const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
		protected const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
		protected const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
		protected const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
		protected const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
		protected const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
		protected const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
		protected const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
		protected const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			/// <summary>
			/// The iIcon field in the C++ struct has type int. On Windows that is a 4 byte signed integer.It corresponds to int in C#.
			/// You have declared the field as IntPtr in your C# code. That is a signed integer, the same size as a pointer. So it is 4 bytes in 32 bit code, and 8 bytes in 64 bit code. It seems likely that you are running 64 bit code.
			/// So, the error is the declaration of this field which simply has the wrong type.The solution is to change the type of iIcon to int.
			/// </summary>
			public int iIcon; //Originally IntPtr, changed to int because
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SHSTOCKICONINFO
		{
			public uint cbSize;
			public IntPtr hIcon;
			public int iSysIconIndex;
			public int iIcon;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szPath;
		}

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

		[DllImport("shell32.dll")]
		public static extern int SHGetStockIconInfo(uint siid, uint uFlags, ref SHSTOCKICONINFO psii);

		[DllImport("user32.dll")]
		public static extern bool DestroyIcon(IntPtr handle);

		#endregion

	}
}
