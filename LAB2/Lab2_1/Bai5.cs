using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab2
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
            LoadDrives();
            // Liên kết sự kiện nháy đúp chuột
            treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
        }

        // Load the drives into the TreeView
        private void LoadDrives()
        {
            TreeNode rootNode;
            foreach (var drive in Directory.GetLogicalDrives())
            {
                rootNode = new TreeNode(drive)
                {
                    Tag = drive
                };
                rootNode.Nodes.Add(new TreeNode());
                treeView1.Nodes.Add(rootNode);
                LoadDirectories(rootNode); // Load the subdirectories of the drive
            }
        }

        // Load subdirectories
        private void LoadDirectories(TreeNode node)
        {
            try
            {
                // Xóa node placeholder
                node.Nodes.Clear();

                // Kiểm tra quyền truy cập
                var dirs = Directory.GetDirectories(node.Tag.ToString());
                foreach (var dir in dirs)
                {
                    try
                    {
                        TreeNode directoryNode = new TreeNode(Path.GetFileName(dir))
                        {
                            Tag = dir
                        };
                        // Thêm Node placeholder nếu thư mục này có thư mục con
                        if (Directory.GetDirectories(dir).Length > 0)
                        {
                            directoryNode.Nodes.Add(new TreeNode()); // Placeholder
                        }
                        node.Nodes.Add(directoryNode);
                    }
                    catch (UnauthorizedAccessException) // Bắt lỗi nếu không có quyền truy cập thư mục con
                    {
                        continue; // Bỏ qua thư mục không thể truy cập
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to access this folder.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            richTextBox1.Clear();
            richTextBox1.Controls.Clear();
            // Kiểm tra xem node được chọn có phải là file hay không
            if (File.Exists(path))
            {
                // Nếu là file, kiểm tra định dạng file và hiển thị nội dung
                if (path.EndsWith(".txt"))
                {
                    // Đọc nội dung file .txt vào richTextBox1
                    richTextBox1.Clear();
                    string content = File.ReadAllText(path);
                    richTextBox1.Text = content;
                }
                else if (path.EndsWith(".png"))
                {
                    // Hiển thị file .png trong PictureBox với kích thước stretch trong richTextBox1
                    richTextBox1.Clear(); // Xóa nội dung trước đó
                    PictureBox pictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.Fill,
                        Image = Image.FromFile(path),
                        Width = richTextBox1.Width,
                        Height = richTextBox1.Height
                    };

                    // Clear and add PictureBox into richTextBox1
                    richTextBox1.Controls.Clear();
                    richTextBox1.Controls.Add(pictureBox);
                }
            }
            else if (Directory.Exists(path))
            {
                // Nếu là thư mục, bạn có thể hiển thị danh sách file trong thư mục
                LoadFilesAndDirectories(e.Node); // Nếu bạn muốn tải tiếp các tập tin và thư mục con
            }
        }

        private void LoadFilesAndDirectories(TreeNode node)
        {
            try
            {
                // Xóa node placeholder
                node.Nodes.Clear();

                // Lấy các thư mục con và thêm vào TreeNode
                var dirs = Directory.GetDirectories(node.Tag.ToString());
                foreach (var dir in dirs)
                {
                    try
                    {
                        TreeNode directoryNode = new TreeNode(Path.GetFileName(dir))
                        {
                            Tag = dir
                        };
                        // Thêm Node placeholder nếu thư mục này có thư mục con
                        if (Directory.GetDirectories(dir).Length > 0)
                        {
                            directoryNode.Nodes.Add(new TreeNode()); // Placeholder
                        }
                        node.Nodes.Add(directoryNode);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue; // Bỏ qua nếu không có quyền truy cập
                    }
                }

                // Lấy các tập tin .txt và .png và thêm vào TreeNode
                var files = Directory.GetFiles(node.Tag.ToString(), "*.*")
                                     .Where(f => f.EndsWith(".txt") || f.EndsWith(".png"));
                foreach (var file in files)
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file
                    };
                    node.Nodes.Add(fileNode); // Thêm tập tin vào TreeNode
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to access this folder.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "") // Kiểm tra node placeholder
            {
                LoadFilesAndDirectories(e.Node); // Tải các thư mục và tập tin khi mở rộng
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = e.Node.Tag.ToString();

            // Kiểm tra xem node được chọn có phải là file ảnh .png hay không
            if (File.Exists(path) && path.EndsWith(".png"))
            {
                try
                {
                    // Nạp ảnh từ file
                    Image img = Image.FromFile(path);

                    // Copy hình ảnh vào Clipboard
                    Clipboard.SetImage(img);

                    // Dán hình ảnh vào RichTextBox
                    richTextBox1.Paste();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
