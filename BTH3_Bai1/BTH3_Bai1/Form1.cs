using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTH3_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LogEvent(string eventName)
        {
            string logEntry = $"[{DateTime.Now:HH:mm:ss.fff}] - Sự kiện: {eventName}{Environment.NewLine}";
            lboxResult.Items.Add(logEntry);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogEvent("Load Form, đang tải dữ liệu.");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LogEvent("Shown: Form đã hiển thị lần đầu.");
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            LogEvent("Activate: Form được kích hoạt.");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            LogEvent("Deactivate: Form mất");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogEvent("Form closing: Form đang đóng");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogEvent("Form closed: Form đã đóng");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                LogEvent($"Resize: Kích thước mới ({this.Width}x{this.Height}).");
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            LogEvent($"Move: Vị trí mới ({this.Location.X}, {this.Location.Y}).");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            LogEvent("Click: 'Mở Modal Form'");

            using (Form modalForm = new Form())
            {
                modalForm.Text = "Child Modal Form";
                modalForm.Size = new Size(300, 150);
                modalForm.StartPosition = FormStartPosition.CenterParent;
                modalForm.ShowInTaskbar = false;
                Label lbl = new Label
                {
                    Text = "Đóng form này để quay lại Form chính.",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                modalForm.Controls.Add(lbl);
                LogEvent(">>> Chuẩn bị gọi ShowDialog()...");
                modalForm.ShowDialog(this);
                LogEvent(">>> ... ShowDialog() đã trả về.");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
