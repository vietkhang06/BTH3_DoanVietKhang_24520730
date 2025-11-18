using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BTH3_BT9
{
    public partial class Form1 : Form
    {
        private BindingList<SinhVien> danhSachSV = new BindingList<SinhVien>();
        private bool isClearing = false;
        public Form1()
        {
            InitializeComponent();
            SetupForm();
            dgvDsTtinSinhVien.DataSource = danhSachSV;
        }
        private void SetupForm()
        {
            cbChuyenNganh.DataSource = DuLieuMonHoc.GetChuyenNganhList();
            cbChuyenNganh.SelectedIndexChanged += cbChuyenNganh_SelectedIndexChanged;

            SetupDataGridViewColumns();

            btnChon.Click += btnChon_Click;
            btnBoChon.Click += btnBoChon_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoaChon.Click += btnXoaChon_Click;

            cbChuyenNganh_SelectedIndexChanged(cbChuyenNganh, EventArgs.Empty);
        }
        private void SetupDataGridViewColumns()
        {
            dgvDsTtinSinhVien.AutoGenerateColumns = false;
            dgvDsTtinSinhVien.Columns.Clear();

            dgvDsTtinSinhVien.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "MSSV", DataPropertyName = "MaSV", Width = 80 });
            dgvDsTtinSinhVien.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Họ Tên", DataPropertyName = "HoTen", Width = 150 });
            dgvDsTtinSinhVien.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Chuyên Ngành", DataPropertyName = "ChuyenNganh", Width = 150 });
            dgvDsTtinSinhVien.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Giới Tính", DataPropertyName = "GioiTinh", Width = 70 });
            dgvDsTtinSinhVien.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số Môn", DataPropertyName = "SoMonDangKy", Width = 80 });
        }
        private void cbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chuyenNganhDaChon = cbChuyenNganh.SelectedItem.ToString();

            lbxCacMonCoSan.Items.Clear();
            lbxCacMonDaChon.Items.Clear();

            if (DuLieuMonHoc.DanhSachMonHocTheoChuyenNganh.TryGetValue(chuyenNganhDaChon, out List<string> monHocMoi))
            {
                foreach (string mon in monHocMoi)
                {
                    lbxCacMonCoSan.Items.Add(mon);
                }
            }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            for (int i = lbxCacMonCoSan.SelectedItems.Count - 1; i >= 0; i--)
            {
                object item = lbxCacMonCoSan.SelectedItems[i];
                lbxCacMonDaChon.Items.Add(item);
                lbxCacMonCoSan.Items.Remove(item);
            }
        }
        private void btnBoChon_Click(object sender, EventArgs e)
        {
            for (int i = lbxCacMonDaChon.SelectedItems.Count - 1; i >= 0; i--)
            {
                object item = lbxCacMonDaChon.SelectedItems[i];
                lbxCacMonCoSan.Items.Add(item); 
                lbxCacMonDaChon.Items.Remove(item); 
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isClearing) return;
            if (string.IsNullOrWhiteSpace(tbMaSV.Text) || string.IsNullOrWhiteSpace(tbHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên và Họ tên.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Regex.IsMatch(tbMaSV.Text, @"^\d+$"))
            {
                MessageBox.Show("Mã sinh viên chỉ được phép nhập số.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbMaSV.Focus();
                return;
            }
            if (Regex.IsMatch(tbHoTen.Text, @"[\d!@#$%^&*(),.?""{}|<>_]"))
            {
                MessageBox.Show("Họ tên chỉ được chứa chữ cái và khoảng trắng.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbHoTen.Focus(); 
                return;
            }
            string gioiTinh = ckbNam.Checked ? "Nam" : (ckbNu.Checked ? "Nữ" : "Chưa chọn");

            if (gioiTinh == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn Giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (danhSachSV.Any(sv => sv.MaSV == tbMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng sử dụng chức năng cập nhật.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> monHocDaChon = lbxCacMonDaChon.Items.Cast<string>().ToList();
            SinhVien svMoi = new SinhVien
            {
                MaSV = tbMaSV.Text,
                HoTen = tbHoTen.Text,
                ChuyenNganh = cbChuyenNganh.SelectedItem.ToString(),
                GioiTinh = gioiTinh,
                MonDaDangKy = monHocDaChon
            };
            danhSachSV.Add(svMoi);
            MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextbox();
        }
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            ClearTextbox();
            lbxCacMonDaChon.Items.Clear();
            cbChuyenNganh_SelectedIndexChanged(cbChuyenNganh, EventArgs.Empty);
        }
        private void ClearTextbox()
        {
            isClearing = true; 
            this.AutoValidate = AutoValidate.Disable;

            cbChuyenNganh.SelectedIndexChanged -= cbChuyenNganh_SelectedIndexChanged;

            tbMaSV.Clear();
            tbHoTen.Clear();
            cbChuyenNganh.SelectedIndex = 0;
            ckbNam.Checked = false;
            ckbNu.Checked = false;
            cbChuyenNganh.SelectedIndexChanged += cbChuyenNganh_SelectedIndexChanged;
            cbChuyenNganh_SelectedIndexChanged(cbChuyenNganh, EventArgs.Empty);
            tbMaSV.Focus();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            isClearing = false;
        }
        private void ckbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNam.Checked)
            {
                if (ckbNu.Checked)
                {
                    MessageBox.Show("Vui lòng chỉ chọn một giới tính (Nam hoặc Nữ).", "Lỗi Giới Tính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ckbNam.Checked = false;
                }
            }
        }
        private void ckbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNu.Checked)
            {
                if (ckbNam.Checked)
                {
                    MessageBox.Show("Vui lòng chỉ chọn một giới tính (Nam hoặc Nữ).", "Lỗi Giới Tính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ckbNu.Checked = false;
                }
            }
        }
    }
}