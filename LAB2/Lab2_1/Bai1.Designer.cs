namespace Lab2_1
{
    partial class Bai1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReadFile = new Button();
            btnWriteFile = new Button();
            rTxtFile = new RichTextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnReadFile
            // 
            btnReadFile.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadFile.Location = new Point(12, 12);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(229, 69);
            btnReadFile.TabIndex = 0;
            btnReadFile.Text = "ĐỌC FILE";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnWriteFile
            // 
            btnWriteFile.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnWriteFile.Location = new Point(12, 102);
            btnWriteFile.Name = "btnWriteFile";
            btnWriteFile.Size = new Size(229, 69);
            btnWriteFile.TabIndex = 1;
            btnWriteFile.Text = "GHI FILE";
            btnWriteFile.UseVisualStyleBackColor = true;
            btnWriteFile.Click += btnWriteFile_Click;
            // 
            // rTxtFile
            // 
            rTxtFile.Location = new Point(291, 12);
            rTxtFile.Name = "rTxtFile";
            rTxtFile.Size = new Size(497, 426);
            rTxtFile.TabIndex = 2;
            rTxtFile.Text = "";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnBack.Location = new Point(2, 421);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(79, 29);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(rTxtFile);
            Controls.Add(btnWriteFile);
            Controls.Add(btnReadFile);
            Name = "Bai1";
            Text = "Bai 1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnReadFile;
        private Button btnWriteFile;
        private RichTextBox rTxtFile;
        private Button btnBack;
    }
}
