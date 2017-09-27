using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftIDE
{
    public partial class Form3 : Form
    {
        IniFile MyIni;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MyIni = new IniFile("Settings.ini");
            locationBox.Text = MyIni.Read("CompilerLocation");
            switch (MyIni.Read("TargetVersion"))
            {
                case "3": rad_sw3.Checked = true; break;
                case "4": rad_sw4.Checked = true; break;
                default: break;
            }

            optParamsTxt.Text = MyIni.Read("OptParamList");
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            compilerBrowser.Filter = "Swift Compiler (swiftc.exe)|swiftc.exe";
            if (compilerBrowser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (compilerBrowser.OpenFile() != null)
                    {
                        locationBox.Text = compilerBrowser.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void can_btn_Click(object sender, EventArgs e)
        {
           Hide();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            MyIni.Write("CompilerLocation", locationBox.Text);
            string chekedver = "3";
            if (rad_sw3.Checked)
            {
                chekedver = "3";
            }
            else if (rad_sw4.Checked)
            {
                chekedver = "4";
            }
            MyIni.Write("TargetVersion", chekedver);
            MyIni.Write("OptParamList", optParamsTxt.Text);
            Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void allParamsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "CompilerHelp.txt";
            p.Start();
        }
    }
}
