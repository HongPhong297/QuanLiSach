using F02.BUS.Entities;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmBaoCao : Form
    {
        public FrmBaoCao()
        {
            InitializeComponent();
            SetUp();
        }
        SachBUS sachBUS = new SachBUS();
        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            // Đổ dữ liệu vào ComboBox cboNXB
            var namXBList = sachBUS.GetAllNamXB();

            foreach (var item in namXBList)
            {
                cboNXB.Items.Add(item);
            }
            //cboNXB.DataSource = namXBList;
            //cboNXB.SelectedIndex = -1;




            this.rptBaoCao.RefreshReport();
            //var hoaDonDTO = hoaDonBLL.GetBaoCaoHoaDon(thang, nam);
            var baoCaoDTO = sachBUS.ThongKeSachTheoNam();
            // In kết quả ra ngoài form
            rptBaoCao.LocalReport.ReportPath = "rptThongKe.rdlc";
            var dataReport = new ReportDataSource("DataSet1", baoCaoDTO);
            rptBaoCao.LocalReport.DataSources.Clear();
            rptBaoCao.LocalReport.DataSources.Add(dataReport);

            // Tạo danh sách các tham số cho báo cáo


            // Gán tham số vào ReportViewer
            //rptThongKeHoaDon.LocalReport.SetParameters(parameters);
            rptBaoCao.RefreshReport();
        }

        private void rptBaoCao_Load(object sender, EventArgs e)
        {

        }


        private void SetUp()
        {
            
        }

        private void cboNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNXB.SelectedIndex >= 0 && cboNXB.SelectedIndex >= 0)
            {
                this.rptBaoCao.RefreshReport();
                var nam = (int)cboNXB.SelectedItem;
                //var hoaDonDTO = hoaDonBLL.GetBaoCaoHoaDon(thang, nam);
                var baoCaoDTO = sachBUS.ThongKeSachTheoNam(nam);
                // In kết quả ra ngoài form
                rptBaoCao.LocalReport.ReportPath = "rptThongKe.rdlc";
                var dataReport = new ReportDataSource("DataSet1", baoCaoDTO);
                rptBaoCao.LocalReport.DataSources.Clear();
                rptBaoCao.LocalReport.DataSources.Add(dataReport);

                // Tạo danh sách các tham số cho báo cáo


                // Gán tham số vào ReportViewer
                //rptThongKeHoaDon.LocalReport.SetParameters(parameters);
                rptBaoCao.RefreshReport();
            }
        }
    }
}
