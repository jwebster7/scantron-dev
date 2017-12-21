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
            this.uxReadFiles = new System.Windows.Forms.Button();
            this.uxCreateFile = new System.Windows.Forms.Button();
            this.uxStatusBox = new System.Windows.Forms.TextBox();
            this.uxDataBox = new System.Windows.Forms.TextBox();
            this.uxMaxCharactersBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxReadFiles
            // 
            this.uxReadFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxReadFiles.Location = new System.Drawing.Point(12, 12);
            this.uxReadFiles.Name = "uxReadFiles";
            this.uxReadFiles.Size = new System.Drawing.Size(200, 45);
            this.uxReadFiles.TabIndex = 0;
            this.uxReadFiles.Text = "Read Scantron Sheets";
            this.uxReadFiles.UseVisualStyleBackColor = true;
            this.uxReadFiles.Click += new System.EventHandler(this.uxReadFiles_Click);
            // 
            // uxCreateFile
            // 
            this.uxCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCreateFile.Location = new System.Drawing.Point(218, 12);
            this.uxCreateFile.Name = "uxCreateFile";
            this.uxCreateFile.Size = new System.Drawing.Size(200, 45);
            this.uxCreateFile.TabIndex = 1;
            this.uxCreateFile.Text = "Clear Text";
            this.uxCreateFile.UseVisualStyleBackColor = true;
            this.uxCreateFile.Click += new System.EventHandler(this.uxCreateFile_Click);
            // 
            // uxStatusBox
            // 
            this.uxStatusBox.Location = new System.Drawing.Point(12, 63);
            this.uxStatusBox.Name = "uxStatusBox";
            this.uxStatusBox.ReadOnly = true;
            this.uxStatusBox.Size = new System.Drawing.Size(200, 20);
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
            // uxMaxCharactersBox
            // 
            this.uxMaxCharactersBox.Location = new System.Drawing.Point(218, 63);
            this.uxMaxCharactersBox.Name = "uxMaxCharactersBox";
            this.uxMaxCharactersBox.Size = new System.Drawing.Size(198, 20);
            this.uxMaxCharactersBox.TabIndex = 4;
            this.uxMaxCharactersBox.TextChanged += new System.EventHandler(this.uxMaxCharactersBox_TextChanged);
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 296);
            this.Controls.Add(this.uxMaxCharactersBox);
            this.Controls.Add(this.uxDataBox);
            this.Controls.Add(this.uxStatusBox);
            this.Controls.Add(this.uxCreateFile);
            this.Controls.Add(this.uxReadFiles);
            this.Name = "Scantron";
            this.Text = "File Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxReadFiles;
        private System.Windows.Forms.Button uxCreateFile;
        private System.Windows.Forms.TextBox uxStatusBox;
        private System.Windows.Forms.TextBox uxDataBox;
        private System.Windows.Forms.TextBox uxMaxCharactersBox;
    }
}

