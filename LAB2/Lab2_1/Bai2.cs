using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = openFileDialog.SafeFileName;

                FileInfo fileInfo = new FileInfo(filePath);
                long fileSize = fileInfo.Length;

                string fileSizeFormatted = FormatFileSize(fileSize);  // Sử dụng hàm định dạng kích thước tệp

                string content;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                }

                int lineCount = content.Split('\n').Length;
                int wordCount = content.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                int charCount = content.Length;

                txtFileName.Text = fileName;
                txtSize.Text = $"{fileSize} bytes";
                txtURL.Text = filePath;
                txtLineCount.Text = lineCount.ToString();
                txtWordsCount.Text = wordCount.ToString();
                txtCharacter.Text = charCount.ToString();
                rTxtFile.Text = content;
            }
        }
        private string FormatFileSize(long bytes)
        {
            const int scale = 1024;
            string[] units = { "bytes", "KB", "MB", "GB", "TB" };
            double fileSize = bytes;
            int unitIndex = 0;

            while (fileSize >= scale && unitIndex < units.Length - 1)
            {
                fileSize /= scale;
                unitIndex++;
            }

            return $"{fileSize:0.##} {units[unitIndex]}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}
