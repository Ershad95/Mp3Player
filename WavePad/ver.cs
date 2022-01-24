using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WavePad
{
    public partial class ver : Form
    {
        public ver()
        {
            InitializeComponent();
        }

       
        private void buttonX1_Click(object sender, EventArgs e)
        {
            ver v = new ver();
            
            v.Close();
        }
    }
}
