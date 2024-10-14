using System.Text.Json;

namespace Lab2
{
    public partial class Bai4 : Form
    {
        [Serializable]
        // Tạo lớp sinh viên
        public class Student
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Phone { get; set; }
            public float Score1 { get; set; }
            public float Score2 { get; set; }
            public float Score3 { get; set; }
            public float AverageScore { get; set; }
            public void CalculateAverageScore()
            {
                AverageScore = (float)Math.Round((Score1 + Score2 + Score3) / 3.0, 2);
            }
        }
        // Danh sách thí sinh đang nhập
        private List<Student> listStudents = new List<Student>();
        // Lưu nhưng ID đang nhập để tránh bị trùng
        private HashSet<int> iDSet = new HashSet<int>();

        public Bai4()
        {
            InitializeComponent();
        }

        // Kiểm tra name
        private bool CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 30) return false;
            string pattern = @"^[\p{L}\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, pattern)) return false;
            return true;
        }

        // Kiểm tra iD
        private bool CheckID(string number)
        {
            if (number == "") return false;
            if (int.TryParse(number, out int id))
            {
                if (id > 0 && id < 99999999) return true;
                else return false;
            }
            else return false;
        }

        // Kiểm tra số điện thoại
        private bool CheckPhone(string number)
        {
            if (number == "") return false;
            if (number[0] != '0' && number.Length != 10) return false;
            else if (int.TryParse(number, out int phone))
            {
                if (phone > 0 && phone < 1000000000) return true;
                else return false;
            }
            else return false;
        }

        // Kiểm tra điểm
        private bool CheckScore(string number)
        {
            if (number == "") return false;
            if (int.TryParse(number, out int score))
            {
                if (score >= 0 && score <= 10) return true;
                else return false;
            }
            else return false;
        }

        // Xóa thông tin khi nhập thành công
        private void DeleteInfoAfterAdd()
        {
            nameTextBox.Clear();
            idTextBox.Clear();
            phoneTextBox.Clear();
            score1TextBox.Clear();
            score2TextBox.Clear();
            score3TextBox.Clear();
        }

        // Hiện thị thông tin 1 sinh viên.
        private void DisplayInfo(Student student)
        {
            studentsListBox.Text += $"Name: {student.Name}\n"
                                      + $"ID: {student.ID:D8}\n"
                                      + $"Phone: {student.Phone}\n"
                                      + $"Course 1: {student.Score1}\n"
                                      + $"Course 2: {student.Score2}\n"
                                      + $"Course 3: {student.Score3}\n"
                                      + $"Average: {student.AverageScore:F2}\n"
                                      + new string('-', 30) + "\n"; // Ngăn cách sinh viên
        }

        // Nhập thông tin từng sinh viên 
        private void addButton_Click(object sender, EventArgs e)
        {
            string check = "";
            if (!CheckName(nameTextBox.Text)) check += "Name không hợp lệ\n";
            if (!CheckID(idTextBox.Text)) check += "ID không hợp lệ\n";
            if (!CheckPhone(phoneTextBox.Text)) check += "Phone không hợp lệ\n";
            if (!CheckScore(score1TextBox.Text)) check += "Course 1 không hợp lệ\n";
            if (!CheckScore(score2TextBox.Text)) check += "Course 2 không hợp lệ\n";
            if (!CheckScore(score3TextBox.Text)) check += "Course 3 không hợp lệ\n";

            if (check != "")
            {
                MessageBox.Show(check, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra MSSV trùng
            int studentID = Convert.ToInt32(idTextBox.Text);
            if (iDSet.Contains(studentID))
            {
                MessageBox.Show("ID đã tồn tại. Vui lòng nhập ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Student student = new Student
            {
                Name = nameTextBox.Text,
                ID = studentID,
                Phone = phoneTextBox.Text,
                Score1 = float.Parse(score1TextBox.Text),
                Score2 = float.Parse(score2TextBox.Text),
                Score3 = float.Parse(score3TextBox.Text)
            };
            listStudents.Add(student);
            iDSet.Add(Convert.ToInt32(student.ID));
            studentsListBox.Text += "Thêm thông tin:\n";
            DisplayInfo(student);
            DeleteInfoAfterAdd();
        }

        // Kiểm tra ID đã tồn tại trong file
        private bool IsDuplicateID(int id, List<Student> existingStudents)
        {
            foreach (var student in existingStudents)
            {
                if (student.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        // Chọn file có sẵn để lưu
        private void write_button_Click(object sender, EventArgs e)
        {
            if (listStudents.Count == 0)
            {
                MessageBox.Show("Danh sách sinh viên trống.", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn file để đọc";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Đọc danh sách sinh viên đã có từ file trước khi lưu để kiểm tra ID trùng
                List<Student> existingStudents = new List<Student>();

                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Kiểm tra nếu file không trống thì mới đọc dữ liệu
                    if (fileInfo.Length > 0)
                    {
                        try
                        {
                            string jsonString = File.ReadAllText(filePath);
                            existingStudents = JsonSerializer.Deserialize<List<Student>>(jsonString);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Kiểm tra từng sinh viên trong danh sách mới
                List<Student> nonDuplicateStudents = new List<Student>();

                foreach (var student in listStudents)
                {
                    if (!IsDuplicateID(student.ID, existingStudents))
                    {
                        // Nếu không trùng MSSV, thêm sinh viên vào danh sách cần ghi
                        nonDuplicateStudents.Add(student);
                    }
                }

                if (nonDuplicateStudents.Count > 0)
                {
                    // Nếu có sinh viên không trùng, thêm họ vào file
                    existingStudents.AddRange(nonDuplicateStudents);

                    // Ghi lại danh sách sinh viên mới vào file
                    try
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(existingStudents, options);
                        File.WriteAllText(filePath, jsonString);
                        listStudents.Clear(); // Xóa danh sách sinh viên
                        studentsListBox.Clear(); // Xóa hiển thị trong ListBox
                        iDSet.Clear(); // Xóa danh sách MSSV đã thêm
                        MessageBox.Show("Ghi file thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Tất cả sinh viên trong danh sách đều đã tồn tại trong file.", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Không chọn file để lưu.", "Thông báo");
            }
        }

        private int currentIndex = 0;

        // Đọc thông tin từ file
        private void read_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn file để đọc";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    listStudents = JsonSerializer.Deserialize<List<Student>>(jsonString);
                    studentsListBox.Clear();
                    DisplayStudentList();
                    currentIndex = 0;
                    if (listStudents.Count > 0)
                    {
                        DisplayStudent_Read(listStudents[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không chọn file để đọc.", "Thông báo");
            }

        }

        // Hiển thị ra toàn bộ thông tin
        private void DisplayStudentList()
        {
            studentsListBox.Clear(); // Xóa nội dung hiện tại
            foreach (var student in listStudents)
            {
                DisplayInfo(student);
            }
        }
        // Hiển thị thông tin từng người
        private void DisplayStudent_Read(Student student)
        {
            view_name.Text = student.Name;
            view_id.Text = student.ID.ToString("00000000");
            view_phone.Text = student.Phone;
            view_score1.Text = student.Score1.ToString();
            view_score2.Text = student.Score2.ToString();
            view_score3.Text = student.Score3.ToString();
            view_scoreAverage.Text = student.AverageScore.ToString();
            if (lb_page.Text == "0") lb_page.Text = "1";
        }

        // Sinh viên phía trước
        private void button_back_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = listStudents.Count - 1;

            }
            DisplayStudent_Read(listStudents[currentIndex]);
            lb_page.Text = (currentIndex + 1).ToString();
        }

        // Sinh viên phía sau
        private void button_next_Click(object sender, EventArgs e)
        {
            if (currentIndex < listStudents.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            DisplayStudent_Read(listStudents[currentIndex]);
            lb_page.Text = (currentIndex + 1).ToString();
        }

        // tính điểm trung bình và lưu vào file khác
        private void calulatorAverage_Click(object sender, EventArgs e)
        {
            if (view_scoreAverage.Text == "")
            {
                MessageBox.Show("Chưa chọn file", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (view_scoreAverage.Text != "0")
            {
                MessageBox.Show("Đã tính điểm trung bình", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Chọn vị trí để lưu file với điểm trung bình";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;
                foreach (var student in listStudents)
                {
                    student.CalculateAverageScore();
                }
                try
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(listStudents, options);
                    File.WriteAllText(outputFilePath, jsonString);
                    MessageBox.Show("Danh sách sinh viên với điểm trung bình đã được lưu!", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Không chọn vị trí để lưu file.", "Thông báo");
            }
        }
    }
}
