using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Bai3 : Form
    {
        string input_filePath;
        string output_filePath;

        public Bai3()
        {
            InitializeComponent();
        }

        // Sự kiện - Đọc file input3
        private void readFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    input_filePath = openFileDialog.FileName;
                    box_input.Text = File.ReadAllText(input_filePath);
                }
                else
                {
                    MessageBox.Show("File not selected.", "Notification");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, hiển thị thông báo lỗi nếu có
                MessageBox.Show("An error has occurred: " + ex.Message, "Error");
            }
        }

        private string CalculateExpression(string expression)
        {
            Queue<string> postfix = InfixToPostFix(expression); // Chuyển đổi từ trung tố sang hậu tố
            return EvaluatePostfix(postfix); // Tính toán và trả về kết quả
        }

        // Chuyển từ trung tố sang hậu tố
        private Queue<string> InfixToPostFix(string e)
        {
            Stack<char> operators = new Stack<char>(); // Stack để lưu toán tử
            Queue<string> postfix = new Queue<string>(); // Queue để lưu toán hạng

            for (int i = 0; i < e.Length; i++)
            {
                char c = e[i];
                if (char.IsWhiteSpace(c)) continue; // Bỏ qua khoảng trắng
                // Xử lý toán hạng
                if (char.IsDigit(c))
                {
                    string number = c.ToString();
                    while (i + 1 < e.Length && (char.IsDigit(e[i + 1]) || e[i + 1] == ','))
                    {

                        number += e[++i];
                    }
                    postfix.Enqueue(number); // Đưa vào queue
                }

                // Xử lý toán tử
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(c))
                    {
                        postfix.Enqueue(operators.Pop().ToString());
                    }
                    operators.Push(c);
                }

                // Xử lý dấu ngoặc mở
                else if (IsOpeningBracket(c))
                {
                    operators.Push(c);
                }

                // Xử lý dấu ngoặc đóng
                else if (IsClosingBracket(c))
                {
                    while (operators.Count > 0 && !IsMatchingOpeningBracket(operators.Peek(), c))
                    {
                        postfix.Enqueue(operators.Pop().ToString());
                    }
                    if (operators.Count > 0 && IsMatchingOpeningBracket(operators.Peek(), c))
                    {
                        operators.Pop(); // Bỏ dấu ngoặc mở tương ứng
                    }
                }
            }

            while (operators.Count > 0)
            {
                postfix.Enqueue(operators.Pop().ToString());
            }
            return postfix;
        }

        // Độ ưu tiên
        private int GetPrecedence(char op)
        {
            if (op == '+' || op == '-')
                return 1;
            if (op == '*' || op == '/')
                return 2;
            return 0;
        }

        // Hàm kiểm tra dấu ngoặc mở
        private bool IsOpeningBracket(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        // Hàm kiểm tra dấu ngoặc đóng
        private bool IsClosingBracket(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        // Hàm kiểm tra xem dấu ngoặc mở có khớp với dấu ngoặc đóng hay không
        private bool IsMatchingOpeningBracket(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '[' && close == ']') ||
                   (open == '{' && close == '}');
        }

        // Tính toán biểu thức trung tố
        private string EvaluatePostfix(Queue<string> postfix)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            if (b == 0)
                            {
                                return "Can not divide by 0";
                            }
                            else stack.Push(a / b);
                            break;
                    }
                }
            }

            return (stack.Pop()).ToString();
        }

        // Kiểm tra biểu thức có kí tự hợp lệ
        private bool isExpression(string expression)
        {
            string charAcpt = "0123456789+-*/()[]{}, ";

            foreach (char c in expression)
            {
                if (!charAcpt.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Kiểm tra ngoặc
        private bool KiemTraDongMoNgoac(string expression)
        {
            Stack<char> stack = new Stack<char>();
            int dem = 0;
            foreach (char c in expression)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    dem++;
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    dem++;
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();

                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            if (dem == expression.Length) { return false; }
            return stack.Count == 0;
        }

        // Sự kiện - Tính toán
        private void operating_Click(object sender, EventArgs e)
        {
            // Khi nội dung rỗng
            if (box_input.Text == "")
            {
                MessageBox.Show("File not selected or Empty file.", "Notification");
                return;
            }
            using (StreamReader reader = new StreamReader(input_filePath))
            {
                box_output.Clear(); // Xóa nội dung cũ trước khi đọc file

                string line;
                while ((line = reader.ReadLine()) != null) // Đọc từng dòng từ file
                {
                    if (line == "") continue;

                    // Kiểm tra kí tự và dấu ngoặc của biểu thức
                    if (!isExpression(line) || !KiemTraDongMoNgoac(line))
                    {
                        box_output.AppendText($"{"Error: Invalid"}{Environment.NewLine}");
                        continue;
                    }

                    // Nếu biểu thức chỉ chứa kí tự hợp lệ nhưng bắt đầu là * hoặc / 
                    if (line[0] == '*' || line[0] == '/')
                    {
                        box_output.AppendText($"{"Error: Invalid first character"}{Environment.NewLine}");
                        continue;
                    }

                    // Nếu biểu thức kết thúc là + - * /
                    if (line[line.Length - 1] == '+' ||
                        line[line.Length - 1] == '-' ||
                        line[line.Length - 1] == '*' ||
                        line[line.Length - 1] == '/')
                    {
                        box_output.AppendText($"{"Error: Invalid last character"}{Environment.NewLine}");
                        continue;
                    }

                    string tempLine = line;
                    // Nếu biểu thức chỉ chứa kí tự hợp lệ và bắt đầu là + hoặc - 
                    if (tempLine[0] == '+' || tempLine[0] == '-')
                    {
                        tempLine = "0" + tempLine;
                        if (line[0] == '+') line = line.Substring(1);
                    }

                    string result = CalculateExpression(tempLine);

                    box_output.AppendText($"{line} = {result}{Environment.NewLine}");
                }
            }
        }

        // Sự kiện - Ghi kết qua vào file output3
        private void writeFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (box_input.Text == "")
                {
                    MessageBox.Show("Result is empty.", "Notification");
                    return;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    output_filePath = openFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(output_filePath, append: true))
                    {
                        writer.WriteLine(box_output.Text); // Ghi tất cả nội dung từ box_output vào file
                    }
                    MessageBox.Show("Saved successfully.", "Notification");

                }
                else
                {
                    MessageBox.Show("File not selected.", "Notification");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error");
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            box_input.Clear();
            box_output.Clear();
        }
    }
}
