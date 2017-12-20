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
            this.uxTextBox = new System.Windows.Forms.TextBox();
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
            // 
            // uxCreateFile
            // 
            this.uxCreateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCreateFile.Location = new System.Drawing.Point(12, 63);
            this.uxCreateFile.Name = "uxCreateFile";
            this.uxCreateFile.Size = new System.Drawing.Size(200, 45);
            this.uxCreateFile.TabIndex = 1;
            this.uxCreateFile.Text = "Generate Answer File";
            this.uxCreateFile.UseVisualStyleBackColor = true;
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(12, 126);
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.Size = new System.Drawing.Size(199, 20);
            this.uxTextBox.TabIndex = 2;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 171);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxCreateFile);
            this.Controls.Add(this.uxReadFiles);
            this.Name = "GUI";
            this.Text = "File Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxReadFiles;
        private System.Windows.Forms.Button uxCreateFile;
        private System.Windows.Forms.TextBox uxTextBox;
    }
}

