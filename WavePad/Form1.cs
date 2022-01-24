using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WavePad
{
    public partial class Form1 : Form
    {
       
        StreamReader sr;
        StreamWriter sw;
        public string str;
        public int filter=9;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.arg_file != null)
            {
                textBox1.Text = Program.cmd_arg;
                this.Text = "Wpad\\ " + Path.GetFileName(Program.arg_file);
            }
            this.WindowState = FormWindowState.Maximized;
            textBox1.Focus();
        }
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyboardControl1.Enabled = true;
            keyboardControl1.Visible = true;
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyboardControl1.Enabled = false;
            keyboardControl1.Visible = false;
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ver v = new ver();
            v.ShowDialog();
        }

        private void programmerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programmer p = new programmer();
            p.ShowDialog();
            
        }

        private void textColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.ForeColor=colorDialog1.Color;
        }

        private void backColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("last ver : 1.0.0","version",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

           openFileDialog1.Filter = " c|*.c|c++|*.cpp|header|*.h|cs|*.cs|java|*.java|javascript|*.js|html|*.html|wpad|*.wpad|text|*.txt";
           openFileDialog1.ShowDialog();
            
           string addr= openFileDialog1.FileName;
           try
           {
               sr = new StreamReader(addr);
               string str = sr.ReadToEnd();
               textBox1.AppendText(str);
               sr.Close();
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
          

        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                string addr = folderBrowserDialog1.SelectedPath;
                string[] addr_files = Directory.GetFiles(addr);
                foreach (string item in addr_files)
                {
                    sr = new StreamReader(item);
                    textBox1.AppendText(sr.ReadToEnd());
                    textBox1.AppendText("\n\n");
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.ForeColor = colorDialog1.Color;
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
        }

           private void buttonX1_Click(object sender, EventArgs e)
           {
               openFileDialog1.Filter = " c|*.c|c++|*.cpp|header|*.h|cs|*.cs|java|*.java|javascript|*.js|html|*.html|wpad|*.wpad|text|*.txt";
               openFileDialog1.ShowDialog();

               string addr = openFileDialog1.FileName;
               try
               {
                   sr = new StreamReader(addr);
                   string str = sr.ReadToEnd();
                   textBox1.AppendText(str);
                   sr.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void buttonX2_Click(object sender, EventArgs e)
           {

               SaveFileDialog saveFileDialog1 = new SaveFileDialog();
               saveFileDialog1.Filter = " c|*.c|c++|*.cpp|header|*.h|cs|*.cs|java|*.java|javascript|*.js|html|*.html|wpad|*.wpad|text|*.txt";
               saveFileDialog1.FilterIndex = filter;
               saveFileDialog1.RestoreDirectory = true;
               try
               {
                   saveFileDialog1.ShowDialog();
                   str = saveFileDialog1.FileName;
                   sw = new StreamWriter(str);
                   sw.Write(textBox1.Text);
                   sw.Close();
               }
               catch (Exception ex)
               {

                   MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               }
           }
           private void buttonX3_Click(object sender, EventArgs e)
           {
               textBox1.Copy();
           }
           private void buttonX4_Click(object sender, EventArgs e)
           {
               textBox1.Paste();
           }

           private void exitToolStripMenuItem_Click(object sender, EventArgs e)
           {
               Application.Exit();
           }

           private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
           {
               
               SaveFileDialog saveFileDialog1 = new SaveFileDialog();
               saveFileDialog1.Filter = " c|*.c|c++|*.cpp|header|*.h|cs|*.cs|java|*.java|javascript|*.js|html|*.html|wpad|*.wpad|text|*.txt";
               saveFileDialog1.FilterIndex = filter;
               saveFileDialog1.RestoreDirectory = true;
               try
               {
                   saveFileDialog1.ShowDialog();
                   str = saveFileDialog1.FileName;
                   sw = new StreamWriter(str);
                   sw.Write(textBox1.Text);
                   sw.Close();
               }
               catch(Exception ex)
               {
 
                   MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
               }

           }

           private void headerFileToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

              
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;
               c_auto.SetAutocompleteMenu(textBox1, c_auto);
               c_header.Checked = true;
               filter = 3;
               textBox1.AppendText("//Header file for c : "+Environment.NewLine+Environment.NewLine+Environment.NewLine);
              
           }

           private void sourseFileToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;
               c_auto.SetAutocompleteMenu(textBox1, c_auto);
               c_source.Checked = true;
               filter = 1;
               textBox1.AppendText("//Source file for c" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void structToolStripMenuItem2_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
              

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               c_auto.SetAutocompleteMenu(textBox1, c_auto);
               c_struct.Checked = true;
               filter = 1;
               textBox1.AppendText("//Struct  for c : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void headerToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;
               
               cpp_auto.SetAutocompleteMenu(textBox1, cpp_auto);
              
               cpp_header.Checked = true;
               filter = 3;
               textBox1.AppendText("//Header for c++ : "+Environment.NewLine+Environment.NewLine+Environment.NewLine);
           }

           private void sourseToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               cpp_auto.SetAutocompleteMenu(textBox1, cpp_auto);
               cpp_source.Checked = true;
               filter = 2;
               textBox1.AppendText("//Source for c++ : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void classToolStripMenuItem_Click(object sender, EventArgs e)
           {
               
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               cpp_auto.SetAutocompleteMenu(textBox1, cpp_auto);
               cpp_class.Checked = true;
               filter = 3;
               textBox1.AppendText("//Class for c++ : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);
               textBox1.AppendText("class name" + Environment.NewLine + "{" + Environment.NewLine + "public :" + Environment.NewLine + Environment.NewLine + "private : " + Environment.NewLine + Environment.NewLine + "protected : " + Environment.NewLine + Environment.NewLine + "}");
              
           }

           private void interfaceToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               cpp_auto.SetAutocompleteMenu(textBox1, cpp_auto);
               cpp_interface.Checked = true;
               filter = 3;
               textBox1.AppendText("//Interface for C++ : "+ Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void structToolStripMenuItem1_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
              

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               cpp_auto.SetAutocompleteMenu(textBox1, cpp_auto);
               cpp_struct.Checked = true;
               filter = 3;
               textBox1.AppendText("//struct for C++ : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void classToolStripMenuItem1_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               
               csharp_struct.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;


               Csharp_auto.SetAutocompleteMenu(textBox1, Csharp_auto);
               csharp_class.Checked = true;
               filter = 4;
               textBox1.AppendText("//Class for Csharp : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);
               textBox1.AppendText("class name" + Environment.NewLine + "{" + Environment.NewLine + "public :" + Environment.NewLine + Environment.NewLine + "private : " + Environment.NewLine + Environment.NewLine + "protected : " + Environment.NewLine + Environment.NewLine + "}");

           }

           private void interfaceToolStripMenuItem1_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_struct.Checked = false;
               

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               Csharp_auto.SetAutocompleteMenu(textBox1, Csharp_auto);
               csharp_interface.Checked = true;
               filter = 4;
               textBox1.AppendText("//Interface for Csharp : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);

           }

           private void structToolStripMenuItem_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_interface.Checked = false;

               java_class.Checked = false;
               java_interface.Checked = false;
               java_java.Checked = false;

               Csharp_auto.SetAutocompleteMenu(textBox1, Csharp_auto);
               csharp_struct.Checked = true;
               filter = 4;
               textBox1.AppendText("Struct for Csharp : " + Environment.NewLine + Environment.NewLine + Environment.NewLine);

           }


           private void classToolStripMenuItem2_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_interface.Checked = false;
               csharp_struct.Checked = false;
               

               java_class.Checked=false;
               java_interface.Checked=false;
               
               java_auto.SetAutocompleteMenu(textBox1, java_auto);
               java_java.Checked = true;
               filter = 5;
               textBox1.AppendText("file with ext .java" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void classToolStripMenuItem3_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_interface.Checked = false;
               csharp_struct.Checked = false;
               

               java_interface.Checked = false;
               java_java.Checked = false;
               java_auto.SetAutocompleteMenu(textBox1,java_auto);
               java_class.Checked = true;
               filter = 5;
               textBox1.AppendText("//class for java...." + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void interfaceToolStripMenuItem2_Click(object sender, EventArgs e)
           {
               cpp_class.Checked = false;
               cpp_header.Checked = false;
               cpp_interface.Checked = false;
               cpp_source.Checked = false;
               cpp_struct.Checked = false;

               c_header.Checked = false;
               c_source.Checked = false;
               c_struct.Checked = false;

               csharp_class.Checked = false;
               csharp_interface.Checked = false;
               csharp_struct.Checked = false;
               

               java_java.Checked = false;
               java_class.Checked= false;
               java_auto.SetAutocompleteMenu(textBox1, java_auto);
               java_interface.Checked = true;
               filter = 5;
               textBox1.AppendText("//interface for java..." + Environment.NewLine + Environment.NewLine + Environment.NewLine);
           }

           private void textBox1_KeyDown(object sender, KeyEventArgs e)
           {
           
               if(e.KeyCode==Keys.Space && (c_header.Checked==true || c_source.Checked==true || c_struct.Checked==true))
               {
                   c_auto.Show(textBox1, true);
                   cpp_auto.Close();
                   java_auto.Close();
                   Csharp_auto.Close();
                   c_auto.Enabled = true;
                   cpp_auto.Enabled = false;
                   Csharp_auto.Enabled = false;
                   java_auto.Enabled = false;
               }
               if(e.KeyCode==Keys.Space && (cpp_class.Checked==true || cpp_header.Checked==true || cpp_interface.Checked==true || cpp_source.Checked==true || cpp_struct.Checked==true))
               {
                   cpp_auto.Show(textBox1, true);
                   c_auto.Close();
                   java_auto.Close();
                   Csharp_auto.Close();
                   c_auto.Enabled = false;
                   cpp_auto.Enabled = true;
                   Csharp_auto.Enabled = false;
                   java_auto.Enabled = false;
               }
               if(e.KeyCode==Keys.Space && (csharp_class.Checked==true || csharp_interface.Checked==true || csharp_struct.Checked==true) )
               {
                   Csharp_auto.Show(textBox1, true);
                  
                   c_auto.Close();
                   cpp_auto.Close();
                   java_auto.Close();
                   c_auto.Enabled = false;
                   cpp_auto.Enabled = false;
                   Csharp_auto.Enabled = true;
                   java_auto.Enabled = false;
               }
               if(e.KeyCode==Keys.Space && (java_java.Checked==true || java_interface.Checked==true || java_class.Checked==true))
               {
                   java_auto.Show(textBox1, true);
                   c_auto.Close();
                   cpp_auto.Close();
                   Csharp_auto.Close();
                   c_auto.Enabled = false;
                   cpp_auto.Enabled = false;
                   Csharp_auto.Enabled = false;
                   java_auto.Enabled = true;
               }
           }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            Csharp_auto.AddItem(s);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult= MessageBox.Show("Do you want save this file ???", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(DialogResult==DialogResult.Yes)
            {
                buttonX2_Click(sender, e);
            }else if(DialogResult==DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
              string[] file = (string[])  e.Data.GetData(DataFormats.FileDrop);
                sr = new StreamReader(file[0]);
                textBox1.Text =  sr.ReadToEnd();
            }
           
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           int wid_txt = this.Width-groupBox2.Width;
            textBox1.Width = wid_txt;
            keyboardControl1.Width = wid_txt;
           
        }

   

        private void theme_clk(object sender, EventArgs e)
        {
            switch(((ToolStripMenuItem)sender).Text)
            {
                case "Blue (Defult)":
                    menuStrip1.BackColor = Color.White;
                    groupBox2.BackColor = Color.DodgerBlue;
                    groupBox1.BackColor = Color.DodgerBlue;
                    this.BackColor = Color.DodgerBlue;
                    textBox1.ForeColor = Color.Black;
                    textBox1.BackColor = Color.White;
                         break;
                case "Black":
                    menuStrip1.BackColor = Color.DimGray;
                    this.BackColor = Color.Black;
                    groupBox2.BackColor = Color.Black;
                    groupBox1.BackColor = Color.Black;
                    textBox1.BackColor = Color.DarkGray;
                    textBox1.ForeColor = Color.Black;
                    break;
                case "Red":
                    menuStrip1.BackColor = Color.Yellow;
                    this.BackColor = Color.DarkRed ;
                    groupBox2.BackColor = Color.DarkRed;
                    groupBox1.BackColor = Color.DarkRed;
                    textBox1.BackColor = Color.OrangeRed;
                    textBox1.ForeColor = Color.White;
                    
                    break;
                case "Green":
                    menuStrip1.BackColor = Color.LightSeaGreen;
                    this.BackColor = Color.Green;
                    groupBox2.BackColor = Color.Green;
                    groupBox1.BackColor = Color.Green;
                    textBox1.BackColor = Color.SpringGreen;
                    textBox1.ForeColor = Color.Black;
                    break;
                case "Orange":
                    menuStrip1.BackColor = Color.Yellow;
                    this.BackColor = Color.Orange;
                    groupBox2.BackColor = Color.OrangeRed;
                    groupBox1.BackColor = Color.OrangeRed;
                    textBox1.BackColor = Color.Orange;
                    textBox1.ForeColor = Color.White;
                    break;
            }
        }

        private void contextMenuclk(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Text)
            {
                case "copy" :
                    textBox1.Copy();
                    break;
                case "select all":
                    textBox1.SelectAll();
                    break;
                case "cut":
                    textBox1.Cut();
                    break;
                case "paste":
                    textBox1.Paste();
                    break;
                    
            }
        }

        private void editMenuclk(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Text)
            {
                case "Select all":
                    textBox1.SelectAll();
                    break;
                case "Copy":
                    textBox1.Copy();
                    break;
                case "Paste":
                    textBox1.Paste();
                    break;
                case "Cut":
                    textBox1.Cut();
                    break;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}

