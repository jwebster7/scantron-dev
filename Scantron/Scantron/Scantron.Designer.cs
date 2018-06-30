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
            this.uxNumberOfQuestions = new System.Windows.Forms.TextBox();
            this.uxEnter = new System.Windows.Forms.Button();
            this.uxCreateAnswerKey = new System.Windows.Forms.Button();
            this.Grade = new System.Windows.Forms.Button();
            this.uxStudentAnswerPanel = new System.Windows.Forms.Panel();
            this.uxStudentSelector = new System.Windows.Forms.ComboBox();
            this.uxMainPanel.SuspendLayout();
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
            this.uxAnswerKeyPanel.Location = new System.Drawing.Point(586, 0);
            this.uxAnswerKeyPanel.Name = "uxAnswerKeyPanel";
            this.uxAnswerKeyPanel.Size = new System.Drawing.Size(312, 349);
            this.uxAnswerKeyPanel.TabIndex = 10;
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(586, 355);
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(100, 20);
            this.uxNumberOfQuestions.TabIndex = 11;
            // 
            // uxEnter
            // 
            this.uxEnter.Location = new System.Drawing.Point(586, 381);
            this.uxEnter.Name = "uxEnter";
            this.uxEnter.Size = new System.Drawing.Size(75, 23);
            this.uxEnter.TabIndex = 12;
            this.uxEnter.Text = "Enter";
            this.uxEnter.UseVisualStyleBackColor = true;
            this.uxEnter.Click += new System.EventHandler(this.uxEnter_Click);
            // 
            // uxCreateAnswerKey
            // 
            this.uxCreateAnswerKey.Location = new System.Drawing.Point(586, 410);
            this.uxCreateAnswerKey.Name = "uxCreateAnswerKey";
            this.uxCreateAnswerKey.Size = new System.Drawing.Size(75, 39);
            this.uxCreateAnswerKey.TabIndex = 13;
            this.uxCreateAnswerKey.Text = "Create Answer Key";
            this.uxCreateAnswerKey.UseVisualStyleBackColor = true;
            this.uxCreateAnswerKey.Click += new System.EventHandler(this.uxCreateAnswerKey_Click);
            // 
            // Grade
            // 
            this.Grade.Location = new System.Drawing.Point(586, 455);
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(75, 23);
            this.Grade.TabIndex = 14;
            this.Grade.Text = "Grade";
            this.Grade.UseVisualStyleBackColor = true;
            this.Grade.Click += new System.EventHandler(this.Grade_Click);
            // 
            // uxStudentAnswerPanel
            // 
            this.uxStudentAnswerPanel.AutoScroll = true;
            this.uxStudentAnswerPanel.Location = new System.Drawing.Point(904, 0);
            this.uxStudentAnswerPanel.Name = "uxStudentAnswerPanel";
            this.uxStudentAnswerPanel.Size = new System.Drawing.Size(312, 349);
            this.uxStudentAnswerPanel.TabIndex = 15;
            // 
            // uxStudentSelector
            // 
            this.uxStudentSelector.FormattingEnabled = true;
            this.uxStudentSelector.Location = new System.Drawing.Point(904, 355);
            this.uxStudentSelector.Name = "uxStudentSelector";
            this.uxStudentSelector.Size = new System.Drawing.Size(153, 21);
            this.uxStudentSelector.TabIndex = 16;
            this.uxStudentSelector.Text = "Choose Student...";
            this.uxStudentSelector.SelectedIndexChanged += new System.EventHandler(this.uxStudentSelector_SelectedIndexChanged);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1256, 668);
            this.Controls.Add(this.uxStudentSelector);
            this.Controls.Add(this.uxStudentAnswerPanel);
            this.Controls.Add(this.Grade);
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
        private System.Windows.Forms.TextBox uxNumberOfQuestions;
        private System.Windows.Forms.Button uxEnter;
        private System.Windows.Forms.Button uxCreateAnswerKey;
        private System.Windows.Forms.Button Grade;
        private System.Windows.Forms.Panel uxStudentAnswerPanel;
        private System.Windows.Forms.ComboBox uxStudentSelector;
    }
}

