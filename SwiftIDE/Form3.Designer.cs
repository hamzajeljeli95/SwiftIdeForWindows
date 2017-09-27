namespace SwiftIDE
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.can_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rad_sw4 = new System.Windows.Forms.RadioButton();
            this.rad_sw3 = new System.Windows.Forms.RadioButton();
            this.compilerBrowser = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optParamsTxt = new System.Windows.Forms.TextBox();
            this.allParamsList = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browse_btn);
            this.groupBox1.Controls.Add(this.locationBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compiler path";
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(200, 17);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 1;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(6, 19);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(188, 20);
            this.locationBox.TabIndex = 0;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(219, 220);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 1;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // can_btn
            // 
            this.can_btn.Location = new System.Drawing.Point(138, 220);
            this.can_btn.Name = "can_btn";
            this.can_btn.Size = new System.Drawing.Size(75, 23);
            this.can_btn.TabIndex = 2;
            this.can_btn.Text = "Cancel";
            this.can_btn.UseVisualStyleBackColor = true;
            this.can_btn.Click += new System.EventHandler(this.can_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rad_sw4);
            this.groupBox2.Controls.Add(this.rad_sw3);
            this.groupBox2.Location = new System.Drawing.Point(13, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 51);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Swift Compiling Version";
            // 
            // rad_sw4
            // 
            this.rad_sw4.AutoSize = true;
            this.rad_sw4.Location = new System.Drawing.Point(196, 20);
            this.rad_sw4.Name = "rad_sw4";
            this.rad_sw4.Size = new System.Drawing.Size(57, 17);
            this.rad_sw4.TabIndex = 2;
            this.rad_sw4.TabStop = true;
            this.rad_sw4.Text = "Swift 4";
            this.rad_sw4.UseVisualStyleBackColor = true;
            // 
            // rad_sw3
            // 
            this.rad_sw3.AutoSize = true;
            this.rad_sw3.Location = new System.Drawing.Point(6, 20);
            this.rad_sw3.Name = "rad_sw3";
            this.rad_sw3.Size = new System.Drawing.Size(57, 17);
            this.rad_sw3.TabIndex = 1;
            this.rad_sw3.TabStop = true;
            this.rad_sw3.Text = "Swift 3";
            this.rad_sw3.UseVisualStyleBackColor = true;
            // 
            // compilerBrowser
            // 
            this.compilerBrowser.FileName = "swiftc.exe";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.allParamsList);
            this.groupBox3.Controls.Add(this.optParamsTxt);
            this.groupBox3.Location = new System.Drawing.Point(13, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 76);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Optional parameters";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // optParamsTxt
            // 
            this.optParamsTxt.Location = new System.Drawing.Point(6, 20);
            this.optParamsTxt.Name = "optParamsTxt";
            this.optParamsTxt.Size = new System.Drawing.Size(269, 20);
            this.optParamsTxt.TabIndex = 0;
            // 
            // allParamsList
            // 
            this.allParamsList.AutoSize = true;
            this.allParamsList.Location = new System.Drawing.Point(159, 43);
            this.allParamsList.Name = "allParamsList";
            this.allParamsList.Size = new System.Drawing.Size(116, 13);
            this.allParamsList.TabIndex = 1;
            this.allParamsList.TabStop = true;
            this.allParamsList.Text = "Optional parameters list";
            this.allParamsList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allParamsList_LinkClicked);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 255);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.can_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button can_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rad_sw4;
        private System.Windows.Forms.RadioButton rad_sw3;
        private System.Windows.Forms.OpenFileDialog compilerBrowser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox optParamsTxt;
        private System.Windows.Forms.LinkLabel allParamsList;
    }
}