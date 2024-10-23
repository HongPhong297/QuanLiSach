using F03.DAL.Lib;
using F03.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F02.BUS.Entities
{
    public class SachBUS
    {
        private SachDAL sachDAL;

        public SachBUS()
        {
            sachDAL = new SachDAL();
        }

        // Lấy danh sách tất cả sách (nghiệp vụ gọi DAL)
        public List<Sach> GetAllSach()
        {
            return sachDAL.GetAllSach();
        }

        // Thêm sách mới (gọi DAL)
        public void AddSach(Sach sach)
        {
            sachDAL.AddSach(sach);
        }

        // Cập nhật thông tin sách (gọi DAL)
        public void UpdateSach(Sach sach)
        {
            sachDAL.UpdateSach(sach);
        }

        // Xóa sách (gọi DAL)
        public void DeleteSach(string maSach)
        {
            sachDAL.DeleteSach(maSach);
        }

        // Lấy sách dựa trên mã sách
        public Sach GetSachByMa(string maSach)
        {
            return sachDAL.GetSachByMa(maSach);
        }
        // Tìm kiếm sách theo MaSach, TenSach, hoặc NamXB
        public List<Sach> SearchSach(string keyword)
        {
            return sachDAL.SearchSach(keyword);
        }


        // Thống kê sách theo năm xuất bản
        public List<Sach> ThongKeSachTheoNam()
        {
            return sachDAL.ThongKeSachTheoNam();
        }


        // Lấy danh sách các năm xuất bản duy nhất
        public List<int> GetAllNamXB()
        {
            return sachDAL.GetAllNamXB();
        }

        public List<Sach> ThongKeSachTheoNam(int namXB)
        {
            return sachDAL.ThongKeSachTheoNam(namXB);
        }
    }
}
