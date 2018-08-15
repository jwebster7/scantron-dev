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
            this.uxStop = new System.Windows.Forms.Button();
            this.uxRestart = new System.Windows.Forms.Button();
            this.uxStudentResponsePanel = new System.Windows.Forms.Panel();
            this.uxCouldNotBeGradedLabel = new System.Windows.Forms.Label();
            this.uxStudentSelector = new System.Windows.Forms.ComboBox();
            this.uxMainTabControl = new System.Windows.Forms.TabControl();
            this.uxAnswerKeyTab = new System.Windows.Forms.TabPage();
            this.uxAnswerKeyInstructionLabel = new System.Windows.Forms.Label();
            this.uxCreateAnswerKey = new System.Windows.Forms.Button();
            this.uxAnswerKeyInstructionBox = new System.Windows.Forms.Label();
            this.uxExamNameLabel = new System.Windows.Forms.Label();
            this.uxExamName = new System.Windows.Forms.TextBox();
            this.uxNumberOfVersionsLabel = new System.Windows.Forms.Label();
            this.uxNumberOfQuestionsLabel = new System.Windows.Forms.Label();
            this.uxAllPartialCredit = new System.Windows.Forms.CheckBox();
            this.uxAllQuestionPointsLabel = new System.Windows.Forms.Label();
            this.uxAllQuestionPoints = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfQuestions = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfVersions = new System.Windows.Forms.NumericUpDown();
            this.uxAnswerKeyTabControl = new System.Windows.Forms.TabControl();
            this.uxVersion1Tab = new System.Windows.Forms.TabPage();
            this.uxVersion2Tab = new System.Windows.Forms.TabPage();
            this.uxVersion3Tab = new System.Windows.Forms.TabPage();
            this.uxScanTab = new System.Windows.Forms.TabPage();
            this.uxTestData = new System.Windows.Forms.Button();
            this.uxCreateStudents = new System.Windows.Forms.Button();
            this.uxSaveChanges = new System.Windows.Forms.Button();
            this.uxCardList = new System.Windows.Forms.Panel();
            this.uxScanInstructionLabel = new System.Windows.Forms.Label();
            this.uxHorizontalDivider = new System.Windows.Forms.Label();
            this.uxGradeTab = new System.Windows.Forms.TabPage();
            this.uxGradeStudents = new System.Windows.Forms.Button();
            this.uxScoreLabel = new System.Windows.Forms.Label();
            this.uxGradeInstructionLabel = new System.Windows.Forms.Label();
            this.uxHorizontalDivider2 = new System.Windows.Forms.Label();
            this.uxVersionLabel = new System.Windows.Forms.Label();
            this.uxPreviousStudent = new System.Windows.Forms.Button();
            this.uxNextStudent = new System.Windows.Forms.Button();
            this.uxStudentResponseLabel = new System.Windows.Forms.Label();
            this.uxPause = new System.Windows.Forms.Button();
            this.uxResume = new System.Windows.Forms.Button();
            this.uxMainTabControl.SuspendLayout();
            this.uxAnswerKeyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).BeginInit();
            this.uxAnswerKeyTabControl.SuspendLayout();
            this.uxScanTab.SuspendLayout();
            this.uxGradeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(9, 226);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(85, 65);
            this.uxStart.TabIndex = 0;
            this.uxStart.Tag = "";
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = false;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxStop
            // 
            this.uxStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStop.Location = new System.Drawing.Point(9, 297);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(85, 65);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = false;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxRestart
            // 
            this.uxRestart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxRestart.Location = new System.Drawing.Point(181, 466);
            this.uxRestart.Name = "uxRestart";
            this.uxRestart.Size = new System.Drawing.Size(124, 65);
            this.uxRestart.TabIndex = 8;
            this.uxRestart.Text = "Restart";
            this.uxRestart.UseVisualStyleBackColor = false;
            this.uxRestart.Click += new System.EventHandler(this.uxRestart_Click);
            // 
            // uxStudentResponsePanel
            // 
            this.uxStudentResponsePanel.AutoScroll = true;
            this.uxStudentResponsePanel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponsePanel.Location = new System.Drawing.Point(405, 227);
            this.uxStudentResponsePanel.Name = "uxStudentResponsePanel";
            this.uxStudentResponsePanel.Size = new System.Drawing.Size(475, 369);
            this.uxStudentResponsePanel.TabIndex = 15;
            // 
            // uxCouldNotBeGradedLabel
            // 
            this.uxCouldNotBeGradedLabel.AutoSize = true;
            this.uxCouldNotBeGradedLabel.BackColor = System.Drawing.Color.Red;
            this.uxCouldNotBeGradedLabel.Location = new System.Drawing.Point(107, 307);
            this.uxCouldNotBeGradedLabel.Name = "uxCouldNotBeGradedLabel";
            this.uxCouldNotBeGradedLabel.Size = new System.Drawing.Size(188, 13);
            this.uxCouldNotBeGradedLabel.TabIndex = 0;
            this.uxCouldNotBeGradedLabel.Text = "Student could not be graded correctly.";
            this.uxCouldNotBeGradedLabel.Visible = false;
            // 
            // uxStudentSelector
            // 
            this.uxStudentSelector.DisplayMember = "Student";
            this.uxStudentSelector.FormattingEnabled = true;
            this.uxStudentSelector.ItemHeight = 13;
            this.uxStudentSelector.Location = new System.Drawing.Point(110, 281);
            this.uxStudentSelector.Name = "uxStudentSelector";
            this.uxStudentSelector.Size = new System.Drawing.Size(193, 21);
            this.uxStudentSelector.TabIndex = 16;
            this.uxStudentSelector.Text = "Choose Student...";
            this.uxStudentSelector.SelectedIndexChanged += new System.EventHandler(this.uxStudentSelector_SelectedIndexChanged);
            // 
            // uxMainTabControl
            // 
            this.uxMainTabControl.Controls.Add(this.uxAnswerKeyTab);
            this.uxMainTabControl.Controls.Add(this.uxScanTab);
            this.uxMainTabControl.Controls.Add(this.uxGradeTab);
            this.uxMainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMainTabControl.HotTrack = true;
            this.uxMainTabControl.ItemSize = new System.Drawing.Size(250, 30);
            this.uxMainTabControl.Location = new System.Drawing.Point(-6, 0);
            this.uxMainTabControl.Name = "uxMainTabControl";
            this.uxMainTabControl.SelectedIndex = 0;
            this.uxMainTabControl.Size = new System.Drawing.Size(897, 649);
            this.uxMainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uxMainTabControl.TabIndex = 9;
            // 
            // uxAnswerKeyTab
            // 
            this.uxAnswerKeyTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxAnswerKeyTab.Controls.Add(this.uxCreateAnswerKey);
            this.uxAnswerKeyTab.Controls.Add(this.uxAnswerKeyInstructionLabel);
            this.uxAnswerKeyTab.Controls.Add(this.uxExamNameLabel);
            this.uxAnswerKeyTab.Controls.Add(this.uxExamName);
            this.uxAnswerKeyTab.Controls.Add(this.uxNumberOfVersionsLabel);
            this.uxAnswerKeyTab.Controls.Add(this.uxNumberOfQuestionsLabel);
            this.uxAnswerKeyTab.Controls.Add(this.uxAllPartialCredit);
            this.uxAnswerKeyTab.Controls.Add(this.uxAllQuestionPointsLabel);
            this.uxAnswerKeyTab.Controls.Add(this.uxAllQuestionPoints);
            this.uxAnswerKeyTab.Controls.Add(this.uxNumberOfQuestions);
            this.uxAnswerKeyTab.Controls.Add(this.uxNumberOfVersions);
            this.uxAnswerKeyTab.Controls.Add(this.uxAnswerKeyTabControl);
            this.uxAnswerKeyTab.Location = new System.Drawing.Point(4, 34);
            this.uxAnswerKeyTab.Name = "uxAnswerKeyTab";
            this.uxAnswerKeyTab.Size = new System.Drawing.Size(889, 611);
            this.uxAnswerKeyTab.TabIndex = 2;
            this.uxAnswerKeyTab.Text = "Answer Key";
            // 
            // uxCreateAnswerKey
            // 
            this.uxCreateAnswerKey.Location = new System.Drawing.Point(17, 434);
            this.uxCreateAnswerKey.Name = "uxCreateAnswerKey";
            this.uxCreateAnswerKey.Size = new System.Drawing.Size(149, 85);
            this.uxCreateAnswerKey.TabIndex = 44;
            this.uxCreateAnswerKey.Text = "Create Answer Key";
            this.uxCreateAnswerKey.UseVisualStyleBackColor = true;
            this.uxCreateAnswerKey.Click += new System.EventHandler(this.uxCreateAnswerKey_Click);
            // 
            // uxAnswerKeyInstructionBox
            // 
            this.uxAnswerKeyInstructionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxAnswerKeyInstructionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAnswerKeyInstructionLabel.Location = new System.Drawing.Point(6, 3);
            this.uxAnswerKeyInstructionLabel.Name = "uxAnswerKeyInstructionLabel";
            this.uxAnswerKeyInstructionLabel.Size = new System.Drawing.Size(874, 189);
            this.uxAnswerKeyInstructionLabel.TabIndex = 43;
            // 
            // uxExamNameLabel
            // 
            this.uxExamNameLabel.AutoSize = true;
            this.uxExamNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxExamNameLabel.Location = new System.Drawing.Point(14, 237);
            this.uxExamNameLabel.Name = "uxExamNameLabel";
            this.uxExamNameLabel.Size = new System.Drawing.Size(77, 13);
            this.uxExamNameLabel.TabIndex = 42;
            this.uxExamNameLabel.Text = "Exam Name:";
            this.uxExamNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxExamName
            // 
            this.uxExamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxExamName.Location = new System.Drawing.Point(100, 233);
            this.uxExamName.Name = "uxExamName";
            this.uxExamName.Size = new System.Drawing.Size(170, 20);
            this.uxExamName.TabIndex = 41;
            // 
            // uxNumberOfVersionsLabel
            // 
            this.uxNumberOfVersionsLabel.AutoSize = true;
            this.uxNumberOfVersionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfVersionsLabel.Location = new System.Drawing.Point(14, 270);
            this.uxNumberOfVersionsLabel.Name = "uxNumberOfVersionsLabel";
            this.uxNumberOfVersionsLabel.Size = new System.Drawing.Size(121, 13);
            this.uxNumberOfVersionsLabel.TabIndex = 35;
            this.uxNumberOfVersionsLabel.Text = "Number of Versions:";
            this.uxNumberOfVersionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxNumberOfQuestionsLabel
            // 
            this.uxNumberOfQuestionsLabel.AutoSize = true;
            this.uxNumberOfQuestionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfQuestionsLabel.Location = new System.Drawing.Point(14, 304);
            this.uxNumberOfQuestionsLabel.Name = "uxNumberOfQuestionsLabel";
            this.uxNumberOfQuestionsLabel.Size = new System.Drawing.Size(129, 13);
            this.uxNumberOfQuestionsLabel.TabIndex = 37;
            this.uxNumberOfQuestionsLabel.Text = "Number of Questions:";
            this.uxNumberOfQuestionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAllPartialCredit
            // 
            this.uxAllPartialCredit.AutoSize = true;
            this.uxAllPartialCredit.BackColor = System.Drawing.Color.Transparent;
            this.uxAllPartialCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAllPartialCredit.Location = new System.Drawing.Point(17, 374);
            this.uxAllPartialCredit.Name = "uxAllPartialCredit";
            this.uxAllPartialCredit.Size = new System.Drawing.Size(117, 17);
            this.uxAllPartialCredit.TabIndex = 33;
            this.uxAllPartialCredit.Text = "All Partial Credit";
            this.uxAllPartialCredit.UseVisualStyleBackColor = false;
            this.uxAllPartialCredit.Click += new System.EventHandler(this.uxAllPartialCredit_CheckedChanged);
            // 
            // uxAllQuestionPointsLabel
            // 
            this.uxAllQuestionPointsLabel.AutoSize = true;
            this.uxAllQuestionPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.uxAllQuestionPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAllQuestionPointsLabel.Location = new System.Drawing.Point(14, 339);
            this.uxAllQuestionPointsLabel.Name = "uxAllQuestionPointsLabel";
            this.uxAllQuestionPointsLabel.Size = new System.Drawing.Size(85, 13);
            this.uxAllQuestionPointsLabel.TabIndex = 40;
            this.uxAllQuestionPointsLabel.Text = "All Questions:";
            this.uxAllQuestionPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uxAllQuestionPoints
            // 
            this.uxAllQuestionPoints.DecimalPlaces = 2;
            this.uxAllQuestionPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAllQuestionPoints.Location = new System.Drawing.Point(149, 339);
            this.uxAllQuestionPoints.Name = "uxAllQuestionPoints";
            this.uxAllQuestionPoints.Size = new System.Drawing.Size(50, 20);
            this.uxAllQuestionPoints.TabIndex = 39;
            this.uxAllQuestionPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxAllQuestionPoints.ValueChanged += new System.EventHandler(this.uxAllQuestionPoints_ValueChanged);
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(149, 304);
            this.uxNumberOfQuestions.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(50, 20);
            this.uxNumberOfQuestions.TabIndex = 38;
            this.uxNumberOfQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfQuestions.ValueChanged += new System.EventHandler(this.uxNumberOfQuestions_ValueChanged);
            // 
            // uxNumberOfVersions
            // 
            this.uxNumberOfVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumberOfVersions.Location = new System.Drawing.Point(149, 270);
            this.uxNumberOfVersions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxNumberOfVersions.Name = "uxNumberOfVersions";
            this.uxNumberOfVersions.Size = new System.Drawing.Size(50, 20);
            this.uxNumberOfVersions.TabIndex = 36;
            this.uxNumberOfVersions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfVersions.ValueChanged += new System.EventHandler(this.uxNumberOfVersions_ValueChanged);
            // 
            // uxAnswerKeyTabControl
            // 
            this.uxAnswerKeyTabControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion1Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion2Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion3Tab);
            this.uxAnswerKeyTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAnswerKeyTabControl.Location = new System.Drawing.Point(352, 233);
            this.uxAnswerKeyTabControl.Name = "uxAnswerKeyTabControl";
            this.uxAnswerKeyTabControl.SelectedIndex = 0;
            this.uxAnswerKeyTabControl.Size = new System.Drawing.Size(458, 372);
            this.uxAnswerKeyTabControl.TabIndex = 23;
            // 
            // uxVersion1Tab
            // 
            this.uxVersion1Tab.AutoScroll = true;
            this.uxVersion1Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion1Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion1Tab.Name = "uxVersion1Tab";
            this.uxVersion1Tab.Padding = new System.Windows.Forms.Padding(3);
            this.uxVersion1Tab.Size = new System.Drawing.Size(450, 346);
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
            this.uxVersion2Tab.Size = new System.Drawing.Size(450, 346);
            this.uxVersion2Tab.TabIndex = 1;
            this.uxVersion2Tab.Text = "Version 2";
            // 
            // uxVersion3Tab
            // 
            this.uxVersion3Tab.AutoScroll = true;
            this.uxVersion3Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion3Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion3Tab.Name = "uxVersion3Tab";
            this.uxVersion3Tab.Size = new System.Drawing.Size(450, 346);
            this.uxVersion3Tab.TabIndex = 2;
            this.uxVersion3Tab.Text = "Version 3";
            // 
            // uxScanTab
            // 
            this.uxScanTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxScanTab.Controls.Add(this.uxResume);
            this.uxScanTab.Controls.Add(this.uxPause);
            this.uxScanTab.Controls.Add(this.uxTestData);
            this.uxScanTab.Controls.Add(this.uxCreateStudents);
            this.uxScanTab.Controls.Add(this.uxSaveChanges);
            this.uxScanTab.Controls.Add(this.uxCardList);
            this.uxScanTab.Controls.Add(this.uxScanInstructionLabel);
            this.uxScanTab.Controls.Add(this.uxHorizontalDivider);
            this.uxScanTab.Controls.Add(this.uxStart);
            this.uxScanTab.Controls.Add(this.uxStop);
            this.uxScanTab.Controls.Add(this.uxRestart);
            this.uxScanTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScanTab.Location = new System.Drawing.Point(4, 34);
            this.uxScanTab.Name = "uxScanTab";
            this.uxScanTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxScanTab.Size = new System.Drawing.Size(889, 611);
            this.uxScanTab.TabIndex = 0;
            this.uxScanTab.Text = "Scan";
            // 
            // uxTestData
            // 
            this.uxTestData.Location = new System.Drawing.Point(9, 374);
            this.uxTestData.Name = "uxTestData";
            this.uxTestData.Size = new System.Drawing.Size(127, 72);
            this.uxTestData.TabIndex = 35;
            this.uxTestData.Text = "Test Data";
            this.uxTestData.UseVisualStyleBackColor = true;
            this.uxTestData.Click += new System.EventHandler(this.uxTestData_Click);
            // 
            // uxCreateStudents
            // 
            this.uxCreateStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCreateStudents.Location = new System.Drawing.Point(9, 526);
            this.uxCreateStudents.Name = "uxCreateStudents";
            this.uxCreateStudents.Size = new System.Drawing.Size(125, 70);
            this.uxCreateStudents.TabIndex = 34;
            this.uxCreateStudents.Text = "Create Students";
            this.uxCreateStudents.UseVisualStyleBackColor = true;
            this.uxCreateStudents.Click += new System.EventHandler(this.uxCreateStudents_Click);
            // 
            // uxSaveChanges
            // 
            this.uxSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSaveChanges.Location = new System.Drawing.Point(9, 452);
            this.uxSaveChanges.Name = "uxSaveChanges";
            this.uxSaveChanges.Size = new System.Drawing.Size(125, 68);
            this.uxSaveChanges.TabIndex = 33;
            this.uxSaveChanges.Text = "Save Changes";
            this.uxSaveChanges.UseVisualStyleBackColor = true;
            this.uxSaveChanges.Click += new System.EventHandler(this.uxSaveChanges_Click);
            // 
            // uxCardList
            // 
            this.uxCardList.BackColor = System.Drawing.SystemColors.Control;
            this.uxCardList.Location = new System.Drawing.Point(321, 250);
            this.uxCardList.Name = "uxCardList";
            this.uxCardList.Size = new System.Drawing.Size(355, 319);
            this.uxCardList.TabIndex = 32;
            // 
            // uxScanInstructionLabel
            // 
            this.uxScanInstructionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxScanInstructionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScanInstructionLabel.Location = new System.Drawing.Point(6, 3);
            this.uxScanInstructionLabel.Name = "uxScanInstructionLabel";
            this.uxScanInstructionLabel.Size = new System.Drawing.Size(874, 189);
            this.uxScanInstructionLabel.TabIndex = 31;
            // 
            // uxHorizontalDivider
            // 
            this.uxHorizontalDivider.BackColor = System.Drawing.Color.SlateBlue;
            this.uxHorizontalDivider.Location = new System.Drawing.Point(7, 202);
            this.uxHorizontalDivider.Name = "uxHorizontalDivider";
            this.uxHorizontalDivider.Size = new System.Drawing.Size(873, 10);
            this.uxHorizontalDivider.TabIndex = 10;
            // 
            // uxGradeTab
            // 
            this.uxGradeTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxGradeTab.Controls.Add(this.uxGradeStudents);
            this.uxGradeTab.Controls.Add(this.uxScoreLabel);
            this.uxGradeTab.Controls.Add(this.uxCouldNotBeGradedLabel);
            this.uxGradeTab.Controls.Add(this.uxGradeInstructionLabel);
            this.uxGradeTab.Controls.Add(this.uxHorizontalDivider2);
            this.uxGradeTab.Controls.Add(this.uxVersionLabel);
            this.uxGradeTab.Controls.Add(this.uxPreviousStudent);
            this.uxGradeTab.Controls.Add(this.uxNextStudent);
            this.uxGradeTab.Controls.Add(this.uxStudentResponseLabel);
            this.uxGradeTab.Controls.Add(this.uxStudentSelector);
            this.uxGradeTab.Controls.Add(this.uxStudentResponsePanel);
            this.uxGradeTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uxGradeTab.Location = new System.Drawing.Point(4, 34);
            this.uxGradeTab.Name = "uxGradeTab";
            this.uxGradeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxGradeTab.Size = new System.Drawing.Size(889, 611);
            this.uxGradeTab.TabIndex = 1;
            this.uxGradeTab.Text = "Grade";
            // 
            // uxGradeStudents
            // 
            this.uxGradeStudents.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxGradeStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxGradeStudents.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGradeStudents.Location = new System.Drawing.Point(14, 382);
            this.uxGradeStudents.Name = "uxGradeStudents";
            this.uxGradeStudents.Size = new System.Drawing.Size(167, 67);
            this.uxGradeStudents.TabIndex = 35;
            this.uxGradeStudents.Text = "Grade Students";
            this.uxGradeStudents.UseVisualStyleBackColor = false;
            this.uxGradeStudents.Click += new System.EventHandler(this.uxGradeStudents_Click);
            // 
            // uxScoreLabel
            // 
            this.uxScoreLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxScoreLabel.Location = new System.Drawing.Point(319, 250);
            this.uxScoreLabel.Name = "uxScoreLabel";
            this.uxScoreLabel.Size = new System.Drawing.Size(65, 22);
            this.uxScoreLabel.TabIndex = 33;
            this.uxScoreLabel.Text = "Score: ";
            this.uxScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxGradeInstructionLabel
            // 
            this.uxGradeInstructionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxGradeInstructionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGradeInstructionLabel.Location = new System.Drawing.Point(6, 3);
            this.uxGradeInstructionLabel.Name = "uxGradeInstructionLabel";
            this.uxGradeInstructionLabel.Size = new System.Drawing.Size(874, 189);
            this.uxGradeInstructionLabel.TabIndex = 30;
            // 
            // uxHorizontalDivider2
            // 
            this.uxHorizontalDivider2.BackColor = System.Drawing.Color.SlateBlue;
            this.uxHorizontalDivider2.Location = new System.Drawing.Point(7, 202);
            this.uxHorizontalDivider2.Name = "uxHorizontalDivider2";
            this.uxHorizontalDivider2.Size = new System.Drawing.Size(873, 10);
            this.uxHorizontalDivider2.TabIndex = 29;
            // 
            // uxVersionLabel
            // 
            this.uxVersionLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxVersionLabel.Location = new System.Drawing.Point(11, 245);
            this.uxVersionLabel.Name = "uxVersionLabel";
            this.uxVersionLabel.Size = new System.Drawing.Size(65, 22);
            this.uxVersionLabel.TabIndex = 25;
            this.uxVersionLabel.Text = "Version: ";
            this.uxVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxPreviousStudent
            // 
            this.uxPreviousStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxPreviousStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxPreviousStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxPreviousStudent.Location = new System.Drawing.Point(14, 275);
            this.uxPreviousStudent.Name = "uxPreviousStudent";
            this.uxPreviousStudent.Size = new System.Drawing.Size(90, 30);
            this.uxPreviousStudent.TabIndex = 21;
            this.uxPreviousStudent.Text = "Previous";
            this.uxPreviousStudent.UseVisualStyleBackColor = false;
            this.uxPreviousStudent.Click += new System.EventHandler(this.uxPreviousStudent_Click);
            // 
            // uxNextStudent
            // 
            this.uxNextStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxNextStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxNextStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNextStudent.Location = new System.Drawing.Point(309, 275);
            this.uxNextStudent.Name = "uxNextStudent";
            this.uxNextStudent.Size = new System.Drawing.Size(90, 30);
            this.uxNextStudent.TabIndex = 10;
            this.uxNextStudent.Text = "Next";
            this.uxNextStudent.UseVisualStyleBackColor = false;
            this.uxNextStudent.Click += new System.EventHandler(this.uxNextStudent_Click);
            // 
            // uxStudentResponseLabel
            // 
            this.uxStudentResponseLabel.AutoSize = true;
            this.uxStudentResponseLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxStudentResponseLabel.Location = new System.Drawing.Point(121, 227);
            this.uxStudentResponseLabel.Name = "uxStudentResponseLabel";
            this.uxStudentResponseLabel.Size = new System.Drawing.Size(165, 24);
            this.uxStudentResponseLabel.TabIndex = 18;
            this.uxStudentResponseLabel.Text = "Student Response";
            // 
            // uxPause
            // 
            this.uxPause.Location = new System.Drawing.Point(100, 226);
            this.uxPause.Name = "uxPause";
            this.uxPause.Size = new System.Drawing.Size(90, 65);
            this.uxPause.TabIndex = 36;
            this.uxPause.Text = "Pause";
            this.uxPause.UseVisualStyleBackColor = true;
            this.uxPause.Click += new System.EventHandler(this.uxPause_Click);
            // 
            // uxResume
            // 
            this.uxResume.Location = new System.Drawing.Point(196, 226);
            this.uxResume.Name = "uxResume";
            this.uxResume.Size = new System.Drawing.Size(97, 65);
            this.uxResume.TabIndex = 37;
            this.uxResume.Text = "Resume";
            this.uxResume.UseVisualStyleBackColor = true;
            this.uxResume.Click += new System.EventHandler(this.uxResume_Click);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(887, 642);
            this.Controls.Add(this.uxMainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
            this.uxMainTabControl.ResumeLayout(false);
            this.uxAnswerKeyTab.ResumeLayout(false);
            this.uxAnswerKeyTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).EndInit();
            this.uxAnswerKeyTabControl.ResumeLayout(false);
            this.uxScanTab.ResumeLayout(false);
            this.uxGradeTab.ResumeLayout(false);
            this.uxGradeTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxRestart;
        private System.Windows.Forms.Panel uxStudentResponsePanel;
        private System.Windows.Forms.ComboBox uxStudentSelector;
        private System.Windows.Forms.TabControl uxMainTabControl;
        private System.Windows.Forms.TabPage uxScanTab;
        private System.Windows.Forms.TabPage uxGradeTab;
        private System.Windows.Forms.Label uxStudentResponseLabel;
        private System.Windows.Forms.Button uxPreviousStudent;
        private System.Windows.Forms.Button uxNextStudent;
        private System.Windows.Forms.Label uxVersionLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label uxHorizontalDivider;
        private System.Windows.Forms.Label uxGradeInstructionLabel;
        private System.Windows.Forms.Label uxScanInstructionLabel;
        private System.Windows.Forms.Label uxCouldNotBeGradedLabel;
        private System.Windows.Forms.Label uxScoreLabel;
        private System.Windows.Forms.TabPage uxAnswerKeyTab;
        private System.Windows.Forms.Label uxExamNameLabel;
        private System.Windows.Forms.TextBox uxExamName;
        private System.Windows.Forms.Label uxNumberOfVersionsLabel;
        private System.Windows.Forms.Label uxNumberOfQuestionsLabel;
        private System.Windows.Forms.CheckBox uxAllPartialCredit;
        private System.Windows.Forms.Label uxAllQuestionPointsLabel;
        private System.Windows.Forms.NumericUpDown uxAllQuestionPoints;
        private System.Windows.Forms.NumericUpDown uxNumberOfQuestions;
        private System.Windows.Forms.NumericUpDown uxNumberOfVersions;
        private System.Windows.Forms.TabControl uxAnswerKeyTabControl;
        private System.Windows.Forms.TabPage uxVersion1Tab;
        private System.Windows.Forms.TabPage uxVersion2Tab;
        private System.Windows.Forms.TabPage uxVersion3Tab;
        private System.Windows.Forms.Button uxGradeStudents;
        private System.Windows.Forms.Label uxHorizontalDivider2;
        private System.Windows.Forms.Label uxAnswerKeyInstructionLabel;
        private System.Windows.Forms.Panel uxCardList;
        private System.Windows.Forms.Button uxSaveChanges;
        private System.Windows.Forms.Button uxCreateStudents;
        private System.Windows.Forms.Button uxTestData;
        private System.Windows.Forms.Button uxCreateAnswerKey;
        private System.Windows.Forms.Button uxResume;
        private System.Windows.Forms.Button uxPause;
    }
}

