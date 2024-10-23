using F02.BUS.Entities;
using F03.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F01.GUI
{
    public partial class FrmMain : Form
    {
        private LoaiSachBUS loaiSachBUS;
        private SachBUS sachBUS;
        public FrmMain()
        {
            InitializeComponent();
            loaiSachBUS = new LoaiSachBUS();
            sachBUS = new SachBUS();    
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách thể loại sách từ BUS và đổ vào ComboBox
                var theLoaiList = loaiSachBUS.GetAllLoaiSach();
                cboTheLoai.DataSource = theLoaiList;
                cboTheLoai.DisplayMember = "TenLoai"; // Hiển thị tên thể loại
                cboTheLoai.ValueMember = "MaLoai"; // Giá trị tương ứng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            SetUp();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void SetUp()
        {
            //try
            //{
            //    // Lấy danh sách sách từ BUS và đổ vào DataGridView
            //    var sachList = sachBUS.GetAllSach();
            //    var data = (from s in sachList
            //                select new
            //                {
            //                    MaSach = s.MaSach,
            //                    TenSach = s.TenSach,
            //                    NamXB = s.NamXB,
            //                    TheLoai = s.LoaiSach.TenLoai
            //                }).ToList();

            //    dgvQLSach.DataSource = data;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            //}


            // Hiển thị danh sách khu vực thông qua mô hình 3 lớp 
            var sachList = sachBUS.GetAllSach();
            dgvQLSach.Rows.Clear();
            foreach (var sach in sachList)
            {
                dgvQLSach.Rows.Add(sach.MaSach,sach.TenSach,sach.NamXB,sach.LoaiSach.TenLoai);
            }
            ResetInputFields();
        }

        private void ResetInputFields()
        {
            txtMaSach.Text = string.Empty;
            txtTenSach.Text = string.Empty;
            txtNamXB.Text = string.Empty;
            cboTheLoai.SelectedIndex = -1;
            txtTimKiem.Text = string.Empty;
        }

        private void dgvQLSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào dòng hợp lệ (không phải dòng tiêu đề hoặc dòng trống)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại mà người dùng vừa nhấp vào
                DataGridViewRow row = dgvQLSach.Rows[e.RowIndex];
                var indexcbo = loaiSachBUS.GetMaLoaiByTenLoai(row.Cells["TheLoai"].Value?.ToString());  
                cboTheLoai.SelectedValue = indexcbo;
                // Đẩy giá trị từ cột "colMaDinhDanh" vào txtMaSo
                txtMaSach.Text = row.Cells["MaSach"].Value?.ToString();
                // Đẩy giá trị từ cột "colTenKhuVuc" vào txtTen
                txtNamXB.Text = row.Cells["NamXB"].Value?.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();

                // Khi có dữ liệu được chọn, bật nút Sửa và Xóa, tắt nút Thêm
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                
            }
            else
            {
                // Nếu không có dòng hợp lệ được chọn, chỉ bật nút Thêm
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                ResetInputFields();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(txtNamXB.Text) ||
                cboTheLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMaSach.Text.Length != 6)
            {
                MessageBox.Show("Mã sách phải có 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sach = new Sach
                {
                    MaSach = txtMaSach.Text,
                    TenSach = txtTenSach.Text,
                    NamXB = int.Parse(txtNamXB.Text),
                    MaLoai = ((LoaiSach)cboTheLoai.SelectedItem).MaLoai
                };

                sachBUS.AddSach(sach);
                //MessageBox.Show(((LoaiSach)cboTheLoai.SelectedItem).ToString());
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                string.IsNullOrWhiteSpace(txtTenSach.Text) ||
                string.IsNullOrWhiteSpace(txtNamXB.Text) ||
                cboTheLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMaSach.Text.Length != 6)
            {
                MessageBox.Show("Mã sách phải có 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sach = new Sach
                {
                    MaSach = txtMaSach.Text,
                    TenSach = txtTenSach.Text,
                    NamXB = int.Parse(txtNamXB.Text),
                    MaLoai = ((LoaiSach)cboTheLoai.SelectedItem).MaLoai
                };

                sachBUS.UpdateSach(sach);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var maSach = txtMaSach.Text;

            if (string.IsNullOrWhiteSpace(maSach))
            {
                MessageBox.Show("Vui lòng nhập mã sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sach = sachBUS.GetSachByMa(maSach);

                if (sach == null)
                {
                    MessageBox.Show("Sách cần xóa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sachBUS.DeleteSach(maSach);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetUp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvQLSach.Rows.Clear();
            try
            {
                var sachList = sachBUS.SearchSach(keyword);
                foreach (var sach in sachList)
                {
                    dgvQLSach.Rows.Add(sach.MaSach, sach.TenSach, sach.NamXB, sach.LoaiSach.TenLoai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void tstripThongKeSachTheoNam_Click(object sender, EventArgs e)
        {
            FrmBaoCao frmBaoCao = new FrmBaoCao();
            if (frmBaoCao != null)
            {
                frmBaoCao.ShowDialog();
            }
            
        }
    }
}
