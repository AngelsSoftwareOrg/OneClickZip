using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OneClickZip
{
    public partial class Main : Form
    {
        ZipDesigner zipDesignerForm = null;

        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zipDesignerForm = new ZipDesigner();
            zipDesignerForm.Show();
            this.Hide();
            zipDesignerForm.FormClosed += delegate
            {
                this.Show();
                zipDesignerForm = null;
            };
        }


    }
}
