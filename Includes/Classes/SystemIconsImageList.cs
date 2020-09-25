using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

namespace OneClickZip.Includes.Classes
{
	public class SystemIconsImageList : SystemShellDeclaration, IDisposable
	{
		private static String ICON_NAME_FOR_DIRECTORIES = "5EEB255733234c4dBECF9A128E896A1E";
		private static String ICON_NAME_FOR_FILES_WITHOUT_EXTENSION = "F9EB930C78D2477c80A51945D505E9C4";

		#region Stock Icons
		public enum SHSTOCKICONID : uint
		{
			SIID_DOCNOASSOC = 0,
			SIID_DOCASSOC = 1,
			SIID_APPLICATION = 2,
			SIID_FOLDER = 3,
			SIID_FOLDEROPEN = 4,
			SIID_DRIVE525 = 5,
			SIID_DRIVE35 = 6,
			SIID_DRIVEREMOVE = 7,
			SIID_DRIVEFIXED = 8,
			SIID_DRIVENET = 9,
			SIID_DRIVENETDISABLED = 10,
			SIID_DRIVECD = 11,
			SIID_DRIVERAM = 12,
			SIID_WORLD = 13,
			SIID_SERVER = 15,
			SIID_PRINTER = 16,
			SIID_MYNETWORK = 17,
			SIID_FIND = 22,
			SIID_HELP = 23,
			SIID_SHARE = 28,
			SIID_LINK = 29,
			SIID_SLOWFILE = 30,
			SIID_RECYCLER = 31,
			SIID_RECYCLERFULL = 32,
			SIID_MEDIACDAUDIO = 40,
			SIID_LOCK = 47,
			SIID_AUTOLIST = 49,
			SIID_PRINTERNET = 50,
			SIID_SERVERSHARE = 51,
			SIID_PRINTERFAX = 52,
			SIID_PRINTERFAXNET = 53,
			SIID_PRINTERFILE = 54,
			SIID_STACK = 55,
			SIID_MEDIASVCD = 56,
			SIID_STUFFEDFOLDER = 57,
			SIID_DRIVEUNKNOWN = 58,
			SIID_DRIVEDVD = 59,
			SIID_MEDIADVD = 60,
			SIID_MEDIADVDRAM = 61,
			SIID_MEDIADVDRW = 62,
			SIID_MEDIADVDR = 63,
			SIID_MEDIADVDROM = 64,
			SIID_MEDIACDAUDIOPLUS = 65,
			SIID_MEDIACDRW = 66,
			SIID_MEDIACDR = 67,
			SIID_MEDIACDBURN = 68,
			SIID_MEDIABLANKCD = 69,
			SIID_MEDIACDROM = 70,
			SIID_AUDIOFILES = 71,
			SIID_IMAGEFILES = 72,
			SIID_VIDEOFILES = 73,
			SIID_MIXEDFILES = 74,
			SIID_FOLDERBACK = 75,
			SIID_FOLDERFRONT = 76,
			SIID_SHIELD = 77,
			SIID_WARNING = 78,
			SIID_INFO = 79,
			SIID_ERROR = 80,
			SIID_KEY = 81,
			SIID_SOFTWARE = 82,
			SIID_RENAME = 83,
			SIID_DELETE = 84,
			SIID_MEDIAAUDIODVD = 85,
			SIID_MEDIAMOVIEDVD = 86,
			SIID_MEDIAENHANCEDCD = 87,
			SIID_MEDIAENHANCEDDVD = 88,
			SIID_MEDIAHDDVD = 89,
			SIID_MEDIABLURAY = 90,
			SIID_MEDIAVCD = 91,
			SIID_MEDIADVDPLUSR = 92,
			SIID_MEDIADVDPLUSRW = 93,
			SIID_DESKTOPPC = 94,
			SIID_MOBILEPC = 95,
			SIID_USERS = 96,
			SIID_MEDIASMARTMEDIA = 97,
			SIID_MEDIACOMPACTFLASH = 98,
			SIID_DEVICECELLPHONE = 99,
			SIID_DEVICECAMERA = 100,
			SIID_DEVICEVIDEOCAMERA = 101,
			SIID_DEVICEAUDIOPLAYER = 102,
			SIID_NETWORKCONNECT = 103,
			SIID_INTERNET = 104,
			SIID_ZIPFILE = 105,
			SIID_SETTINGS = 106,
			SIID_DRIVEHDDVD = 132,
			SIID_DRIVEBD = 133,
			SIID_MEDIAHDDVDROM = 134,
			SIID_MEDIAHDDVDR = 135,
			SIID_MEDIAHDDVDRAM = 136,
			SIID_MEDIABDROM = 137,
			SIID_MEDIABDR = 138,
			SIID_MEDIABDRE = 139,
			SIID_CLUSTEREDDRIVE = 140,
			SIID_MAX_ICONS = 175
		}
		#endregion

		#region Fields
		private ImageList _smallImageList = new ImageList();
		private ImageList _largeImageList = new ImageList();

		private bool _disposed = false;
		#endregion

		#region Properties
		/// <summary>
		/// Gets System.Windows.Forms.ImageList with small icons in. Assign this property to SmallImageList of ListView, TreeView etc.
		/// </summary>
		public ImageList SmallIconsImageList
		{
			get { return _smallImageList; }
		}

		/// <summary>
		/// Gets System.Windows.Forms.ImageList with large icons in. Assign this property to LargeImageList of ListView, TreeView etc.
		/// </summary>
		public ImageList LargeIconsImageList
		{
			get { return _largeImageList; }
		}

		/// <summary>
		/// Gets number of icons were loaded
		/// </summary>
		public int Count
		{
			get { return _smallImageList.Images.Count; }
		}
		#endregion

		#region Constructor/Destructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public SystemIconsImageList()
			: base()
		{
			_smallImageList.ColorDepth = ColorDepth.Depth32Bit;
			_smallImageList.ImageSize = SystemInformation.SmallIconSize;

			_largeImageList.ColorDepth = ColorDepth.Depth32Bit;
			_largeImageList.ImageSize = SystemInformation.IconSize;
		}

		private void CleanUp(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_smallImageList.Dispose();
					_largeImageList.Dispose();
				}
			}
			_disposed = true;
		}

		/// <summary>
		/// Performs resource cleaning
		/// </summary>
		public void Dispose()
		{
			CleanUp(true);
			GC.SuppressFinalize(this);
		}

		~SystemIconsImageList()
		{
			CleanUp(false);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns index of an icon based on FileName. Note: File should exists!
		/// </summary>
		/// <param name="FileName">Name of an existing File or Directory</param>
		/// <returns>Index of an Icon</returns>
		public int GetIconIndex(string FileName)
		{
			SHFILEINFO shinfo = new SHFILEINFO();

			FileInfo info = new FileInfo(FileName);

			string ext = info.Extension;
			if (String.IsNullOrEmpty(ext))
			{
				if ((info.Attributes & FileAttributes.Directory) != 0)
					ext = ICON_NAME_FOR_DIRECTORIES; // for directories
				else
					ext = ICON_NAME_FOR_FILES_WITHOUT_EXTENSION; // for files without extension
			}
			else
				if (ext.Equals(".exe", StringComparison.InvariantCultureIgnoreCase) ||
					ext.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
				ext = info.Name;

			if (_smallImageList.Images.ContainsKey(ext))
			{
				return _smallImageList.Images.IndexOfKey(ext);
			}
			else
			{
				SHGetFileInfo(FileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
				Icon smallIcon;
				try
				{
					smallIcon = Icon.FromHandle(shinfo.hIcon);
				}
				catch (ArgumentException ex)
				{
					throw new ArgumentException(String.Format("File \"{0}\" doesn not exist!", FileName), ex);
				}
				_smallImageList.Images.Add(ext, smallIcon);

				SHGetFileInfo(FileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
				Icon largeIcon = Icon.FromHandle(shinfo.hIcon);
				_largeImageList.Images.Add(ext, largeIcon);
				return _smallImageList.Images.Count - 1;
			}
		}
		
		public int GetIconIndexForDirectories()
		{
			if (!_smallImageList.Images.ContainsKey(ICON_NAME_FOR_DIRECTORIES))
			{
				_smallImageList.Images.Add(ICON_NAME_FOR_DIRECTORIES, GetStockIcon(SHSIID_FOLDER, SHGSI_SMALLICON));
			}
			return _smallImageList.Images.IndexOfKey(ICON_NAME_FOR_DIRECTORIES);
		}

		public Icon GetStockIcon(uint type, uint size)
		{
			var info = new SHSTOCKICONINFO();
			info.cbSize = (uint)Marshal.SizeOf(info);

			SHGetStockIconInfo(type, SHGSI_ICON | size, ref info);

			var icon = (Icon)Icon.FromHandle(info.hIcon).Clone(); // Get a copy that doesn't use the original handle
			DestroyIcon(info.hIcon); // Clean up native icon to prevent resource leak

			return icon;
		}

		#endregion
	}
}
