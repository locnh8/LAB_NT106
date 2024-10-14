namespace Lab2
{
    partial class Bai2
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
            rTxtFile = new RichTextBox();
            btnReadFile = new Button();
            btnExit = new Button();
            lbFileName = new Label();
            lbSize = new Label();
            lbURL = new Label();
            lbLineCount = new Label();
            lbWordsCount = new Label();
            lbCharacterCount = new Label();
            txtFileName = new TextBox();
            txtSize = new TextBox();
            txtURL = new TextBox();
            txtLineCount = new TextBox();
            txtWordsCount = new TextBox();
            txtCharacter = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            btnBack = new Button();
            SuspendLayout();
            // 
            // rTxtFile
            // 
            rTxtFile.Location = new Point(348, 12);
            rTxtFile.Name = "rTxtFile";
            rTxtFile.Size = new Size(440, 426);
            rTxtFile.TabIndex = 0;
            rTxtFile.Text = "";
            // 
            // btnReadFile
            // 
            btnReadFile.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnReadFile.Location = new Point(12, 12);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(299, 33);
            btnReadFile.TabIndex = 1;
            btnReadFile.Text = "Read from File ";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnExit.Location = new Point(12, 403);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(137, 35);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lbFileName
            // 
            lbFileName.AutoSize = true;
            lbFileName.Location = new Point(7, 110);
            lbFileName.Name = "lbFileName";
            lbFileName.Size = new Size(73, 20);
            lbFileName.TabIndex = 3;
            lbFileName.Text = "File name";
            // 
            // lbSize
            // 
            lbSize.AutoSize = true;
            lbSize.Location = new Point(7, 155);
            lbSize.Name = "lbSize";
            lbSize.Size = new Size(36, 20);
            lbSize.TabIndex = 4;
            lbSize.Text = "Size";
            // 
            // lbURL
            // 
            lbURL.AutoSize = true;
            lbURL.Location = new Point(8, 199);
            lbURL.Name = "lbURL";
            lbURL.Size = new Size(35, 20);
            lbURL.TabIndex = 5;
            lbURL.Text = "URL";
            // 
            // lbLineCount
            // 
            lbLineCount.AutoSize = true;
            lbLineCount.Location = new Point(3, 246);
            lbLineCount.Name = "lbLineCount";
            lbLineCount.Size = new Size(77, 20);
            lbLineCount.TabIndex = 8;
            lbLineCount.Text = "Line count";
            // 
            // lbWordsCount
            // 
            lbWordsCount.AutoSize = true;
            lbWordsCount.Location = new Point(3, 289);
            lbWordsCount.Name = "lbWordsCount";
            lbWordsCount.Size = new Size(92, 20);
            lbWordsCount.TabIndex = 7;
            lbWordsCount.Text = "Words count";
            // 
            // lbCharacterCount
            // 
            lbCharacterCount.AutoSize = true;
            lbCharacterCount.Location = new Point(3, 336);
            lbCharacterCount.Name = "lbCharacterCount";
            lbCharacterCount.Size = new Size(113, 20);
            lbCharacterCount.TabIndex = 6;
            lbCharacterCount.Text = "Character count";
            // 
            // txtFileName
            // 
            txtFileName.BackColor = SystemColors.ButtonHighlight;
            txtFileName.Location = new Point(122, 107);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(215, 27);
            txtFileName.TabIndex = 9;
            // 
            // txtSize
            // 
            txtSize.BackColor = SystemColors.ButtonHighlight;
            txtSize.Location = new Point(122, 152);
            txtSize.Name = "txtSize";
            txtSize.ReadOnly = true;
            txtSize.Size = new Size(215, 27);
            txtSize.TabIndex = 10;
            // 
            // txtURL
            // 
            txtURL.BackColor = SystemColors.ButtonHighlight;
            txtURL.Location = new Point(122, 196);
            txtURL.Name = "txtURL";
            txtURL.ReadOnly = true;
            txtURL.Size = new Size(215, 27);
            txtURL.TabIndex = 11;
            // 
            // txtLineCount
            // 
            txtLineCount.BackColor = SystemColors.ButtonHighlight;
            txtLineCount.Location = new Point(122, 246);
            txtLineCount.Name = "txtLineCount";
            txtLineCount.ReadOnly = true;
            txtLineCount.Size = new Size(215, 27);
            txtLineCount.TabIndex = 12;
            // 
            // txtWordsCount
            // 
            txtWordsCount.BackColor = SystemColors.ButtonHighlight;
            txtWordsCount.Location = new Point(122, 289);
            txtWordsCount.Name = "txtWordsCount";
            txtWordsCount.ReadOnly = true;
            txtWordsCount.Size = new Size(215, 27);
            txtWordsCount.TabIndex = 13;
            // 
            // txtCharacter
            // 
            txtCharacter.BackColor = SystemColors.ButtonHighlight;
            txtCharacter.Location = new Point(122, 329);
            txtCharacter.Name = "txtCharacter";
            txtCharacter.ReadOnly = true;
            txtCharacter.Size = new Size(215, 27);
            txtCharacter.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnBack.Location = new Point(196, 403);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(125, 35);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(txtCharacter);
            Controls.Add(txtWordsCount);
            Controls.Add(txtLineCount);
            Controls.Add(txtURL);
            Controls.Add(txtSize);
            Controls.Add(txtFileName);
            Controls.Add(lbLineCount);
            Controls.Add(lbWordsCount);
            Controls.Add(lbCharacterCount);
            Controls.Add(lbURL);
            Controls.Add(lbSize);
            Controls.Add(lbFileName);
            Controls.Add(btnExit);
            Controls.Add(btnReadFile);
            Controls.Add(rTxtFile);
            Name = "Bai2";
            Text = "Bai 2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rTxtFile;
        private Button btnReadFile;
        private Button btnExit;
        private Label lbFileName;
        private Label lbSize;
        private Label lbURL;
        private Label lbLineCount;
        private Label lbWordsCount;
        private Label lbCharacterCount;
        private TextBox txtFileName;
        private TextBox txtSize;
        private TextBox txtURL;
        private TextBox txtLineCount;
        private TextBox txtWordsCount;
        private TextBox txtCharacter;
        private OpenFileDialog openFileDialog1;
        private Button btnBack;
    }
}