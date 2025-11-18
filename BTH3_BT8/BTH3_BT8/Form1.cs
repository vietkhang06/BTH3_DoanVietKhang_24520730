using BTH3_BT8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BTH3_BT8
{
    public partial class Form1 : Form
    {
        private List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>();
        public Form1()
        {
            InitializeComponent();
            SetupListDsTaiKhoan();
        }
        private void SetupListDsTaiKhoan()
        {
            lvDsTaiKhoan.SelectedIndexChanged += lvDsTaiKhoan_SelectedIndexChanged;
            InputDataToListView();
        }
        private void InputDataToListView()
        {
            lvDsTaiKhoan.Items.Clear();

            int stt = 1;
            foreach (var tk in danhSachTaiKhoan)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(tk.MaTaiKhoan.ToString());
                item.SubItems.Add(tk.TenKhachHang);
                item.SubItems.Add(tk.DiaChi);
                item.SubItems.Add(tk.SoTien.ToString("N0"));
                item.Tag = tk;

                lvDsTaiKhoan.Items.Add(item);
                stt++;
            }
            TinhTongTien();
        }
        private void TinhTongTien()
        {
            decimal tong = danhSachTaiKhoan.Sum(tk => tk.SoTien);
            tbTongTien.Text = tong.ToString("N0") + " VND";
        }
        private void ClearTextBox()
        {
            tbSTK.Clear();
            tbTenKH.Clear();
            tbDiaChi.Clear();
            tbSoTien.Clear();
            tbSTK.Focus();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSTK.Text) || string.IsNullOrWhiteSpace(tbTenKH.Text) || string.IsNullOrWhiteSpace(tbDiaChi.Text) || string.IsNullOrWhiteSpace(tbSoTien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(tbSTK.Text, out int maTaiKhoan) || !decimal.TryParse(tbSoTien.Text, out decimal soTien))
            {
                MessageBox.Show("Số tài khoản hoặc Số tiền không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TaiKhoan tkHienTai = danhSachTaiKhoan.FirstOrDefault(tk => tk.MaTaiKhoan == maTaiKhoan);

            if (tkHienTai == null)
            {
                TaiKhoan tkMoi = new TaiKhoan
                {
                    MaTaiKhoan = maTaiKhoan,
                    TenKhachHang = tbTenKH.Text,
                    DiaChi = tbDiaChi.Text,
                    SoTien = soTien
                };
                danhSachTaiKhoan.Add(tkMoi);
                MessageBox.Show("Thêm mới dữ liệu tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tkHienTai.TenKhachHang = tbTenKH.Text;
                tkHienTai.DiaChi = tbDiaChi.Text;
                tkHienTai.SoTien = soTien;

                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            InputDataToListView();
            ClearTextBox();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSTK.Text, out int maTaiKhoan))
            {
                MessageBox.Show("Vui lòng nhập Số tài khoản hợp lệ để xóa.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiKhoan tkCanXoa = danhSachTaiKhoan.FirstOrDefault(tk => tk.MaTaiKhoan == maTaiKhoan);

            if (tkCanXoa != null)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản " + maTaiKhoan.ToString() + " của khách hàng " + tkCanXoa.TenKhachHang + " ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    danhSachTaiKhoan.Remove(tkCanXoa);
                    InputDataToListView();
                    ClearTextBox();
                    MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lvDsTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDsTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDsTaiKhoan.SelectedItems[0];
                TaiKhoan tk = (TaiKhoan)selectedItem.Tag;
                tbSTK.Text = tk.MaTaiKhoan.ToString();
                tbTenKH.Text = tk.TenKhachHang;
                tbDiaChi.Text = tk.DiaChi;
                tbSoTien.Text = tk.SoTien.ToString();
            }
            else
            {
                ClearTextBox();
            }
        }
    }
}