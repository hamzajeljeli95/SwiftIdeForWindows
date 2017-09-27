using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SwiftIDE
{
    /*
    Hello There, i know the source code may look very hard to read and/or to understand
    it needs a lot of optimizations (and a lot of new fonctionnalities also such as templates for exemple ...)
    */

    public partial class Form1 : Form
    {
        IniFile MyIni;
        String Filename;
        StreamReader sr;
        Form2 LogForm;
        Form3 SettingsForm;
        Boolean isLogFormActive;
        String exefile;

        //Newly defined Functions and procedures

        void ShowLogForm(Boolean state)
        {
            if (state)
            {
                LogForm.Show();
            }
            else
            {
                LogForm.Hide();
            }
        }

        void LoadSettings()
        {
            if (
                (!MyIni.KeyExists("CompilerLocation")) ||
                (!MyIni.KeyExists("TargetVersion")) ||
                (!MyIni.KeyExists("ShowLog")) ||
                (!MyIni.KeyExists("OptParamList"))
                )
            {
                //If no old settings found
                MyIni.Write("CompilerLocation", "swiftc.exe");
                MyIni.Write("TargetVersion", "3");
                MyIni.Write("ShowLog", "true");
                MyIni.Write("OptParamList", "-fixit-code");
                isLogFormActive = true;
                showLogItemMenu.CheckState = CheckState.Checked;
                putToLog("No previous settings found, Loading defaults ...\n");
            }
            else
            {
                //If old settings found
                if (MyIni.Read("ShowLog").Equals("true"))
                {
                    isLogFormActive = true;
                    showLogItemMenu.CheckState = CheckState.Checked;
                }
                else
                {
                    isLogFormActive = false;
                    showLogItemMenu.CheckState = CheckState.Unchecked;
                }
                putToLog("Settings Loaded !\n");
            }
        }

        void justStartProcess(string appName, string args)
        {
            Process newProcess = new Process();
            newProcess.StartInfo.FileName = appName;
            if (args != null)
            {
                newProcess.StartInfo.Arguments = args;
            }
            newProcess.Start();
        }

        int startProcessAndWait(string appName, string args)
        {
            Process newProcess = new Process();
            newProcess.StartInfo.FileName = appName;
            if (args != null)
            {
                newProcess.StartInfo.Arguments = args;
            }
            newProcess.Start();
            newProcess.WaitForExit();
            return newProcess.ExitCode;
        }

        void save()
        {
            if (Filename != null)
            {
                try
                {
                    File.Create(Filename).Close();
                    File.WriteAllText(Filename, codeTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal error : " + ex.Message + "\n");
                    putToLog("Internal error : " + ex.Message + "\n");
                }
            }
            else
            {
                Filename = saveNewFile();
                if (Filename != null)
                {
                    putToLog("File saved as " + Filename + " \n");
                    this.Text = "Swift IDE for Windows - Beta Release ( " + Filename + " )";
                }
            }

        }

        void compile()
        {
            save();
            if (Filename != null)
            {
                try
                {
                    if (exefile != null)
                    {
                        int exitcode = startProcessAndWait("cmd", "/C del " + exefile);
                        putToLog("Deleting old version completed with exit code " + exitcode + ".\n");
                    }
                }
                catch (Exception ex)
                {

                }
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = MyIni.Read("CompilerLocation");
                    String args = "-swift-version " + MyIni.Read("TargetVersion") + " \"" + Filename + "\" -o \"" + Filename.Substring(0, Filename.Length - 6) + ".exe\" " + MyIni.Read("OptParamList");
                    p.StartInfo.Arguments = args;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.UseShellExecute = false; ;
                    p.StartInfo.ErrorDialog = false;
                    putToLog("Starting command : " + MyIni.Read("CompilerLocation") + " " + args + "\n");
                    p.Start();
                    StreamReader outputReader = p.StandardOutput;
                    StreamReader errorReader = p.StandardError;
                    p.WaitForExit();
                    putToLog("Output, Errors and suggestions : \n" + outputReader.ReadToEnd() + "\n" + errorReader.ReadToEnd() + "\n");
                    putToLog("Compilated completed with exit code " + p.ExitCode + ".\n");
                    exefile = "\"" + Filename.Substring(0, Filename.Length - 6) + ".exe\"";
                }
                catch (Exception ex)
                {
                    putToLog("Info : " + ex.Message + "\n");
                }
            }
            else
            {
                putToLog("Aborted, Nothing to compile.\n");
            }
        }

        void run()
        {
            if (exefile == null)
            {
                putToLog("Nothing to run. Try Compiling the file first.\n");
            }
            else
            {
                try
                {
                    int exitcode = startProcessAndWait(exefile, null);
                    putToLog("Application exited with exit code " + exitcode + ".\n");
                }
                catch (Exception ex)
                {
                    putToLog("Info : " + ex.Message + "\n");
                }
            }
        }

        string saveNewFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Swift source code file (*.swift)|*.swift";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.Write(codeTextBox.Text);
                writer.Dispose();
                writer.Close();
                return save.FileName;
            }
            else
            {
                return null;
            }
        }

        void putToLog(string str)
        {
            LogForm.LogTextBox.AppendText(str+"\n");
        }

        //----------------------------------------

        //App Functions and procedures

        public Form1(string[] args)
        {
            InitializeComponent();
            LogForm = new Form2();
            SettingsForm = new Form3();
            //Initializing IDE
            putToLog("Initializing...");
            try
            {
                MyIni = new IniFile("Settings.ini");
                LoadSettings();
                ShowLogForm(isLogFormActive);
                putToLog("Completed !");
                //Handling files passed as ARGS
                if (args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (i == 0)
                        {
                            Filename = args[i].ToString();
                            sr = new StreamReader(Filename);
                            codeTextBox.Text = sr.ReadToEnd();
                            sr.Close();
                            sr.Dispose();
                            this.Text = "Swift IDE for Windows - Beta Release ( " + Filename + " )";
                            exefile = null;
                        }
                        else
                        {
                            justStartProcess(Application.ExecutablePath, args[i].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while initializing Swift IDE, Possible Solutions :\n- Restart the IDE.\n- Delete Settings.ini (It will be regenerated later with default settings).\n** If the problem persists, contact Swift IDE Dev. Team . **");
                putToLog("Error while initializing Swift IDE, Possible Solutions :\n- Restart the IDE.\n- Delete Settings.ini (It will be regenerated later with default settings).\n** If the problem persists, contact Swift IDE Dev. Team . **");
                putToLog("Reason : " + ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developped by Jeljeli Hamza\nSwift IDE for Windows - Beta Release");
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (codeTextBox.CanRedo)
            {
                redoToolStripMenuItem.Enabled = true;
            }
            else
            {
                redoToolStripMenuItem.Enabled = false;
            }

            if (codeTextBox.CanUndo)
            {
                undoToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.Paste();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileBrowser.Filter = "Swift source code files (*.swift)|*.swift"; //|All files (*.*)|*.*
            if (openFileBrowser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileBrowser.OpenFile()) != null)
                    {
                        Filename = openFileBrowser.FileName;
                        sr = new StreamReader(Filename);
                        codeTextBox.Text = sr.ReadToEnd();
                        sr.Close();
                        sr.Dispose();
                        myStream.Close();
                        this.Text = "Swift IDE for Windows - Beta Release ( " + Filename + " )";
                        exefile = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    putToLog("Error: Could not read file from disk. Original error: " + ex.Message + "\n");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            justStartProcess(Application.ExecutablePath, null);
        }

        private void showLogItemMenu_Click(object sender, EventArgs e)
        {
            if (showLogItemMenu.Checked)
            {
                MyIni.Write("ShowLog", "true");
                isLogFormActive = true;
            }
            else
            {
                MyIni.Write("ShowLog", "false");
                isLogFormActive = false;
            }
            ShowLogForm(isLogFormActive);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeTextBox.Redo();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filename = saveNewFile();
            if (Filename != null)
            {
                putToLog("File saved as " + Filename + " \n");
                this.Text = "Swift IDE for Windows - Beta Release ( " + Filename + " )";
            }
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compile();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run();
        }

        private void compileAndRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compile();
            run();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm.LogTextBox.Text = "";
        }
    }
}
