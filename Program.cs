﻿using System;
using System.Windows.Forms;

namespace OneClickZip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            Application.Run(new ZipDesigner());
            //Application.Run(new HelloWorld());

        }
    }
}
