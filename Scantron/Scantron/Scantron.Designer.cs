namespace Scantron
{
    partial class Scantron
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
            this.uxStart = new System.Windows.Forms.Button();
            this.uxInstructionBox = new System.Windows.Forms.TextBox();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxCreateFile = new System.Windows.Forms.Button();
            this.uxAdmin = new System.Windows.Forms.Button();
            this.uxCanConvert = new System.Windows.Forms.Button();
            this.uxRestart = new System.Windows.Forms.Button();
            this.uxMainPanel = new System.Windows.Forms.Panel();
            this.uxAnswerKeyPanel = new System.Windows.Forms.Panel();
            this.uxQuestionPanel1 = new System.Windows.Forms.Panel();
            this.uxQuestionLabel1 = new System.Windows.Forms.Label();
            this.uxQuestionPanel1A = new System.Windows.Forms.CheckBox();
            this.uxQuestionPanel1B = new System.Windows.Forms.CheckBox();
            this.uxQuestionPanel1C = new System.Windows.Forms.CheckBox();
            this.uxQuestionPanel1D = new System.Windows.Forms.CheckBox();
            this.uxQuestionPanel1E = new System.Windows.Forms.CheckBox();
            this.uxNumberOfQuestions = new System.Windows.Forms.TextBox();
            this.uxEnter = new System.Windows.Forms.Button();
            this.uxCreateAnswerKey = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.uxMainPanel.SuspendLayout();
            this.uxAnswerKeyPanel.SuspendLayout();
            this.uxQuestionPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(3, 279);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(85, 65);
            this.uxStart.TabIndex = 0;
            this.uxStart.Tag = "";
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxInstructionBox
            // 
            this.uxInstructionBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxInstructionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxInstructionBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.uxInstructionBox.Location = new System.Drawing.Point(3, 28);
            this.uxInstructionBox.MaximumSize = new System.Drawing.Size(580, 245);
            this.uxInstructionBox.Multiline = true;
            this.uxInstructionBox.Name = "uxInstructionBox";
            this.uxInstructionBox.ReadOnly = true;
            this.uxInstructionBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxInstructionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxInstructionBox.Size = new System.Drawing.Size(578, 245);
            this.uxInstructionBox.TabIndex = 3;
            this.uxInstructionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxStop
            // 
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStop.Location = new System.Drawing.Point(94, 279);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(85, 65);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxCreateFile
            // 
            this.uxCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxCreateFile.Location = new System.Drawing.Point(185, 279);
            this.uxCreateFile.Name = "uxCreateFile";
            this.uxCreateFile.Size = new System.Drawing.Size(130, 65);
            this.uxCreateFile.TabIndex = 5;
            this.uxCreateFile.Text = "Create File (Canvas)";
            this.uxCreateFile.UseVisualStyleBackColor = true;
            this.uxCreateFile.Click += new System.EventHandler(this.uxCreateFile_Click);
            // 
            // uxAdmin
            // 
            this.uxAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxAdmin.Location = new System.Drawing.Point(3, 3);
            this.uxAdmin.Name = "uxAdmin";
            this.uxAdmin.Size = new System.Drawing.Size(53, 22);
            this.uxAdmin.TabIndex = 6;
            this.uxAdmin.Text = "Admin";
            this.uxAdmin.UseVisualStyleBackColor = true;
            this.uxAdmin.Click += new System.EventHandler(this.uxAdmin_Click);
            // 
            // uxCanConvert
            // 
            this.uxCanConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxCanConvert.Location = new System.Drawing.Point(321, 279);
            this.uxCanConvert.Name = "uxCanConvert";
            this.uxCanConvert.Size = new System.Drawing.Size(130, 65);
            this.uxCanConvert.TabIndex = 7;
            this.uxCanConvert.Text = "Create File (CanConvert)";
            this.uxCanConvert.UseVisualStyleBackColor = true;
            this.uxCanConvert.Click += new System.EventHandler(this.uxCanConvert_Click);
            // 
            // uxRestart
            // 
            this.uxRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxRestart.Location = new System.Drawing.Point(457, 279);
            this.uxRestart.Name = "uxRestart";
            this.uxRestart.Size = new System.Drawing.Size(124, 65);
            this.uxRestart.TabIndex = 8;
            this.uxRestart.Text = "Restart";
            this.uxRestart.UseVisualStyleBackColor = true;
            this.uxRestart.Click += new System.EventHandler(this.uxRestart_Click);
            // 
            // uxMainPanel
            // 
            this.uxMainPanel.Controls.Add(this.uxStart);
            this.uxMainPanel.Controls.Add(this.uxRestart);
            this.uxMainPanel.Controls.Add(this.uxInstructionBox);
            this.uxMainPanel.Controls.Add(this.uxCanConvert);
            this.uxMainPanel.Controls.Add(this.uxStop);
            this.uxMainPanel.Controls.Add(this.uxAdmin);
            this.uxMainPanel.Controls.Add(this.uxCreateFile);
            this.uxMainPanel.Location = new System.Drawing.Point(-1, 0);
            this.uxMainPanel.Name = "uxMainPanel";
            this.uxMainPanel.Size = new System.Drawing.Size(585, 349);
            this.uxMainPanel.TabIndex = 9;
            // 
            // uxAnswerKeyPanel
            // 
            this.uxAnswerKeyPanel.AutoScroll = true;
            this.uxAnswerKeyPanel.Controls.Add(this.panel1);
            this.uxAnswerKeyPanel.Controls.Add(this.uxQuestionPanel1);
            this.uxAnswerKeyPanel.Location = new System.Drawing.Point(586, 0);
            this.uxAnswerKeyPanel.Name = "uxAnswerKeyPanel";
            this.uxAnswerKeyPanel.Size = new System.Drawing.Size(334, 349);
            this.uxAnswerKeyPanel.TabIndex = 10;
            // 
            // uxQuestionPanel1
            // 
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionLabel1);
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionPanel1A);
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionPanel1B);
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionPanel1C);
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionPanel1D);
            this.uxQuestionPanel1.Controls.Add(this.uxQuestionPanel1E);
            this.uxQuestionPanel1.Location = new System.Drawing.Point(3, 3);
            this.uxQuestionPanel1.Name = "uxQuestionPanel1";
            this.uxQuestionPanel1.Size = new System.Drawing.Size(268, 22);
            this.uxQuestionPanel1.TabIndex = 0;
            this.uxQuestionPanel1.Visible = false;
            // 
            // uxQuestionLabel1
            // 
            this.uxQuestionLabel1.AutoSize = true;
            this.uxQuestionLabel1.Location = new System.Drawing.Point(3, 3);
            this.uxQuestionLabel1.Name = "uxQuestionLabel1";
            this.uxQuestionLabel1.Size = new System.Drawing.Size(64, 13);
            this.uxQuestionLabel1.TabIndex = 0;
            this.uxQuestionLabel1.Text = "Question 15";
            // 
            // uxQuestionPanel1A
            // 
            this.uxQuestionPanel1A.AutoSize = true;
            this.uxQuestionPanel1A.Location = new System.Drawing.Point(73, 3);
            this.uxQuestionPanel1A.Name = "uxQuestionPanel1A";
            this.uxQuestionPanel1A.Size = new System.Drawing.Size(33, 17);
            this.uxQuestionPanel1A.TabIndex = 1;
            this.uxQuestionPanel1A.Text = "A";
            this.uxQuestionPanel1A.UseVisualStyleBackColor = true;
            // 
            // uxQuestionPanel1B
            // 
            this.uxQuestionPanel1B.AutoSize = true;
            this.uxQuestionPanel1B.Location = new System.Drawing.Point(112, 3);
            this.uxQuestionPanel1B.Name = "uxQuestionPanel1B";
            this.uxQuestionPanel1B.Size = new System.Drawing.Size(33, 17);
            this.uxQuestionPanel1B.TabIndex = 2;
            this.uxQuestionPanel1B.Text = "B";
            this.uxQuestionPanel1B.UseVisualStyleBackColor = true;
            // 
            // uxQuestionPanel1C
            // 
            this.uxQuestionPanel1C.AutoSize = true;
            this.uxQuestionPanel1C.Location = new System.Drawing.Point(151, 3);
            this.uxQuestionPanel1C.Name = "uxQuestionPanel1C";
            this.uxQuestionPanel1C.Size = new System.Drawing.Size(33, 17);
            this.uxQuestionPanel1C.TabIndex = 3;
            this.uxQuestionPanel1C.Text = "C";
            this.uxQuestionPanel1C.UseVisualStyleBackColor = true;
            // 
            // uxQuestionPanel1D
            // 
            this.uxQuestionPanel1D.AutoSize = true;
            this.uxQuestionPanel1D.Location = new System.Drawing.Point(190, 3);
            this.uxQuestionPanel1D.Name = "uxQuestionPanel1D";
            this.uxQuestionPanel1D.Size = new System.Drawing.Size(34, 17);
            this.uxQuestionPanel1D.TabIndex = 4;
            this.uxQuestionPanel1D.Text = "D";
            this.uxQuestionPanel1D.UseVisualStyleBackColor = true;
            // 
            // uxQuestionPanel1E
            // 
            this.uxQuestionPanel1E.AutoSize = true;
            this.uxQuestionPanel1E.Location = new System.Drawing.Point(230, 3);
            this.uxQuestionPanel1E.Name = "uxQuestionPanel1E";
            this.uxQuestionPanel1E.Size = new System.Drawing.Size(33, 17);
            this.uxQuestionPanel1E.TabIndex = 5;
            this.uxQuestionPanel1E.Text = "E";
            this.uxQuestionPanel1E.UseVisualStyleBackColor = true;
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(456, 394);
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(100, 20);
            this.uxNumberOfQuestions.TabIndex = 11;
            // 
            // uxEnter
            // 
            this.uxEnter.Location = new System.Drawing.Point(456, 420);
            this.uxEnter.Name = "uxEnter";
            this.uxEnter.Size = new System.Drawing.Size(75, 23);
            this.uxEnter.TabIndex = 12;
            this.uxEnter.Text = "Enter";
            this.uxEnter.UseVisualStyleBackColor = true;
            this.uxEnter.Click += new System.EventHandler(this.uxEnter_Click);
            // 
            // uxCreateAnswerKey
            // 
            this.uxCreateAnswerKey.Location = new System.Drawing.Point(456, 449);
            this.uxCreateAnswerKey.Name = "uxCreateAnswerKey";
            this.uxCreateAnswerKey.Size = new System.Drawing.Size(75, 39);
            this.uxCreateAnswerKey.TabIndex = 13;
            this.uxCreateAnswerKey.Text = "Create Answer Key";
            this.uxCreateAnswerKey.UseVisualStyleBackColor = true;
            this.uxCreateAnswerKey.Click += new System.EventHandler(this.uxCreateAnswerKey_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 22);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question 1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(73, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(33, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "A";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(112, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(33, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "B";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(151, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(33, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "C";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(190, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(34, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "D";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(230, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(33, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "E";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1197, 668);
            this.Controls.Add(this.uxCreateAnswerKey);
            this.Controls.Add(this.uxEnter);
            this.Controls.Add(this.uxNumberOfQuestions);
            this.Controls.Add(this.uxAnswerKeyPanel);
            this.Controls.Add(this.uxMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
            this.uxMainPanel.ResumeLayout(false);
            this.uxMainPanel.PerformLayout();
            this.uxAnswerKeyPanel.ResumeLayout(false);
            this.uxQuestionPanel1.ResumeLayout(false);
            this.uxQuestionPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.TextBox uxInstructionBox;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxCreateFile;
        private System.Windows.Forms.Button uxAdmin;
        private System.Windows.Forms.Button uxCanConvert;
        private System.Windows.Forms.Button uxRestart;
        private System.Windows.Forms.Panel uxMainPanel;
        private System.Windows.Forms.Panel uxAnswerKeyPanel;
        private System.Windows.Forms.Panel uxQuestionPanel1;
        private System.Windows.Forms.CheckBox uxQuestionPanel1E;
        private System.Windows.Forms.CheckBox uxQuestionPanel1D;
        private System.Windows.Forms.CheckBox uxQuestionPanel1C;
        private System.Windows.Forms.CheckBox uxQuestionPanel1B;
        private System.Windows.Forms.CheckBox uxQuestionPanel1A;
        private System.Windows.Forms.Label uxQuestionLabel1;
        private System.Windows.Forms.TextBox uxNumberOfQuestions;
        private System.Windows.Forms.Button uxEnter;
        private System.Windows.Forms.Button uxCreateAnswerKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}

