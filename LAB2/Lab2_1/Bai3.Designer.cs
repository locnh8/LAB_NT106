namespace Lab2
{
    partial class Bai3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bai3));
            this.readFile = new System.Windows.Forms.Button();
            this.box_input = new System.Windows.Forms.RichTextBox();
            this.operating = new System.Windows.Forms.Button();
            this.writeFile = new System.Windows.Forms.Button();
            this.box_output = new System.Windows.Forms.RichTextBox();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readFile
            // 
            this.readFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(114)))), ((int)(((byte)(160)))));
            this.readFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.readFile.FlatAppearance.BorderSize = 2;
            this.readFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readFile.Font = new System.Drawing.Font("Frisky Puppy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.readFile.Location = new System.Drawing.Point(28, 43);
            this.readFile.Name = "readFile";
            this.readFile.Size = new System.Drawing.Size(98, 70);
            this.readFile.TabIndex = 0;
            this.readFile.Text = "Read";
            this.readFile.UseVisualStyleBackColor = false;
            this.readFile.Click += new System.EventHandler(this.readFile_Click);
            // 
            // box_input
            // 
            this.box_input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.box_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.box_input.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box_input.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.box_input.Location = new System.Drawing.Point(168, 43);
            this.box_input.Margin = new System.Windows.Forms.Padding(5);
            this.box_input.Name = "box_input";
            this.box_input.ReadOnly = true;
            this.box_input.Size = new System.Drawing.Size(429, 161);
            this.box_input.TabIndex = 1;
            this.box_input.Text = "";
            // 
            // operating
            // 
            this.operating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(114)))), ((int)(((byte)(160)))));
            this.operating.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.operating.FlatAppearance.BorderSize = 2;
            this.operating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operating.Font = new System.Drawing.Font("Frisky Puppy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.operating.Location = new System.Drawing.Point(28, 160);
            this.operating.Name = "operating";
            this.operating.Size = new System.Drawing.Size(98, 70);
            this.operating.TabIndex = 2;
            this.operating.Text = "Calculator";
            this.operating.UseVisualStyleBackColor = false;
            this.operating.Click += new System.EventHandler(this.operating_Click);
            // 
            // writeFile
            // 
            this.writeFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(114)))), ((int)(((byte)(160)))));
            this.writeFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.writeFile.FlatAppearance.BorderSize = 2;
            this.writeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeFile.Font = new System.Drawing.Font("Frisky Puppy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.writeFile.Location = new System.Drawing.Point(28, 276);
            this.writeFile.Name = "writeFile";
            this.writeFile.Size = new System.Drawing.Size(98, 70);
            this.writeFile.TabIndex = 3;
            this.writeFile.Text = "Write";
            this.writeFile.UseVisualStyleBackColor = false;
            this.writeFile.Click += new System.EventHandler(this.writeFile_Click);
            // 
            // box_output
            // 
            this.box_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.box_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.box_output.Cursor = System.Windows.Forms.Cursors.Default;
            this.box_output.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_output.Location = new System.Drawing.Point(168, 236);
            this.box_output.Name = "box_output";
            this.box_output.ReadOnly = true;
            this.box_output.Size = new System.Drawing.Size(429, 239);
            this.box_output.TabIndex = 4;
            this.box_output.Text = "";
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.RosyBrown;
            this.clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.clear.FlatAppearance.BorderSize = 2;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Font = new System.Drawing.Font("Frisky Puppy", 12F);
            this.clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.clear.Location = new System.Drawing.Point(28, 390);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(98, 70);
            this.clear.TabIndex = 5;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Lab2_Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(114)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(637, 518);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.box_output);
            this.Controls.Add(this.writeFile);
            this.Controls.Add(this.operating);
            this.Controls.Add(this.box_input);
            this.Controls.Add(this.readFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lab2_Bai3";
            this.Text = "Lab2: Bài 3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readFile;
        private System.Windows.Forms.RichTextBox box_input;
        private System.Windows.Forms.Button operating;
        private System.Windows.Forms.Button writeFile;
        private System.Windows.Forms.RichTextBox box_output;
        private System.Windows.Forms.Button clear;
    }
}

