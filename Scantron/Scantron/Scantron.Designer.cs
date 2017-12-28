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
            this.uxClearText = new System.Windows.Forms.Button();
            this.uxStatusBox = new System.Windows.Forms.TextBox();
            this.uxDataBox = new System.Windows.Forms.TextBox();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxCreateFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxStart.Location = new System.Drawing.Point(12, 12);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(98, 45);
            this.uxStart.TabIndex = 0;
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxClearText
            // 
            this.uxClearText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxClearText.Location = new System.Drawing.Point(209, 12);
            this.uxClearText.Name = "uxClearText";
            this.uxClearText.Size = new System.Drawing.Size(100, 45);
            this.uxClearText.TabIndex = 1;
            this.uxClearText.Text = "Clear Text";
            this.uxClearText.UseVisualStyleBackColor = true;
            this.uxClearText.Click += new System.EventHandler(this.uxClearText_Click);
            // 
            // uxStatusBox
            // 
            this.uxStatusBox.Location = new System.Drawing.Point(12, 63);
            this.uxStatusBox.Name = "uxStatusBox";
            this.uxStatusBox.ReadOnly = true;
            this.uxStatusBox.Size = new System.Drawing.Size(404, 20);
            this.uxStatusBox.TabIndex = 2;
            this.uxStatusBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxDataBox
            // 
            this.uxDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDataBox.Location = new System.Drawing.Point(12, 89);
            this.uxDataBox.Multiline = true;
            this.uxDataBox.Name = "uxDataBox";
            this.uxDataBox.ReadOnly = true;
            this.uxDataBox.Size = new System.Drawing.Size(404, 195);
            this.uxDataBox.TabIndex = 3;
            // 
            // uxStop
            // 
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxStop.Location = new System.Drawing.Point(116, 12);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(87, 45);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxCreateFile
            // 
            this.uxCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCreateFile.Location = new System.Drawing.Point(315, 12);
            this.uxCreateFile.Name = "uxCreateFile";
            this.uxCreateFile.Size = new System.Drawing.Size(101, 45);
            this.uxCreateFile.TabIndex = 5;
            this.uxCreateFile.Text = "Create File";
            this.uxCreateFile.UseVisualStyleBackColor = true;
            this.uxCreateFile.Click += new System.EventHandler(this.uxCreateFile_Click);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 296);
            this.Controls.Add(this.uxCreateFile);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxDataBox);
            this.Controls.Add(this.uxStatusBox);
            this.Controls.Add(this.uxClearText);
            this.Controls.Add(this.uxStart);
            this.Name = "Scantron";
            this.Text = "File Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.Button uxClearText;
        private System.Windows.Forms.TextBox uxStatusBox;
        private System.Windows.Forms.TextBox uxDataBox;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxCreateFile;
    }
}

