using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public static class ControlExtensions
{

    //This is to avoid flickering on Listview
    public static void DoubleBuffering(this Control control, bool enable)
    {
        var method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(control, new object[] { ControlStyles.OptimizedDoubleBuffer, enable });
    }
}