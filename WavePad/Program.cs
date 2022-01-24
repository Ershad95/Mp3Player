using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace WavePad
{
    static class Program
    {
        static internal string cmd_arg = null;
        static internal string arg_file = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (arg.Length != 0)
            {

               arg_file= arg[0];
                StreamReader strR = new StreamReader(arg_file);
                cmd_arg= strR.ReadToEnd();
               
            }
            Application.Run(new Form1());
        }
    }
}
