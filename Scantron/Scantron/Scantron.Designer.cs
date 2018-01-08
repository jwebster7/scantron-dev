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
            this.uxDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(12, 263);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(140, 65);
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
            this.uxInstructionBox.Enabled = false;
            this.uxInstructionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxInstructionBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.uxInstructionBox.Location = new System.Drawing.Point(12, 12);
            this.uxInstructionBox.Multiline = true;
            this.uxInstructionBox.Name = "uxInstructionBox";
            this.uxInstructionBox.ReadOnly = true;
            this.uxInstructionBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxInstructionBox.Size = new System.Drawing.Size(580, 245);
            this.uxInstructionBox.TabIndex = 3;
            this.uxInstructionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxStop
            // 
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStop.Location = new System.Drawing.Point(158, 263);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(140, 65);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxCreateFile
            // 
            this.uxCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.uxCreateFile.Location = new System.Drawing.Point(304, 263);
            this.uxCreateFile.Name = "uxCreateFile";
            this.uxCreateFile.Size = new System.Drawing.Size(140, 65);
            this.uxCreateFile.TabIndex = 5;
            this.uxCreateFile.Text = "Create File";
            this.uxCreateFile.UseVisualStyleBackColor = true;
            this.uxCreateFile.Click += new System.EventHandler(this.uxCreateFile_Click);
            // 
            // uxDebug
            // 
            this.uxDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxDebug.Location = new System.Drawing.Point(452, 263);
            this.uxDebug.Name = "uxDebug";
            this.uxDebug.Size = new System.Drawing.Size(140, 65);
            this.uxDebug.TabIndex = 6;
            this.uxDebug.Text = "Debug";
            this.uxDebug.UseVisualStyleBackColor = true;
            this.uxDebug.Click += new System.EventHandler(this.uxDebug_Click);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 336);
            this.Controls.Add(this.uxDebug);
            this.Controls.Add(this.uxCreateFile);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxInstructionBox);
            this.Controls.Add(this.uxStart);
            this.Name = "Scantron";
            this.Text = "File Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.TextBox uxInstructionBox;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxCreateFile;
        private System.Windows.Forms.Button uxDebug;
    }
}

