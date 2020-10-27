using OneClickZip.Forms.Help;
using OneClickZip.Forms.Loading;
using OneClickZip.Forms.Options;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Models;
using System;
using System.Windows.Forms;

namespace OneClickZip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationArgumentModel applicationArgumentModel = new ApplicationArgumentModel(args);
            ProjectSession.Instance().ApplicationArgumentModel = applicationArgumentModel;

            if (applicationArgumentModel.IsOpenProjectBatchFile)
            {
                SplashScreenDesignerFrm.GetIntance().Show();
                Application.Run(new OneClickProcessorFrm());
            }
            else
            {
                Application.Run(new ZipDesigner());
            }
        }
    }
}
