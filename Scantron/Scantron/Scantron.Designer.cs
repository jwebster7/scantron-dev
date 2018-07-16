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
            this.uxRestart = new System.Windows.Forms.Button();
            this.uxAnswerKeyPanel = new System.Windows.Forms.Panel();
            this.uxNumberOfQuestions = new System.Windows.Forms.TextBox();
            this.uxEnter = new System.Windows.Forms.Button();
            this.uxCreateAnswerKey = new System.Windows.Forms.Button();
            this.Grade = new System.Windows.Forms.Button();
            this.uxStudentResponsePanel = new System.Windows.Forms.Panel();
            this.uxStudentSelector = new System.Windows.Forms.ComboBox();
            this.uxTabControl = new System.Windows.Forms.TabControl();
            this.ScanTab = new System.Windows.Forms.TabPage();
            this.GradeTab = new System.Windows.Forms.TabPage();
            this.uxStudentPrevious = new System.Windows.Forms.Button();
            this.uxStudentNext = new System.Windows.Forms.Button();
            this.uxStudentResponseLabel = new System.Windows.Forms.Label();
            this.uxVersionNumber = new System.Windows.Forms.NumericUpDown();
            this.uxVersionLabel = new System.Windows.Forms.Label();
            this.uxAnswerKeyLabel = new System.Windows.Forms.Label();
            this.uxTabControl.SuspendLayout();
            this.ScanTab.SuspendLayout();
            this.GradeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxVersionNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(3, 254);
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
            this.uxInstructionBox.Location = new System.Drawing.Point(3, 3);
            this.uxInstructionBox.MaximumSize = new System.Drawing.Size(580, 245);
            this.uxInstructionBox.Multiline = true;
            this.uxInstructionBox.Name = "uxInstructionBox";
            this.uxInstructionBox.ReadOnly = true;
            this.uxInstructionBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxInstructionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxInstructionBox.Size = new System.Drawing.Size(580, 245);
            this.uxInstructionBox.TabIndex = 3;
            this.uxInstructionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxStop
            // 
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStop.Location = new System.Drawing.Point(94, 254);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(85, 65);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxRestart
            // 
            this.uxRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxRestart.Location = new System.Drawing.Point(185, 254);
            this.uxRestart.Name = "uxRestart";
            this.uxRestart.Size = new System.Drawing.Size(124, 65);
            this.uxRestart.TabIndex = 8;
            this.uxRestart.Text = "Restart";
            this.uxRestart.UseVisualStyleBackColor = true;
            this.uxRestart.Click += new System.EventHandler(this.uxRestart_Click);
            // 
            // uxAnswerKeyPanel
            // 
            this.uxAnswerKeyPanel.AutoScroll = true;
            this.uxAnswerKeyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.uxAnswerKeyPanel.Location = new System.Drawing.Point(3, 30);
            this.uxAnswerKeyPanel.Name = "uxAnswerKeyPanel";
            this.uxAnswerKeyPanel.Size = new System.Drawing.Size(475, 330);
            this.uxAnswerKeyPanel.TabIndex = 10;
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(8, 366);
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(100, 20);
            this.uxNumberOfQuestions.TabIndex = 11;
            // 
            // uxEnter
            // 
            this.uxEnter.Location = new System.Drawing.Point(8, 399);
            this.uxEnter.Name = "uxEnter";
            this.uxEnter.Size = new System.Drawing.Size(75, 23);
            this.uxEnter.TabIndex = 12;
            this.uxEnter.Text = "Enter";
            this.uxEnter.UseVisualStyleBackColor = true;
            this.uxEnter.Click += new System.EventHandler(this.uxEnter_Click);
            // 
            // uxCreateAnswerKey
            // 
            this.uxCreateAnswerKey.Location = new System.Drawing.Point(8, 428);
            this.uxCreateAnswerKey.Name = "uxCreateAnswerKey";
            this.uxCreateAnswerKey.Size = new System.Drawing.Size(75, 39);
            this.uxCreateAnswerKey.TabIndex = 13;
            this.uxCreateAnswerKey.Text = "Create Answer Key";
            this.uxCreateAnswerKey.UseVisualStyleBackColor = true;
            this.uxCreateAnswerKey.Click += new System.EventHandler(this.uxCreateAnswerKey_Click);
            // 
            // Grade
            // 
            this.Grade.Location = new System.Drawing.Point(8, 473);
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(75, 23);
            this.Grade.TabIndex = 14;
            this.Grade.Text = "Grade";
            this.Grade.UseVisualStyleBackColor = true;
            this.Grade.Click += new System.EventHandler(this.Grade_Click);
            // 
            // uxStudentResponsePanel
            // 
            this.uxStudentResponsePanel.AutoScroll = true;
            this.uxStudentResponsePanel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponsePanel.Location = new System.Drawing.Point(487, 30);
            this.uxStudentResponsePanel.Name = "uxStudentResponsePanel";
            this.uxStudentResponsePanel.Size = new System.Drawing.Size(475, 330);
            this.uxStudentResponsePanel.TabIndex = 15;
            // 
            // uxStudentSelector
            // 
            this.uxStudentSelector.FormattingEnabled = true;
            this.uxStudentSelector.Location = new System.Drawing.Point(487, 412);
            this.uxStudentSelector.Name = "uxStudentSelector";
            this.uxStudentSelector.Size = new System.Drawing.Size(193, 21);
            this.uxStudentSelector.TabIndex = 16;
            this.uxStudentSelector.Text = "Choose Student...";
            this.uxStudentSelector.SelectedIndexChanged += new System.EventHandler(this.uxStudentSelector_SelectedIndexChanged);
            // 
            // uxTabControl
            // 
            this.uxTabControl.Controls.Add(this.ScanTab);
            this.uxTabControl.Controls.Add(this.GradeTab);
            this.uxTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxTabControl.HotTrack = true;
            this.uxTabControl.ItemSize = new System.Drawing.Size(150, 50);
            this.uxTabControl.Location = new System.Drawing.Point(0, 0);
            this.uxTabControl.Name = "uxTabControl";
            this.uxTabControl.SelectedIndex = 0;
            this.uxTabControl.Size = new System.Drawing.Size(1101, 588);
            this.uxTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uxTabControl.TabIndex = 9;
            // 
            // ScanTab
            // 
            this.ScanTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ScanTab.Controls.Add(this.uxStart);
            this.ScanTab.Controls.Add(this.uxStop);
            this.ScanTab.Controls.Add(this.uxRestart);
            this.ScanTab.Controls.Add(this.uxInstructionBox);
            this.ScanTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ScanTab.Location = new System.Drawing.Point(4, 54);
            this.ScanTab.Name = "ScanTab";
            this.ScanTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScanTab.Size = new System.Drawing.Size(1093, 530);
            this.ScanTab.TabIndex = 0;
            this.ScanTab.Text = "Scan";
            // 
            // GradeTab
            // 
            this.GradeTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GradeTab.Controls.Add(this.uxStudentPrevious);
            this.GradeTab.Controls.Add(this.uxStudentNext);
            this.GradeTab.Controls.Add(this.uxStudentResponseLabel);
            this.GradeTab.Controls.Add(this.uxVersionNumber);
            this.GradeTab.Controls.Add(this.uxStudentResponsePanel);
            this.GradeTab.Controls.Add(this.uxVersionLabel);
            this.GradeTab.Controls.Add(this.uxStudentSelector);
            this.GradeTab.Controls.Add(this.uxAnswerKeyLabel);
            this.GradeTab.Controls.Add(this.uxNumberOfQuestions);
            this.GradeTab.Controls.Add(this.uxCreateAnswerKey);
            this.GradeTab.Controls.Add(this.Grade);
            this.GradeTab.Controls.Add(this.uxAnswerKeyPanel);
            this.GradeTab.Controls.Add(this.uxEnter);
            this.GradeTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GradeTab.Location = new System.Drawing.Point(4, 54);
            this.GradeTab.Name = "GradeTab";
            this.GradeTab.Padding = new System.Windows.Forms.Padding(3);
            this.GradeTab.Size = new System.Drawing.Size(1093, 530);
            this.GradeTab.TabIndex = 1;
            this.GradeTab.Text = "Grade";
            // 
            // uxStudentPrevious
            // 
            this.uxStudentPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxStudentPrevious.Location = new System.Drawing.Point(487, 366);
            this.uxStudentPrevious.Name = "uxStudentPrevious";
            this.uxStudentPrevious.Size = new System.Drawing.Size(100, 40);
            this.uxStudentPrevious.TabIndex = 21;
            this.uxStudentPrevious.Text = "Previous";
            this.uxStudentPrevious.UseVisualStyleBackColor = true;
            this.uxStudentPrevious.Click += new System.EventHandler(this.uxStudentPrevious_Click);
            // 
            // uxStudentNext
            // 
            this.uxStudentNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxStudentNext.Location = new System.Drawing.Point(862, 366);
            this.uxStudentNext.Name = "uxStudentNext";
            this.uxStudentNext.Size = new System.Drawing.Size(100, 40);
            this.uxStudentNext.TabIndex = 10;
            this.uxStudentNext.Text = "Next";
            this.uxStudentNext.UseVisualStyleBackColor = true;
            this.uxStudentNext.Click += new System.EventHandler(this.uxStudentNext_Click);
            // 
            // uxStudentResponseLabel
            // 
            this.uxStudentResponseLabel.AutoSize = true;
            this.uxStudentResponseLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxStudentResponseLabel.Location = new System.Drawing.Point(489, 3);
            this.uxStudentResponseLabel.Name = "uxStudentResponseLabel";
            this.uxStudentResponseLabel.Size = new System.Drawing.Size(165, 24);
            this.uxStudentResponseLabel.TabIndex = 18;
            this.uxStudentResponseLabel.Text = "Student Response";
            // 
            // uxVersionNumber
            // 
            this.uxVersionNumber.Location = new System.Drawing.Point(442, 367);
            this.uxVersionNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxVersionNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxVersionNumber.Name = "uxVersionNumber";
            this.uxVersionNumber.Size = new System.Drawing.Size(36, 20);
            this.uxVersionNumber.TabIndex = 20;
            this.uxVersionNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxVersionNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxVersionLabel
            // 
            this.uxVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxVersionLabel.Location = new System.Drawing.Point(310, 367);
            this.uxVersionLabel.Name = "uxVersionLabel";
            this.uxVersionLabel.Size = new System.Drawing.Size(126, 20);
            this.uxVersionLabel.TabIndex = 19;
            this.uxVersionLabel.Text = "Number of Versions:";
            this.uxVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxAnswerKeyLabel
            // 
            this.uxAnswerKeyLabel.AutoSize = true;
            this.uxAnswerKeyLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxAnswerKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxAnswerKeyLabel.Location = new System.Drawing.Point(3, 3);
            this.uxAnswerKeyLabel.Name = "uxAnswerKeyLabel";
            this.uxAnswerKeyLabel.Size = new System.Drawing.Size(111, 24);
            this.uxAnswerKeyLabel.TabIndex = 17;
            this.uxAnswerKeyLabel.Text = "Answer Key";
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1630, 643);
            this.Controls.Add(this.uxTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
            this.uxTabControl.ResumeLayout(false);
            this.ScanTab.ResumeLayout(false);
            this.ScanTab.PerformLayout();
            this.GradeTab.ResumeLayout(false);
            this.GradeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxVersionNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.TextBox uxInstructionBox;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxRestart;
        private System.Windows.Forms.Panel uxAnswerKeyPanel;
        private System.Windows.Forms.TextBox uxNumberOfQuestions;
        private System.Windows.Forms.Button uxEnter;
        private System.Windows.Forms.Button uxCreateAnswerKey;
        private System.Windows.Forms.Button Grade;
        private System.Windows.Forms.Panel uxStudentResponsePanel;
        private System.Windows.Forms.ComboBox uxStudentSelector;
        private System.Windows.Forms.TabControl uxTabControl;
        private System.Windows.Forms.TabPage ScanTab;
        private System.Windows.Forms.TabPage GradeTab;
        private System.Windows.Forms.Label uxStudentResponseLabel;
        private System.Windows.Forms.Label uxAnswerKeyLabel;
        private System.Windows.Forms.NumericUpDown uxVersionNumber;
        private System.Windows.Forms.Label uxVersionLabel;
        private System.Windows.Forms.Button uxStudentPrevious;
        private System.Windows.Forms.Button uxStudentNext;
    }
}

