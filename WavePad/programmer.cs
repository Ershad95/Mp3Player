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
    public partial class programmer : Form
    {
        public programmer()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            programmer p = new programmer();
            p.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
