using Microsoft.Win32;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Classes
{
    public class FileAssociation
    {
        // needed so that Explorer windows get refreshed after the registry is updated
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        private const int SHCNE_ASSOCCHANGED = 0x8000000;
        private const int SHCNF_FLUSH = 0x1000;

        private enum REGISTRY_ROOT_TYPE
        {
            HKLM,
            HKCU
        };

        public static void EnsureAssociationsSet()
        {
            var filePath = Process.GetCurrentProcess().MainModule.FileName;
            EnsureAssociationsSet(new FileAssociationModel[]{
                    ResourcesUtil.GetFileAssociationProjectDesignerModel(filePath),
                    ResourcesUtil.GetFileAssociationBatchFileModel(filePath),
                });
        }

        public static void EnsureAssociationsSet(params FileAssociationModel[] associations)
        {
            bool madeChanges = false;
            foreach (var association in associations)
            {
                madeChanges |= SetAssociation(association);
            }
            if (madeChanges)
            {
                SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
            }
        }

        public static bool IsApplicationProgramAlreadyAssociatedWith()
        {
            FileAssociationModel[] fam = new FileAssociationModel[]{
                                        ResourcesUtil.GetFileAssociationProjectDesignerModel(),
                                        ResourcesUtil.GetFileAssociationBatchFileModel(),
                                    };

            foreach(FileAssociationModel f in fam)
            {
                if(!RegistryValueExists(REGISTRY_ROOT_TYPE.HKCU, GenerateSoftwareClassesPath(f.ProgId), null)){
                    return false;
                }
            }

            return true;
        }

        private static bool SetAssociation(FileAssociationModel faMdl)
        {
            bool madeChanges = false;
            madeChanges |= SetKeyDefaultValue(GenerateSoftwareClassesPath(faMdl.Extension), faMdl.ProgId);
            madeChanges |= SetKeyDefaultValue(GenerateSoftwareClassesPath(faMdl.ProgId), faMdl.FileTypeDescription);
            madeChanges |= SetKeyDefaultValue(GenerateShellOpenCommandPath(faMdl.ProgId), "\"" + faMdl.ExecutableFilePath + "\" \"%1\"");
            madeChanges |= SetKeyDefaultValue(GenerateDefaultIconCommandPath(faMdl.ProgId), faMdl.DefaultIconFilePath);
            return madeChanges;
        }

        private static String GenerateSoftwareClassesPath(String pathEnd)
        {
            return String.Format(@"Software\Classes\{0}", pathEnd);
        }

        private static String GenerateShellOpenCommandPath(String programId)
        {
            return String.Format(@"Software\Classes\{0}\shell\open\command", programId);
        }

        private static String GenerateDefaultIconCommandPath(String programId)
        {
            return String.Format(@"Software\Classes\{0}\DefaultIcon", programId);
        }

        private static bool SetKeyDefaultValue(string keyPath, string value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key.GetValue(null) as string != value)
                {
                    key.SetValue(null, value);
                    return true;
                }
            }

            return false;
        }

        private static bool RegistryValueExists(REGISTRY_ROOT_TYPE hive_HKLM_or_HKCU, string registryRoot, string valueName)
        {
            RegistryKey root;
            switch (hive_HKLM_or_HKCU.ToString().ToUpper())
            {
                case "HKLM":
                    root = Registry.LocalMachine.OpenSubKey(registryRoot, false);
                    break;
                case "HKCU":
                    root = Registry.CurrentUser.OpenSubKey(registryRoot, false);
                    break;
                default:
                    throw new System.InvalidOperationException("parameter registryRoot must be either \"HKLM\" or \"HKCU\"");
            }

            if (root == null) return false;

            return root.GetValue(valueName) != null;
        }
    }
}
