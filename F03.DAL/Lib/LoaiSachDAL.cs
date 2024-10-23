using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F03.DAL.Lib
{
    public class LoaiSachDAL
    {
        private QLSach dbContext;

        public LoaiSachDAL()
        {
            dbContext = new QLSach();
        }

        // Lấy danh sách tất cả thể loại sách
        public List<LoaiSach> GetAllLoaiSach()
        {
            return dbContext.LoaiSaches.ToList();
        }

        public int? GetMaLoaiByTenLoai(string tenLoai)
        {
            var loaiSach = dbContext.LoaiSaches.FirstOrDefault(ls => ls.TenLoai == tenLoai);
            return loaiSach?.MaLoai;
        }
    }
}
