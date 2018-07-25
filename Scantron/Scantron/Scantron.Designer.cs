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
            this.uxEnter = new System.Windows.Forms.Button();
            this.uxCreateAnswerKey = new System.Windows.Forms.Button();
            this.Grade = new System.Windows.Forms.Button();
            this.uxStudentResponsePanel = new System.Windows.Forms.Panel();
            this.uxStudentSelector = new System.Windows.Forms.ComboBox();
            this.uxMainTabControl = new System.Windows.Forms.TabControl();
            this.uxScanTab = new System.Windows.Forms.TabPage();
            this.uxGradeTab = new System.Windows.Forms.TabPage();
            this.uxVersionLabel = new System.Windows.Forms.Label();
            this.uxNumberOfQuestions = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfQuestionsLabel = new System.Windows.Forms.Label();
            this.uxAnswerKeyTabControl = new System.Windows.Forms.TabControl();
            this.uxVersion1Tab = new System.Windows.Forms.TabPage();
            this.uxVersion2Tab = new System.Windows.Forms.TabPage();
            this.uxVersion3Tab = new System.Windows.Forms.TabPage();
            this.uxPreviousStudent = new System.Windows.Forms.Button();
            this.uxNextStudent = new System.Windows.Forms.Button();
            this.uxStudentResponseLabel = new System.Windows.Forms.Label();
            this.uxNumberOfVersions = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfVersionsLabel = new System.Windows.Forms.Label();
            this.uxAnswerKeyLabel = new System.Windows.Forms.Label();
            this.uxAllQuestionPoints = new System.Windows.Forms.NumericUpDown();
            this.uxAllQuestionPointsLabel = new System.Windows.Forms.Label();
            this.uxAllPartialCredit = new System.Windows.Forms.CheckBox();
            this.uxMainTabControl.SuspendLayout();
            this.uxScanTab.SuspendLayout();
            this.uxGradeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).BeginInit();
            this.uxAnswerKeyTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).BeginInit();
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
            this.uxInstructionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
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
            // uxEnter
            // 
            this.uxEnter.Location = new System.Drawing.Point(212, 369);
            this.uxEnter.Name = "uxEnter";
            this.uxEnter.Size = new System.Drawing.Size(75, 23);
            this.uxEnter.TabIndex = 12;
            this.uxEnter.Text = "Enter";
            this.uxEnter.UseVisualStyleBackColor = true;
            this.uxEnter.Click += new System.EventHandler(this.uxEnter_Click);
            // 
            // uxCreateAnswerKey
            // 
            this.uxCreateAnswerKey.Location = new System.Drawing.Point(293, 369);
            this.uxCreateAnswerKey.Name = "uxCreateAnswerKey";
            this.uxCreateAnswerKey.Size = new System.Drawing.Size(75, 39);
            this.uxCreateAnswerKey.TabIndex = 13;
            this.uxCreateAnswerKey.Text = "Create Answer Key";
            this.uxCreateAnswerKey.UseVisualStyleBackColor = true;
            this.uxCreateAnswerKey.Click += new System.EventHandler(this.uxCreateAnswerKey_Click);
            // 
            // Grade
            // 
            this.Grade.Location = new System.Drawing.Point(374, 369);
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
            this.uxStudentSelector.DisplayMember = "Student";
            this.uxStudentSelector.FormattingEnabled = true;
            this.uxStudentSelector.Location = new System.Drawing.Point(624, 366);
            this.uxStudentSelector.Name = "uxStudentSelector";
            this.uxStudentSelector.Size = new System.Drawing.Size(193, 21);
            this.uxStudentSelector.TabIndex = 16;
            this.uxStudentSelector.Text = "Choose Student...";
            this.uxStudentSelector.SelectedIndexChanged += new System.EventHandler(this.uxStudentSelector_SelectedIndexChanged);
            // 
            // uxMainTabControl
            // 
            this.uxMainTabControl.Controls.Add(this.uxScanTab);
            this.uxMainTabControl.Controls.Add(this.uxGradeTab);
            this.uxMainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxMainTabControl.HotTrack = true;
            this.uxMainTabControl.ItemSize = new System.Drawing.Size(150, 50);
            this.uxMainTabControl.Location = new System.Drawing.Point(0, 0);
            this.uxMainTabControl.Name = "uxMainTabControl";
            this.uxMainTabControl.SelectedIndex = 0;
            this.uxMainTabControl.Size = new System.Drawing.Size(1101, 588);
            this.uxMainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uxMainTabControl.TabIndex = 9;
            // 
            // uxScanTab
            // 
            this.uxScanTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxScanTab.Controls.Add(this.uxStart);
            this.uxScanTab.Controls.Add(this.uxStop);
            this.uxScanTab.Controls.Add(this.uxRestart);
            this.uxScanTab.Controls.Add(this.uxInstructionBox);
            this.uxScanTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uxScanTab.Location = new System.Drawing.Point(4, 54);
            this.uxScanTab.Name = "uxScanTab";
            this.uxScanTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxScanTab.Size = new System.Drawing.Size(1093, 530);
            this.uxScanTab.TabIndex = 0;
            this.uxScanTab.Text = "Scan";
            // 
            // uxGradeTab
            // 
            this.uxGradeTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxGradeTab.Controls.Add(this.uxAllPartialCredit);
            this.uxGradeTab.Controls.Add(this.uxAllQuestionPointsLabel);
            this.uxGradeTab.Controls.Add(this.uxAllQuestionPoints);
            this.uxGradeTab.Controls.Add(this.uxVersionLabel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfQuestions);
            this.uxGradeTab.Controls.Add(this.uxNumberOfQuestionsLabel);
            this.uxGradeTab.Controls.Add(this.uxAnswerKeyTabControl);
            this.uxGradeTab.Controls.Add(this.uxPreviousStudent);
            this.uxGradeTab.Controls.Add(this.uxNextStudent);
            this.uxGradeTab.Controls.Add(this.uxStudentResponseLabel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfVersions);
            this.uxGradeTab.Controls.Add(this.uxStudentResponsePanel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfVersionsLabel);
            this.uxGradeTab.Controls.Add(this.uxStudentSelector);
            this.uxGradeTab.Controls.Add(this.uxAnswerKeyLabel);
            this.uxGradeTab.Controls.Add(this.uxCreateAnswerKey);
            this.uxGradeTab.Controls.Add(this.Grade);
            this.uxGradeTab.Controls.Add(this.uxEnter);
            this.uxGradeTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uxGradeTab.Location = new System.Drawing.Point(4, 54);
            this.uxGradeTab.Name = "uxGradeTab";
            this.uxGradeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxGradeTab.Size = new System.Drawing.Size(1093, 530);
            this.uxGradeTab.TabIndex = 1;
            this.uxGradeTab.Text = "Grade";
            // 
            // uxVersionLabel
            // 
            this.uxVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxVersionLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxVersionLabel.Location = new System.Drawing.Point(624, 390);
            this.uxVersionLabel.Name = "uxVersionLabel";
            this.uxVersionLabel.Size = new System.Drawing.Size(73, 20);
            this.uxVersionLabel.TabIndex = 25;
            this.uxVersionLabel.Text = "Version: ";
            this.uxVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(157, 369);
            this.uxNumberOfQuestions.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.uxNumberOfQuestions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(49, 20);
            this.uxNumberOfQuestions.TabIndex = 24;
            this.uxNumberOfQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfQuestions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxNumberOfQuestionsLabel
            // 
            this.uxNumberOfQuestionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNumberOfQuestionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfQuestionsLabel.Location = new System.Drawing.Point(8, 367);
            this.uxNumberOfQuestionsLabel.Name = "uxNumberOfQuestionsLabel";
            this.uxNumberOfQuestionsLabel.Size = new System.Drawing.Size(143, 20);
            this.uxNumberOfQuestionsLabel.TabIndex = 23;
            this.uxNumberOfQuestionsLabel.Text = "Number of Questions:";
            this.uxNumberOfQuestionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAnswerKeyTabControl
            // 
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion1Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion2Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion3Tab);
            this.uxAnswerKeyTabControl.Location = new System.Drawing.Point(0, 30);
            this.uxAnswerKeyTabControl.Name = "uxAnswerKeyTabControl";
            this.uxAnswerKeyTabControl.SelectedIndex = 0;
            this.uxAnswerKeyTabControl.Size = new System.Drawing.Size(490, 331);
            this.uxAnswerKeyTabControl.TabIndex = 22;
            // 
            // uxVersion1Tab
            // 
            this.uxVersion1Tab.AutoScroll = true;
            this.uxVersion1Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion1Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion1Tab.Name = "uxVersion1Tab";
            this.uxVersion1Tab.Padding = new System.Windows.Forms.Padding(3);
            this.uxVersion1Tab.Size = new System.Drawing.Size(482, 305);
            this.uxVersion1Tab.TabIndex = 0;
            this.uxVersion1Tab.Text = "Version 1";
            // 
            // uxVersion2Tab
            // 
            this.uxVersion2Tab.AutoScroll = true;
            this.uxVersion2Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion2Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion2Tab.Name = "uxVersion2Tab";
            this.uxVersion2Tab.Padding = new System.Windows.Forms.Padding(3);
            this.uxVersion2Tab.Size = new System.Drawing.Size(482, 305);
            this.uxVersion2Tab.TabIndex = 1;
            this.uxVersion2Tab.Text = "Version 2";
            // 
            // uxVersion3Tab
            // 
            this.uxVersion3Tab.AutoScroll = true;
            this.uxVersion3Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion3Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion3Tab.Name = "uxVersion3Tab";
            this.uxVersion3Tab.Size = new System.Drawing.Size(482, 305);
            this.uxVersion3Tab.TabIndex = 2;
            this.uxVersion3Tab.Text = "Version 3";
            // 
            // uxPreviousStudent
            // 
            this.uxPreviousStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxPreviousStudent.Location = new System.Drawing.Point(518, 366);
            this.uxPreviousStudent.Name = "uxPreviousStudent";
            this.uxPreviousStudent.Size = new System.Drawing.Size(100, 40);
            this.uxPreviousStudent.TabIndex = 21;
            this.uxPreviousStudent.Text = "Previous";
            this.uxPreviousStudent.UseVisualStyleBackColor = true;
            this.uxPreviousStudent.Click += new System.EventHandler(this.uxPreviousStudent_Click);
            // 
            // uxNextStudent
            // 
            this.uxNextStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNextStudent.Location = new System.Drawing.Point(823, 367);
            this.uxNextStudent.Name = "uxNextStudent";
            this.uxNextStudent.Size = new System.Drawing.Size(100, 40);
            this.uxNextStudent.TabIndex = 10;
            this.uxNextStudent.Text = "Next";
            this.uxNextStudent.UseVisualStyleBackColor = true;
            this.uxNextStudent.Click += new System.EventHandler(this.uxNextStudent_Click);
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
            // uxNumberOfVersions
            // 
            this.uxNumberOfVersions.Location = new System.Drawing.Point(157, 395);
            this.uxNumberOfVersions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxNumberOfVersions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumberOfVersions.Name = "uxNumberOfVersions";
            this.uxNumberOfVersions.Size = new System.Drawing.Size(49, 20);
            this.uxNumberOfVersions.TabIndex = 20;
            this.uxNumberOfVersions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfVersions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxNumberOfVersionsLabel
            // 
            this.uxNumberOfVersionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNumberOfVersionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfVersionsLabel.Location = new System.Drawing.Point(8, 392);
            this.uxNumberOfVersionsLabel.Name = "uxNumberOfVersionsLabel";
            this.uxNumberOfVersionsLabel.Size = new System.Drawing.Size(126, 20);
            this.uxNumberOfVersionsLabel.TabIndex = 19;
            this.uxNumberOfVersionsLabel.Text = "Number of Versions:";
            this.uxNumberOfVersionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // uxAllQuestionPoints
            // 
            this.uxAllQuestionPoints.DecimalPlaces = 2;
            this.uxAllQuestionPoints.Location = new System.Drawing.Point(274, 20);
            this.uxAllQuestionPoints.Name = "uxAllQuestionPoints";
            this.uxAllQuestionPoints.Size = new System.Drawing.Size(60, 20);
            this.uxAllQuestionPoints.TabIndex = 26;
            this.uxAllQuestionPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxAllQuestionPoints.ValueChanged += new System.EventHandler(this.uxAllQuestionPoints_ValueChanged);
            // 
            // uxAllQuestionPointsLabel
            // 
            this.uxAllQuestionPointsLabel.AutoSize = true;
            this.uxAllQuestionPointsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxAllQuestionPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAllQuestionPointsLabel.Location = new System.Drawing.Point(185, 20);
            this.uxAllQuestionPointsLabel.Name = "uxAllQuestionPointsLabel";
            this.uxAllQuestionPointsLabel.Size = new System.Drawing.Size(81, 13);
            this.uxAllQuestionPointsLabel.TabIndex = 27;
            this.uxAllQuestionPointsLabel.Text = "All Questions";
            // 
            // uxAllPartialCredit
            // 
            this.uxAllPartialCredit.AutoSize = true;
            this.uxAllPartialCredit.BackColor = System.Drawing.Color.Transparent;
            this.uxAllPartialCredit.Location = new System.Drawing.Point(337, 21);
            this.uxAllPartialCredit.Name = "uxAllPartialCredit";
            this.uxAllPartialCredit.Size = new System.Drawing.Size(99, 17);
            this.uxAllPartialCredit.TabIndex = 0;
            this.uxAllPartialCredit.Text = "All Partial Credit";
            this.uxAllPartialCredit.UseVisualStyleBackColor = false;
            this.uxAllPartialCredit.CheckedChanged += new System.EventHandler(this.uxAllPartialCredit_CheckedChanged);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1037, 643);
            this.Controls.Add(this.uxMainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
            this.uxMainTabControl.ResumeLayout(false);
            this.uxScanTab.ResumeLayout(false);
            this.uxScanTab.PerformLayout();
            this.uxGradeTab.ResumeLayout(false);
            this.uxGradeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).EndInit();
            this.uxAnswerKeyTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.TextBox uxInstructionBox;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxRestart;
        private System.Windows.Forms.Button uxEnter;
        private System.Windows.Forms.Button uxCreateAnswerKey;
        private System.Windows.Forms.Button Grade;
        private System.Windows.Forms.Panel uxStudentResponsePanel;
        private System.Windows.Forms.ComboBox uxStudentSelector;
        private System.Windows.Forms.TabControl uxMainTabControl;
        private System.Windows.Forms.TabPage uxScanTab;
        private System.Windows.Forms.TabPage uxGradeTab;
        private System.Windows.Forms.Label uxStudentResponseLabel;
        private System.Windows.Forms.Label uxAnswerKeyLabel;
        private System.Windows.Forms.NumericUpDown uxNumberOfVersions;
        private System.Windows.Forms.Label uxNumberOfVersionsLabel;
        private System.Windows.Forms.Button uxPreviousStudent;
        private System.Windows.Forms.Button uxNextStudent;
        private System.Windows.Forms.TabControl uxAnswerKeyTabControl;
        private System.Windows.Forms.TabPage uxVersion1Tab;
        private System.Windows.Forms.TabPage uxVersion2Tab;
        private System.Windows.Forms.TabPage uxVersion3Tab;
        private System.Windows.Forms.NumericUpDown uxNumberOfQuestions;
        private System.Windows.Forms.Label uxNumberOfQuestionsLabel;
        private System.Windows.Forms.Label uxVersionLabel;
        private System.Windows.Forms.NumericUpDown uxAllQuestionPoints;
        private System.Windows.Forms.CheckBox uxAllPartialCredit;
        private System.Windows.Forms.Label uxAllQuestionPointsLabel;
    }
}

