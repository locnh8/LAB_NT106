using Lab2;

namespace Lab2_1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string inputFilePath = "input1.txt";

            try
            {

                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    string content = reader.ReadToEnd();

                    rTxtFile.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            string outputFilePath = "output1.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.Write(rTxtFile.Text.ToUpper());
                }

                MessageBox.Show("Ghi file thành công!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}
