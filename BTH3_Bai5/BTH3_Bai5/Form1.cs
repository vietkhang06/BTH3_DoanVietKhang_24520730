using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH3_Bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool LayDuLieu(out double so1, out double so2)
        {
            so1 = 0;
            so2 = 0;
            bool check1 = double.TryParse(tbNum1.Text, out so1);
            bool check2 = double.TryParse(tbNum2.Text, out so2);
            if (!check1 || !check2)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ vào cả hai ô!", "Lỗi Đầu Vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (LayDuLieu(out double so1, out double so2))
            {
                double ketQua = so1 + so2;
                tbAnswer.Text = ketQua.ToString();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (LayDuLieu(out double so1, out double so2))
            {
                double ketQua = so1 - so2;
                tbAnswer.Text = ketQua.ToString();
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (LayDuLieu(out double so1, out double so2))
            {
                double ketQua = so1 * so2;
                tbAnswer.Text = ketQua.ToString();
            }
        }

        private void btnDivine_Click(object sender, EventArgs e)
        {
            if (LayDuLieu(out double so1, out double so2))
            {
                if (so2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi Phép Tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAnswer.Text = "Không xác định";
                }
                else
                {
                    double ketQua = so1 / so2;
                    tbAnswer.Text = ketQua.ToString();
                }
            }
        }
    }
}
