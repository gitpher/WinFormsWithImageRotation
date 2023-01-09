using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWithImageRotation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            ImageRotationForm imageRotationForm = new ImageRotationForm
            {
                MinimumSize = new System.Drawing.Size(765, 537)
            };

            Application.Run(imageRotationForm);
        }
    }
}