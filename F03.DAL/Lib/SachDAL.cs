using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F03.DAL.Lib
{
    public class SachDAL
    {
        private QLSach dbContext;

        public SachDAL()
        {
            dbContext = new QLSach();
        }

        // Lấy danh sách tất cả sách
        public List<Sach> GetAllSach()
        {
            return dbContext.Saches.ToList();
        }


        // Thêm sách mới vào CSDL
        public void AddSach(Sach sach)
        {
            dbContext.Saches.Add(sach);
            dbContext.SaveChanges();
        }

        // Cập nhật thông tin sách trong CSDL
        public void UpdateSach(Sach sach)
        {
            var existingSach = dbContext.Saches.FirstOrDefault(s => s.MaSach == sach.MaSach);
            if (existingSach != null)
            {
                existingSach.TenSach = sach.TenSach;
                existingSach.NamXB = sach.NamXB;
                existingSach.MaLoai = sach.MaLoai;
                dbContext.SaveChanges();
            }
        }

        // Xóa sách khỏi CSDL
        public void DeleteSach(string maSach)
        {
            var sach = dbContext.Saches.FirstOrDefault(s => s.MaSach == maSach);
            if (sach != null)
            {
                dbContext.Saches.Remove(sach);
                dbContext.SaveChanges();
            }
        }

        // Lấy sách dựa trên mã sách
        public Sach GetSachByMa(string maSach)
        {
            return dbContext.Saches.FirstOrDefault(s => s.MaSach == maSach);
        }


        // Tìm kiếm sách theo MaSach, TenSach, hoặc NamXB
        public List<Sach> SearchSach(string keyword)
        {
            return dbContext.Saches
                            .Where(s => s.MaSach.Contains(keyword) ||
                                        s.TenSach.Contains(keyword) ||
                                        s.NamXB.ToString().Contains(keyword))
                            .Include("LoaiSach")
                            .ToList();
        }


        public List<Sach> ThongKeSachTheoNam()
        {
            return dbContext.Saches
                            .OrderBy(s => s.NamXB)
                            .ToList();
        }


        // Lấy danh sách các năm xuất bản duy nhất
        public List<int> GetAllNamXB()
        {
            return dbContext.Saches
                            .Select(s => s.NamXB)
                            .Distinct()
                            .OrderBy(n => n)
                            .ToList();
        }

        // Hàm thống kê sách theo năm xuất bản
        public List<Sach> ThongKeSachTheoNam(int namXB)
        {
            return dbContext.Saches
                            .Where(s => s.NamXB == namXB)
                            .ToList();
        }
    }
}
