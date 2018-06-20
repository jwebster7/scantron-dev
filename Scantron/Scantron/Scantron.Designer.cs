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
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(5, 281);
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
            this.uxInstructionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxInstructionBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxInstructionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxInstructionBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.uxInstructionBox.Location = new System.Drawing.Point(5, 30);
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
            this.uxStop.Location = new System.Drawing.Point(96, 281);
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
            this.uxCreateFile.Location = new System.Drawing.Point(187, 281);
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
            this.uxAdmin.Location = new System.Drawing.Point(5, 5);
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
            this.uxCanConvert.Location = new System.Drawing.Point(323, 281);
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
            this.uxRestart.Location = new System.Drawing.Point(459, 281);
            this.uxRestart.Name = "uxRestart";
            this.uxRestart.Size = new System.Drawing.Size(124, 65);
            this.uxRestart.TabIndex = 8;
            this.uxRestart.Text = "Restart";
            this.uxRestart.UseVisualStyleBackColor = true;
            this.uxRestart.Click += new System.EventHandler(this.uxRestart_Click);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(585, 349);
            this.Controls.Add(this.uxRestart);
            this.Controls.Add(this.uxCanConvert);
            this.Controls.Add(this.uxAdmin);
            this.Controls.Add(this.uxCreateFile);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxInstructionBox);
            this.Controls.Add(this.uxStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
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
    }
}

